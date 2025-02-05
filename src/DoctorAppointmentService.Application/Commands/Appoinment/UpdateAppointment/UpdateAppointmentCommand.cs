using DoctorAppointmentService.Domain.Interfaces;
using MediatR;


namespace DoctorAppointmentService.Application.Commands.Appoinment.UpdateAppointment;

/// <summary>
/// Update Appointment Command
/// </summary>
public class UpdateAppointmentCommand : IRequest<UpdateAppointmentResult>

{
    public string Id { get; set; }
    public string PatientName { get; set; }
    public string DoctorId { get; set; }
    public DateTime AppointmentDateTime { get; set; }
}

/// <summary>
/// Update Appointment Command Handler
/// </summary>
public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, UpdateAppointmentResult>
{
    /// <summary>
    private readonly IAppointmentRepository _appointmentRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="appointmentRepository"></param>
    public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<UpdateAppointmentResult> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.Id);

        if (appointment == null)
        {
            return new UpdateAppointmentResult(false, "Appointment not found");
        }

        appointment.PatientName = request.PatientName;
        appointment.DoctorId = request.DoctorId;
        appointment.AppointmentDateTime = request.AppointmentDateTime;

        await _appointmentRepository.UpdateAsync(appointment);

        return new UpdateAppointmentResult(true, "Appointment updated successfully");
    }


}

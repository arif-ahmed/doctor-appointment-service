
using DoctorAppointmentService.Application.Commands.Appoinment.UpdateAppointment;
using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Commands.Appointment.UpdateAppointment;

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

        if (!string.IsNullOrEmpty(request.PatientName))
        {
            appointment.PatientName = request.PatientName;
        }

        if (!string.IsNullOrEmpty(request.DoctorId)) 
        {
            appointment.DoctorId = request.DoctorId;
        }

        if (request.AppointmentDate != appointment.AppointmentDate)
        {
            appointment.AppointmentDate = request.AppointmentDate;
        }

        await _appointmentRepository.UpdateAsync(appointment);

        return new UpdateAppointmentResult(true, "Appointment updated successfully");
    }
}

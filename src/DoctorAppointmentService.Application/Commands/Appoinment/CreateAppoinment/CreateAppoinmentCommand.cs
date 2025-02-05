using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Commands.Appoinment.CreateAppoinment;

public class CreateAppoinmentCommand : IRequest<string>
{
    public required string PatientName { get; set; }
    public required string DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }    
}


public class CreateAppoinmentCommandHandler : IRequestHandler<CreateAppoinmentCommand, string>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CreateAppoinmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<string> Handle(CreateAppoinmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = new Appointment {
            PatientName = request.PatientName,
            DoctorId = request.DoctorId,
            AppointmentDateTime = request.AppointmentDate
        };

        await _appointmentRepository.AddAsync(appointment);

        return appointment.Id;
    }

}


using MediatR;

namespace DoctorAppointmentService.Application.Commands.Appointment.CancelAppointment;

public class CancelAppointmentCommand : IRequest<CancelAppointmentResult>
{
    public required string Id { get; set; }
}


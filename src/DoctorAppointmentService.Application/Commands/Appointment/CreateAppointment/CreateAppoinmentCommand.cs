using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Commands.Appointment.CreateAppointment;

public class CreateAppoinmentCommand : IRequest<string>
{
    public required string PatientName { get; set; }
    public required string DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }    
}





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
    public DateTime AppointmentDate { get; set; }
}


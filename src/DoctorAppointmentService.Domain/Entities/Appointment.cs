namespace DoctorAppointmentService.Domain.Entities;

public class Appointment : BaseEntity
{
    public required string PatientName { get; set; }
    public string PatientContactInfo { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public required string DoctorId { get; set; } = string.Empty;    
}
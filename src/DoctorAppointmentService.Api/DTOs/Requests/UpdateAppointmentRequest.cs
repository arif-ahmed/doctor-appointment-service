namespace DoctorAppointmentService.Api.DTOs.Requests;
public class UpdateAppointmentRequest
{
    public string? PatientName { get; set; }
    public string? DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
}

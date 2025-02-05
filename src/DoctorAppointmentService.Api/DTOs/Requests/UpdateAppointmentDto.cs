namespace DoctorAppointmentService.Api.DTOs.Requests;
public class UpdateAppointmentDto
{
    public string Id { get; set; }
    public string PatientName { get; set; }
    public string DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
}

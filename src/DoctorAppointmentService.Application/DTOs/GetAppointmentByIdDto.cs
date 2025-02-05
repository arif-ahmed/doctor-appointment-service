namespace DoctorAppointmentService.Application.DTOs;

public record GetAppointmentByIdDto(string Id, string PatientName, string DoctorId, DateTime AppointmentDateTime);



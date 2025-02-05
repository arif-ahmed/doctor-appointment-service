namespace DoctorAppointmentService.Application.DTOs;

public record GetAllAppoinmentsQueryResult(List<AppointmentDTO> Appointments, int TotalCount);





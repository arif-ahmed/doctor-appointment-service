namespace DoctorAppointmentService.Domain.Interfaces;

public interface IAuditEntry
{
    string CreatedById { get; set; }
    string UpdatedById { get; set; }
    string DeletedById { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
    DateTime? DeletedAt { get; set; }
    bool IsActive { get; set; }
}

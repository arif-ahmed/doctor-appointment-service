using DoctorAppointmentService.Domain.Interfaces;

namespace DoctorAppointmentService.Domain.Entities;

public class BaseEntity : IAuditEntry
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; } = null;
    public string CreatedById { get; set; } = string.Empty;
    public string UpdatedById { get; set; } = string.Empty;
    public string DeletedById { get; set; } = string.Empty;
}



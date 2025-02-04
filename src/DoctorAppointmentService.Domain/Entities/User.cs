namespace DoctorAppointmentService.Domain.Entities;

public class User : BaseEntity
{
    public User(string name, string email, string passwordHash)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }    
}



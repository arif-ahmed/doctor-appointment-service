namespace DoctorAppointmentService.Domain.Entities;

public class User : BaseEntity
{
    public User(string userName, string email, string passwordHash)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }    
}




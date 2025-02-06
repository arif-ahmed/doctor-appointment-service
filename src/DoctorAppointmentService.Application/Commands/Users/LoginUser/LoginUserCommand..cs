using MediatR;

namespace DoctorAppointmentService.Application.Commands.Users.LoginUser;

public class LoginUserCommand : IRequest<LoginUserResult>
{
    public LoginUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}


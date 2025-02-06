using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Commands.Users.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResult>
{
    private readonly ITokenService _tokenService;
    public LoginUserCommandHandler(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }
    public Task<LoginUserResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // var user = await _userManager.FindByEmailAsync(request.Email);

        // if (user == null)
        // {
        //     throw new Exception("User not found");
        // }

        // var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        // if (!result.Succeeded)
        // {
        //     throw new Exception("Invalid password");
        // }

        // return new LoginUserResult(user.Id, user.Email, user.UserName);

        var accessToken = _tokenService.GenerateToken();


        return Task.FromResult(new LoginUserResult(accessToken, string.Empty, DateTime.Now.AddDays(1)));


    }
}

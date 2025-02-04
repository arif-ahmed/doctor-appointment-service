using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Commands.Users;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email, request.PasswordHash);
        await _userRepository.AddAsync(user);
        return new CreateUserResult(user.Id, "User created successfully");
    }
}


using MediatR;

namespace DoctorAppointmentService.Application.Commands.Users;
public record CreateUserCommand(string Name, string Email, string PasswordHash) : IRequest<CreateUserResult>;



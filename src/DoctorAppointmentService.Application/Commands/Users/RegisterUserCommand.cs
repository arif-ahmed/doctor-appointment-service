using MediatR;

namespace DoctorAppointmentService.Application.Commands.Users;
public record RegisterUserCommand(string UserName, string Email, string PasswordHash) : IRequest<RegisterUserResult>;



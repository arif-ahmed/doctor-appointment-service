namespace DoctorAppointmentService.Application.Commands.Users.LoginUser;

public record LoginUserResult(string AccessToken, string RefreshToken, DateTime ExpiresAt);


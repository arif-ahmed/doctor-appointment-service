using DoctorAppointmentService.Api.DTOs.Responses;
using Microsoft.AspNetCore.Identity.Data;

namespace DoctorAppointmentService.Api.Interfaces;
public interface IAuthService
{
    Task RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
}

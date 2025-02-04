using DoctorAppointmentService.Api.DTOs.Requests;
using DoctorAppointmentService.Api.Interfaces;
using DoctorAppointmentService.Api.Security;
using DoctorAppointmentService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthController(IAuthService authService, ITokenService tokenService, IPasswordHasher<User> passwordHasher)
    {
        _authService = authService;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        try
        {
            await _authService.RegisterAsync(request);
            return Ok(new { message = "User registered successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var response = await _authService.LoginAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }    
}

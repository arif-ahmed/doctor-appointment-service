using DoctorAppointmentService.Api.DTOs.Requests;
using DoctorAppointmentService.Api.Interfaces;
using DoctorAppointmentService.Api.Security;
using DoctorAppointmentService.Application.Commands.Users;
using DoctorAppointmentService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    // private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IMediator _mediator;

    public AuthController(ITokenService tokenService, IPasswordHasher<User> passwordHasher, IMediator mediator)
    {
        // _authService = authService;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
        _mediator = mediator;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        try
        {
            var command = new RegisterUserCommand(request.Email, request.Email, request.Password);
            var result = await _mediator.Send(command);
            return Ok(new { message = "User registered successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    //[HttpPost("login")]
    //public async Task<IActionResult> Login([FromBody] LoginRequest request)
    //{
    //    try
    //    {
    //        var response = await _authService.LoginAsync(request);
    //        return Ok(response);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { error = ex.Message });
    //    }
    //}    
}

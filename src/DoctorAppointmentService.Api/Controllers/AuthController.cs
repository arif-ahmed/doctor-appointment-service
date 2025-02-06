using DoctorAppointmentService.Api.DTOs.Requests;
using DoctorAppointmentService.Application.Commands.Users;
using DoctorAppointmentService.Application.Commands.Users.LoginUser;
using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using DoctorAppointmentService.Infrastructure.Models;
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
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tokenService"></param>
    /// <param name="passwordHasher"></param>
    /// <param name="mediator"></param>
    /// <param name="userManager"></param>
    /// <param name="signInManager"></param>
    public AuthController(ITokenService tokenService, IPasswordHasher<User> passwordHasher, IMediator mediator, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        // _authService = authService;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
        _mediator = mediator;
        _userManager = userManager;
        _signInManager = signInManager;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
    {
        try
        {
            var command = new LoginUserCommand(request.Email, request.Password);
            var result = await _mediator.Send(command);

            return Ok(new { accessToken = result.AccessToken, refreshToken = result.RefreshToken, expiresAt = result.ExpiresAt });

        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

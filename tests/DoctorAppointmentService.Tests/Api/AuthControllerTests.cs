// using DoctorAppointmentService.Api.Controllers;
// using DoctorAppointmentService.Api.Interfaces;
// using DoctorAppointmentService.Api.Security;
// using DoctorAppointmentService.Domain.Entities;
// using MediatR;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.Data;
// using Microsoft.AspNetCore.Mvc;
// using Moq;

// namespace DoctorAppointmentService.Tests.Api;

// public class AuthControllerTests
// {
//     private readonly AuthController _controller;
//     private readonly Mock<IAuthService> _authServiceMock;
//     private readonly Mock<ITokenService> _tokenServiceMock;
//     private readonly Mock<IPasswordHasher<User>> _passwordHasherMock;
//     private readonly Mock<IMediator> _mediatorMock;
//     private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
//     private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;


//     public AuthControllerTests()
//     {   
//         _authServiceMock = new Mock<IAuthService>();
//         _tokenServiceMock = new Mock<ITokenService>();
//         _passwordHasherMock = new Mock<IPasswordHasher<User>>();
//         _mediatorMock = new Mock<IMediator>();
//         _userManagerMock = new Mock<UserManager<ApplicationUser>>();
//         _signInManagerMock = new Mock<SignInManager<ApplicationUser>>();



//         _controller = new AuthController(_tokenServiceMock.Object, _passwordHasherMock.Object, _mediatorMock.Object, _userManagerMock.Object, _signInManagerMock.Object);
//     }


//     [Fact]
//     public async Task Register_ReturnsOkResult()
//     {
//         // Arrange
//         var request = new RegisterRequest
//         {
//             Email = "test@example.com",
//             Password = "password123"
//         };          

//         // Act
//         var result = await _controller.Register(request);

//         // Assert
//         Assert.IsType<OkObjectResult>(result);
//     }
// }


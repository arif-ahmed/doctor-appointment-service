using DoctorAppointmentService.Application.Commands.Appoinment.CreateAppoinment;
using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using Moq;

namespace DoctorAppointmentService.Tests.Application;

public class CreateAppoinmentCommandTests
{
    [Fact]
    public async Task CreateAppoinmentCommand_Should_Return_String()
    {
        // Arrange
        var command = new CreateAppoinmentCommand { PatientName = "John Doe", DoctorId = Guid.NewGuid().ToString(), AppointmentDate = DateTime.Now };

        var appointmentRepositoryMock = new Mock<IAppointmentRepository>();
        appointmentRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Appointment>())).ReturnsAsync(new Appointment { Id = Guid.NewGuid().ToString(), PatientName = command.PatientName, DoctorId = command.DoctorId, AppointmentDateTime = command.AppointmentDate });

        // Act
        var result = await new CreateAppoinmentCommandHandler(appointmentRepositoryMock.Object).Handle(command, CancellationToken.None);

        // Assert
        Assert.IsType<string>(result);
    }
}


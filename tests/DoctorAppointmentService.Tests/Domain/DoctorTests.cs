
using DoctorAppointmentService.Domain.Entities;

namespace DoctorAppointmentService.Tests.Domain;

/// <summary>
/// This class contains tests for the Doctor entity.
/// </summary>
public class DoctorTests
{
    /// <summary>
    /// This test checks if the Doctor entity has a Name property.
    /// </summary>
    [Fact]
    public void Doctor_Should_Have_Name()    
    {
        // Arrange
        var doctor = new Doctor { Name = "Dr. Smith" };
        // Act
        doctor.Name = "Dr. Smith";
        // Assert
        Assert.Equal("Dr. Smith", doctor.Name);
    }
}   

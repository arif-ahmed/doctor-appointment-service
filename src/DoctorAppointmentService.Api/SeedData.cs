using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentService.Api;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            // Insert if no users exist
            if (!context.Doctors.Any())
            {
                context.Doctors.AddRange(
                    new Doctor { Id = Guid.NewGuid().ToString(), Name = "Dr. Smith" },
                    new Doctor { Id = Guid.NewGuid().ToString(), Name = "Dr. Johnson" }
                );
                context.SaveChanges();
            }
        }
    }
}


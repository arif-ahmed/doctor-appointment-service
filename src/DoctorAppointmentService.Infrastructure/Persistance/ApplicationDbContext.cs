using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentService.Infrastructure.Persistance;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();    
    }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
        modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
        modelBuilder.Entity<ApplicationUser>().HasKey(u => u.Id);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DoctorAppointmentService;Trusted_Connection=True;");
        }
    }
}

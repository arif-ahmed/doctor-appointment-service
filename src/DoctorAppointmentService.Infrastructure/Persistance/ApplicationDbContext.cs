using DoctorAppointmentService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentService.Infrastructure.Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();    
    }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
        modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DoctorAppointmentService;Trusted_Connection=True;");
        }
    }
}

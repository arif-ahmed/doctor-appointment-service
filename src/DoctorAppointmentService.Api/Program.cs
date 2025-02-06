using System.Text;
using DoctorAppointmentService.Api;
using DoctorAppointmentService.Api.Middleware;
using DoctorAppointmentService.Api.Security;
using DoctorAppointmentService.Application.Commands.Appointment.CreateAppointment;
using DoctorAppointmentService.Application.Validators;
using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using DoctorAppointmentService.Infrastructure.Data;
using DoctorAppointmentService.Infrastructure.Models;
using DoctorAppointmentService.Infrastructure.Persistance;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAppointmentRepository, AppoinmentRepository>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();

builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddSingleton<ITokenService, JwtTokenService>();



// var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=.\\SQLEXPRESS;Database=DoctorAppointmentService;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("JwtSettings:Issuer is missing!"),
        ValidAudience = builder.Configuration["Jwt:Audience"] ?? throw new ArgumentNullException("JwtSettings:Audience is missing!"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new ArgumentNullException("JwtSettings:Key is missing!")))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Appointment.Read", policy => policy.RequireClaim("scope", "appointment.read"));
    options.AddPolicy("Appointment.Write", policy => policy.RequireClaim("scope", "appointment.write"));
    options.AddPolicy("Appointment.Delete", policy => policy.RequireClaim("scope", "appointment.delete"));
    options.AddPolicy("Appointment.Update", policy => policy.RequireClaim("scope", "appointment.update"));
    options.AddPolicy("Appointment.Create", policy => policy.RequireClaim("scope", "appointment.create"));
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Appointment API",
        Version = "v1",
        Description = "A simple appointment management API",
    });
});

// Register MediatR for all Application features
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAppoinmentCommand).Assembly));

// Register FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(CreateAppoinmentValidator).Assembly);


// Register MediatR Pipeline Behavior for Validation
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Appointment API V1");
        options.RoutePrefix = string.Empty; // Swagger at root URL
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.Run();

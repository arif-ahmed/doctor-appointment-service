using DoctorAppointmentService.Application.Commands.Appointment.CreateAppointment;
using FluentValidation;

namespace DoctorAppointmentService.Application.Commands.Appointment.CreateAppointment;

public class CreateAppoinmentValidator : AbstractValidator<CreateAppoinmentCommand>

{
    public CreateAppoinmentValidator()
    {
        RuleFor(x => x.PatientName).NotEmpty().WithMessage("Patient name is required");
        RuleFor(x => x.DoctorId).NotEmpty().WithMessage("Doctor id is required");
        RuleFor(x => x.AppointmentDate).NotEmpty().WithMessage("Appointment date is required");
    }

}


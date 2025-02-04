using DoctorAppointmentService.Application.Commands.Appoinment.CreateAppoinment;
using FluentValidation;

namespace DoctorAppointmentService.Application.Validators;

public class CreateAppoinmentValidator : AbstractValidator<CreateAppoinmentCommand>
{
    public CreateAppoinmentValidator()
    {
        RuleFor(x => x.PatientName).NotEmpty().WithMessage("Patient name is required");
        RuleFor(x => x.DoctorId).NotEmpty().WithMessage("Doctor id is required");
        RuleFor(x => x.AppointmentDate).NotEmpty().WithMessage("Appointment date is required");
    }

}


using DoctorAppointmentService.Application.Commands.Appoinment.UpdateAppointment;
using FluentValidation;

namespace DoctorAppointmentService.Application.Validators;

public class UpdateAppointmentValidator : AbstractValidator<UpdateAppointmentCommand>
{
    public UpdateAppointmentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        RuleFor(x => x.PatientName)
            .NotEmpty()
            .WithMessage("PatientName is required");

        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("DoctorId is required");

        RuleFor(x => x.AppointmentDateTime)
            .NotEmpty()
            .WithMessage("AppointmentDateTime is required");
    }
}


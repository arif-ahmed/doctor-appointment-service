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
    }
}


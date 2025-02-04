using FluentValidation;

namespace DoctorAppointmentService.Api.DTOs.Requests;

public class CreateAppoinmentRequest
{
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string DoctorId { get; set; }
}

public class CreateAppoinmentRequestValidator : AbstractValidator<CreateAppoinmentRequest>
{
    public CreateAppoinmentRequestValidator()
    {
        RuleFor(x => x.PatientName).NotEmpty();
        RuleFor(x => x.AppointmentDate).NotEmpty();
        RuleFor(x => x.DoctorId).NotEmpty();
    }
}



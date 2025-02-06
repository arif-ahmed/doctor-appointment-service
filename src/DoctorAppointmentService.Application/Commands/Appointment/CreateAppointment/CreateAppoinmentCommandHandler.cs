using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Commands.Appointment.CreateAppointment;

public class CreateAppoinmentCommandHandler : IRequestHandler<CreateAppoinmentCommand, string>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CreateAppoinmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<string> Handle(CreateAppoinmentCommand request, CancellationToken cancellationToken)
    {

        var conflictingAppointment = await _appointmentRepository.SearchAsync(x => x.AppointmentDate == request.AppointmentDate && x.DoctorId == request.DoctorId);

        if (conflictingAppointment.Any())
        {
            throw new Exception("Doctor is already booked at this time");
        }

        var appointment = new Domain.Entities.Appointment
        {
            PatientName = request.PatientName,
            DoctorId = request.DoctorId,
            AppointmentDate = request.AppointmentDate,
            IsActive = true
        };



        await _appointmentRepository.AddAsync(appointment);

        return appointment.Id;
    }

}
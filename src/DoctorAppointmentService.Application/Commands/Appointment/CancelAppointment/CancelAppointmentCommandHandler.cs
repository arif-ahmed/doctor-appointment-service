using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Commands.Appointment.CancelAppointment;

public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, CancelAppointmentResult>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public CancelAppointmentCommandHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<CancelAppointmentResult> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)

    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.Id);
        if (appointment == null)
        {
            return new CancelAppointmentResult(false, "Appointment not found");
        }

        appointment.IsCancelled = true;
        appointment.IsActive = false;

        await _appointmentRepository.UpdateAsync(appointment);

        return new CancelAppointmentResult(true, "Appointment cancelled successfully");
    }
}

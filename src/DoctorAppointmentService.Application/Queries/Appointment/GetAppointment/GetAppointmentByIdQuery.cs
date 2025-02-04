using DoctorAppointmentService.Application.DTOs;
using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Queries.Appointment.GetAppointment;

public class GetAppointmentByIdQuery : IRequest<GetAppointmentByIdDto>
{
    public string Id { get; set; }
}

public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, GetAppointmentByIdDto>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetAppointmentByIdQueryHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<GetAppointmentByIdDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(request.Id);

        if (appointment == null)
        {
            throw new Exception("Appointment not found");
        }
        
        return new GetAppointmentByIdDto(appointment.Id, appointment.PatientName, appointment.DoctorId, appointment.AppointmentDateTime);    
    }
}




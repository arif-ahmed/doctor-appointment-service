using DoctorAppointmentService.Application.DTOs;
using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Queries.Appointment.GetAllAppoinments;

public class GetAllAppoinmentsQuery : IRequest<GetAllAppoinmentsQueryResult>
{
    public string SearchText { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; } = "CreatedAt";
    public string SortOrder { get; set; } = "asc";
}





public class GetAllAppoinmentsQueryHandler : IRequestHandler<GetAllAppoinmentsQuery, GetAllAppoinmentsQueryResult>
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetAllAppoinmentsQueryHandler(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<GetAllAppoinmentsQueryResult> Handle(GetAllAppoinmentsQuery request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.SearchAsync(x => x.PatientName.Contains(request.SearchText), request.Page, request.PageSize);
        
        var totalCount = await _appointmentRepository.CountAsync(x => x.PatientName.Contains(request.SearchText));

        return new GetAllAppoinmentsQueryResult(appointments.Select(x => new AppointmentDTO(x.Id, x.PatientName, x.DoctorId, x.AppointmentDate)).ToList(), totalCount);
    }
}

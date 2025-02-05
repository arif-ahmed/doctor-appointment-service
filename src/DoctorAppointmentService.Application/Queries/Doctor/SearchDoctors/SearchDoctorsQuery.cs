using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Queries.Doctor.SearchDoctors;

public class SearchDoctorsQuery : IRequest<List<Domain.Entities.Doctor>>
{
    public string Text { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } = "CreatedAt";
    public string SortOrder { get; set; } = "asc";
}


public class SearchDoctorsQueryHandler : IRequestHandler<SearchDoctorsQuery, List<Domain.Entities.Doctor>>
{
    private readonly IDoctorRepository _doctorRepository;

    public SearchDoctorsQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<List<Domain.Entities.Doctor>> Handle(SearchDoctorsQuery request, CancellationToken cancellationToken)
    {
        return await _doctorRepository.SearchAsync(doctor => doctor.Name.Contains(request.Text), request.Page, request.PageSize, request?.SortBy ?? "CreatedAt", request?.SortOrder ?? "asc");
    }

}

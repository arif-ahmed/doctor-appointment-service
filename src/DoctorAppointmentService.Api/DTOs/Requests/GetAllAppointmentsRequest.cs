namespace DoctorAppointmentService.Api.DTOs.Requests;
public class GetAllAppointmentsRequest
{
    public string? SearchText { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } = "CreatedAt";
    public string SortOrder { get; set; } = "asc";
}



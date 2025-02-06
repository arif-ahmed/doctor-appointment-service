using DoctorAppointmentService.Application.DTOs;
using DoctorAppointmentService.Domain.Interfaces;
using MediatR;

namespace DoctorAppointmentService.Application.Queries.User.GetUsers;

public class GetUsersQuery : IRequest<GetUsersQueryResult>
{
    
}

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersQueryResult>
{
    private readonly IUserRepository _userRepository;
    
    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUsersQueryResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.SearchAsync(x => x.IsActive, 1, 10, "Name", "asc");


        var result = new GetUsersQueryResult
        {
            Users = users.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.UserName
            }).ToList()
        };

        return result;
    }
}


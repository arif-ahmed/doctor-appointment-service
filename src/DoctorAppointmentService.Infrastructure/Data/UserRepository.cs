
using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using System.Linq.Expressions;

namespace DoctorAppointmentService.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    public Task<User> AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(Expression<Func<User, bool>>? predicate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> SearchAsync(Expression<Func<User, bool>>? predicate, int page = 1, int pageSize = 10, string sortBy = "CreatedAt", bool isAscending = false)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> SearchAsync(Expression<Func<User, bool>>? predicate, int page = 1, int pageSize = 10, string sortBy = "CreatedAt", string SortOrder = "asc")
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }
}

using System.Linq.Expressions;
using DoctorAppointmentService.Domain.Entities;

namespace DoctorAppointmentService.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(string id);
    Task<List<T>> SearchAsync(Expression<Func<T, bool>>? predicate, int page = 1, int pageSize = 10, string sortBy = "CreatedAt", string SortOrder = "asc");
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(string id);

}



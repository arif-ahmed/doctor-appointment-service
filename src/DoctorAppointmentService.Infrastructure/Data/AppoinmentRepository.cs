
using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using DoctorAppointmentService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DoctorAppointmentService.Infrastructure.Data;

public class AppoinmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _context;

    public AppoinmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Appointment> AddAsync(Appointment entity)
    {
        await _context.Appointments.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> CountAsync(Expression<Func<Appointment, bool>>? predicate)
    {
        return await _context.Appointments.CountAsync(predicate);
    }


    public Task<bool> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Appointment> GetByIdAsync(string id)
    {
        return await _context.Appointments.FindAsync(id);
    }

    public async Task<List<Appointment>> SearchAsync(Expression<Func<Appointment, bool>>? predicate, int page = 1, int pageSize = 10, string sortBy = "CreatedAt", string SortOrder = "asc")
    {
        var query = _context.Appointments.AsQueryable();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        query = query.Skip((page - 1) * pageSize).Take(pageSize);
        // query = query.OrderBy(sortBy, isAscending);
        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<Appointment> UpdateAsync(Appointment entity)
    {
        var existingAppointment = await _context.Appointments
        .AsNoTracking()
        .FirstOrDefaultAsync(a => a.Id == entity.Id);

        if (existingAppointment == null)
            throw new Exception("Appointment not found");

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }


}

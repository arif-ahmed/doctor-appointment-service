using System.Linq.Expressions;
using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using DoctorAppointmentService.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentService.Infrastructure.Data;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;

    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Doctor> AddAsync(Doctor entity)
    {
        await _context.Doctors.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public Task<int> CountAsync(Expression<Func<Doctor, bool>>? predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null)
        {
            return false;
        }
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<Doctor> GetByIdAsync(string id)
    {
        return await _context.Doctors.FindAsync(id);
    }


    public async Task<List<Doctor>> SearchAsync(Expression<Func<Doctor, bool>>? predicate, int page = 1, int pageSize = 10, string sortBy = "CreatedAt", bool isAscending = false)
    {
        var query = _context.Doctors.AsQueryable();
        
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        query = query.Skip((page - 1) * pageSize).Take(pageSize);
        // query = query.OrderBy(sortBy, isAscending);
        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public Task<List<Doctor>> SearchAsync(Expression<Func<Doctor, bool>>? predicate, int page = 1, int pageSize = 10, string sortBy = "CreatedAt", string SortOrder = "asc")
    {
        throw new NotImplementedException();
    }

    public Task<Doctor> UpdateAsync(Doctor entity)

    {
        throw new NotImplementedException();
    }

    public string ReverseString(string str)
    {
        string reversedString = "";
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reversedString += str[i];
        }
        return reversedString;
    }

    public string Palindrome(string str)
    {
        string reversedString = ReverseString(str);
        if (reversedString == str)
        {
            return "Palindrome";
        }
        else
        {
            return "Not a Palindrome";
        }
    }

    public int GetFactorial(int num)
    {
        if (num == 0)
        {
            return 1;
        }
        else
        {
            return num * GetFactorial(num - 1);
        }
    }
}



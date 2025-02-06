using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Domain.Interfaces;
using DoctorAppointmentService.Infrastructure.Models;
using DoctorAppointmentService.Infrastructure.Persistance;
using DoctorAppointmentService.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DoctorAppointmentService.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;


    public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }




    public async Task<User> AddAsync(User entity)
    {
        var user = new ApplicationUser
        {
            UserName = entity.UserName,
            Email = entity.Email,
            PasswordHash = entity.PasswordHash
        };

        var result = await _userManager.CreateAsync(user, entity.PasswordHash);
        if (!result.Succeeded)
        {
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        return new User(user.UserName, user.Email, user.PasswordHash);
    }



    public async Task<int> CountAsync(Expression<Func<User, bool>>? predicate)
    {
        if (predicate == null)
        {
            return await _context.Users.CountAsync();
        }

        // Rewrite the predicate to use ApplicationUser instead of User
        var visitor = new UserToApplicationUserExpressionVisitor();
        var newExpression = (Expression<Func<ApplicationUser, bool>>)visitor.Visit(predicate);

        return await _context.Users.CountAsync(newExpression);
    }



    public async Task<bool> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        await _userManager.DeleteAsync(user);
        return true;
    }

    public async Task<User> GetByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        return new User(user.UserName, user.Email, user.PasswordHash);
    }


    public async Task<List<User>> SearchAsync(Expression<Func<User, bool>>? predicate, int page = 1, int pageSize = 10, string sortBy = "CreatedAt", string SortOrder = "asc")
    {
        if (predicate == null)
        {
            return await _context.Users.Skip((page - 1) * pageSize).Take(pageSize).Select(x => new User(x.UserName, x.Email, x.PasswordHash)).ToListAsync();
        }

        // Rewrite the predicate to use ApplicationUser instead of User
        var visitor = new UserToApplicationUserExpressionVisitor();
        var newExpression = (Expression<Func<ApplicationUser, bool>>)visitor.Visit(predicate);
        return await _context.Users.Where(newExpression).Skip((page - 1) * pageSize).Take(pageSize).Select(x => new User(x.UserName, x.Email, x.PasswordHash)).ToListAsync();
    }


    public async Task<User> UpdateAsync(User entity)
    {
        var user = await _userManager.FindByIdAsync(entity.Id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        user.UserName = entity.UserName;
        user.Email = entity.Email;
        await _userManager.UpdateAsync(user);
        return new User(user.UserName, user.Email, user.PasswordHash);
    }
}

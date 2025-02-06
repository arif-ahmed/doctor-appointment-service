using System.Linq.Expressions;
using DoctorAppointmentService.Domain.Entities;
using DoctorAppointmentService.Infrastructure.Models;


namespace DoctorAppointmentService.Infrastructure.Services;

public class UserToApplicationUserExpressionVisitor : ExpressionVisitor
{
    protected override Expression VisitParameter(ParameterExpression node)
    {
        // Replace the parameter of type User with ApplicationUser
        if (node.Type == typeof(User))
        {
            return Expression.Parameter(typeof(ApplicationUser), node.Name);
        }
        return base.VisitParameter(node);
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        // Replace the member access of User with ApplicationUser
        if (node.Member.DeclaringType == typeof(User))
        {
            var newExpression = Visit(node.Expression);
            var newMember = typeof(ApplicationUser).GetMember(node.Member.Name).FirstOrDefault();
            if (newMember != null)
            {
                return Expression.MakeMemberAccess(newExpression, newMember);
            }
        }
        return base.VisitMember(node);
    }
}
    

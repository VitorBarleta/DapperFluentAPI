using DapperFluentAPI.Infrastructure.Internal.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace DapperFluentAPI.Infrastructure.Internal.Common
{
    public class Checker
    {
        public static PropertyInfo GetMemberFromExpression([AllowNull] MemberExpression memberExpression)
        {
            var member = memberExpression ??
                throw new MemberNotValidException(memberExpression);
            return member.Member as PropertyInfo ??
                throw new MemberNotValidException(member);
        }
    }
}

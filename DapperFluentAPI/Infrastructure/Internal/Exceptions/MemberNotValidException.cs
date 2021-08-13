using System;
using System.Linq.Expressions;

namespace DapperFluentAPI.Infrastructure.Internal.Exceptions
{
    public class MemberNotValidException : Exception
    {
        private static readonly string _message = "The member \"{0}\" is not valid!";

        public MemberNotValidException(Expression body)
            : base(string.Format(_message, body))
        { }

        public MemberNotValidException(string member)
            : base(string.Format(_message, member))
        { }
    }
}

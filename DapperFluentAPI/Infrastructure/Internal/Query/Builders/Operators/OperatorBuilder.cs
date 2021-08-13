using DapperFluentAPI.Infrastructure.Internal.Query.Enums;

namespace DapperFluentAPI.Infrastructure.Internal.Query.Builders.Operators
{
    public static class OperatorBuilder
    {
        public const string FilterTemplate = "{0} {1} {2}";
        public const string SimpleFilterTemplate = "{0} {1}";

        public const string NotEqualOp = "<>";
        public const string EqualOp = "=";
        public const string LikeOp = "LIKE";
        public const string GreaterThanOp = ">";
        public const string LessThanOp = "<";
        public const string GreaterThanOrEqualOp = ">=";
        public const string LessThanOrEqualOp = "<=";
        public const string IsNullOp = "IS NULL";
        public const string IsNotNullOp = "IS NOT NULL";

        private static readonly int[] _simpleOp = new int[3] { (int)Operator.Like, (int)Operator.IsNull, (int)Operator.IsNotNull };

        public static bool GetIsSimpleFilter(Operator @operator)
        {
            for (var i = 0; i < _simpleOp.Length; i++)
            {
                if (_simpleOp[i] == (int)@operator) return true;
            }
            return false;
        }

        public static string GetOperatorString(Operator @operator)
        {
            return @operator switch
            {
                Operator.Equal => EqualOp,
                Operator.NotEqual => NotEqualOp,
                Operator.Like => LikeOp,
                Operator.GreaterThan => GreaterThanOp,
                Operator.LessThan => LessThanOp,
                Operator.GreaterThanOrEqual => GreaterThanOrEqualOp,
                Operator.LessThanOrEqual => LessThanOrEqualOp,
                Operator.IsNull => IsNullOp,
                Operator.IsNotNull => IsNotNullOp,
                _ => throw new System.Exception(),
            };
        }

    }
}

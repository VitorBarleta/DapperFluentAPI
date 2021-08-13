namespace DapperFluentAPI.Infrastructure.Internal.Query
{
    public abstract class FluentQuery
    {
        public const string SizeParamName = "@size";
        public const string OffsetParamName = "@offset";

        public const string BaseTemplate = "SELECT {0} FROM {1}.{2} /**where**/ /**orderby**/";
        public const string PaginationComplementTemplate = " OFFSET " + OffsetParamName + " ROWS FETCH NEXT " + SizeParamName + " ROWS ONLY";
    }
}

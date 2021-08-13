namespace DapperFluentAPI.Infrastructure.Internal.Common
{
    public static class Param
    {
        public const string ParamFormat = "@Param{0}";

        public static string Get(int paramNumber) =>
            string.Format(ParamFormat, paramNumber);
    }
}

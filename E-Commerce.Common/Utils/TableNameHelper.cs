namespace E_Commerce.Common.Utils
{
    public class TableNameHelper
    {
        public static string Format(string prefix, string entityName)
        {
            return $"{prefix}.{entityName}s";
        }
    }
}

namespace E_Commerce.Shared
{
    public static class GlobalUtils
    {
        public static string FormatTableName(string prefix, string entityName)
        {
            return $"{prefix}.{entityName}s";
        }
    }
}

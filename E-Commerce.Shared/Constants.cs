namespace E_Commerce.Shared
{
    public static class Constants
    {
        public const string PREFIX_CONTROL_ACCESS = "ControlAccess";
        public const string PREFIX_PRODUCT = "Product";
        public const string PREFIX_PURCHARSE = "Purcharse";
        public const string PREFIX_PAYMENT = "Payment";

        public const short PRICE_PRECISION = 18;
        public const short PRICE_SCALE = 2;

        public const string DESC_SORT_ORDER = "desc";
        public const string ASC_SORT_ORDER = "asc";

        public const string API_PREFIX_FIRST_VERSION = "v1/api";

        public const string MIGRATIONS_HISTORY_TABLE_NAME = "MigrationsHistory";
        public const string PREFIX_SYSTEM = "System";

        public const string ADMIN = "Admin";
        public const string USER = "User";

        public const string NOT_LOGGED_USER = "User not identified, please login first";

        public const string FORBIDDEN_DEFAULT_MESSAGE = "{\"message\": \"User is not authorized to access this resource.\"}";
    }
}

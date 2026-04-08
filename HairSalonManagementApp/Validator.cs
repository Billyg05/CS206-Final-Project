namespace HairSalonManagementApp
{
    internal static class Validator
    {
        public static bool IsPresent(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsDecimal(string value)
        {
            return decimal.TryParse(value, out _);
        }
    }
}

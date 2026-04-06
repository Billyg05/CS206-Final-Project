namespace HairSalonManagementApp
{
    internal static class Validator
    {
        public static bool IsPresent(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}

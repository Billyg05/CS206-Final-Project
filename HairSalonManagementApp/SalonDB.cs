namespace HairSalonManagementApp
{
    internal static class SalonDB
    {
        public static List<Customer> Customers { get; } = new();
        public static List<Service> Services { get; } = new();
        public static List<Stylist> Stylists { get; } = new();
        public static List<Appointment> Appointments { get; } = new();
    }
}

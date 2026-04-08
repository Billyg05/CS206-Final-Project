using System.Globalization;

namespace HairSalonManagementApp
{
    internal static class SalonDB
    {
        private static readonly string DataFolder = Path.Combine(AppContext.BaseDirectory, "DataFiles");
        private static readonly string CustomerFile = Path.Combine(DataFolder, "customers.txt");
        private static readonly string ServiceFile = Path.Combine(DataFolder, "services.txt");
        private static readonly string StylistFile = Path.Combine(DataFolder, "stylists.txt");
        private static readonly string AppointmentFile = Path.Combine(DataFolder, "appointments.txt");
        private static bool _isInitialized;

        public static List<Customer> Customers { get; } = new();
        public static List<Service> Services { get; } = new();
        public static List<Stylist> Stylists { get; } = new();
        public static List<Appointment> Appointments { get; } = new();

        public static void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }

            Directory.CreateDirectory(DataFolder);

            LoadCustomers();
            LoadServices();
            LoadStylists();
            LoadAppointments();
            SeedDefaults();

            _isInitialized = true;
        }

        public static int GetNextCustomerId()
        {
            return Customers.Count == 0 ? 1001 : Customers.Max(c => c.CustomerId) + 1;
        }

        public static int GetNextServiceId()
        {
            return Services.Count == 0 ? 2001 : Services.Max(s => s.ServiceId) + 1;
        }

        public static int GetNextStylistId()
        {
            return Stylists.Count == 0 ? 3001 : Stylists.Max(s => s.StylistId) + 1;
        }

        public static int GetNextAppointmentId()
        {
            return Appointments.Count == 0 ? 4001 : Appointments.Max(a => a.AppointmentId) + 1;
        }

        public static Customer FindOrCreateCustomer(string fullName, string phoneNumber)
        {
            Customer? customer = Customers.FirstOrDefault(c =>
                string.Equals(c.FullName, fullName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(c.PhoneNumber, phoneNumber, StringComparison.OrdinalIgnoreCase));

            if (customer != null)
            {
                return customer;
            }

            customer = new Customer(GetNextCustomerId(), fullName, phoneNumber, string.Empty, string.Empty);
            Customers.Add(customer);
            SaveCustomers();
            return customer;
        }

        public static void SaveCustomer(Customer customer)
        {
            Customer? existingCustomer = Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);

            if (existingCustomer == null)
            {
                customer.CustomerId = GetNextCustomerId();
                Customers.Add(customer);
            }
            else
            {
                existingCustomer.FullName = customer.FullName;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Email = customer.Email;
                existingCustomer.Notes = customer.Notes;
            }

            SaveCustomers();
        }

        public static void SaveService(Service service)
        {
            Service? existingService = Services.FirstOrDefault(s => s.ServiceId == service.ServiceId);

            if (existingService == null)
            {
                service.ServiceId = GetNextServiceId();
                Services.Add(service);
            }
            else
            {
                existingService.ServiceName = service.ServiceName;
                existingService.Price = service.Price;
                existingService.Category = service.Category;
            }

            SaveServices();
        }

        public static void SaveAppointment(Appointment appointment)
        {
            Appointment? existingAppointment = Appointments.FirstOrDefault(a => a.AppointmentId == appointment.AppointmentId);

            if (existingAppointment == null)
            {
                appointment.AppointmentId = GetNextAppointmentId();
                Appointments.Add(appointment);
            }
            else
            {
                existingAppointment.CustomerId = appointment.CustomerId;
                existingAppointment.ServiceId = appointment.ServiceId;
                existingAppointment.StylistId = appointment.StylistId;
                existingAppointment.AppointmentDate = appointment.AppointmentDate;
                existingAppointment.Status = appointment.Status;
                existingAppointment.TotalCost = appointment.TotalCost;
                existingAppointment.Notes = appointment.Notes;
            }

            SaveAppointments();
        }

        public static void DeleteAppointment(int appointmentId)
        {
            Appointment? appointment = Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);

            if (appointment != null)
            {
                Appointments.Remove(appointment);
                SaveAppointments();
            }
        }

        public static Appointment? GetAppointmentById(int appointmentId)
        {
            return Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
        }

        public static List<Appointment> SearchAppointments(string searchText, string serviceText, DateTime? filterDate)
        {
            IEnumerable<Appointment> query = Appointments.OrderBy(a => a.AppointmentDate);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string search = searchText.Trim().ToLower();
                query = query.Where(a =>
                    GetCustomerName(a.CustomerId).ToLower().Contains(search) ||
                    GetServiceName(a.ServiceId).ToLower().Contains(search) ||
                    GetStylistName(a.StylistId).ToLower().Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(serviceText))
            {
                string service = serviceText.Trim().ToLower();
                query = query.Where(a => GetServiceName(a.ServiceId).ToLower().Contains(service));
            }

            if (filterDate.HasValue)
            {
                DateTime selectedDate = filterDate.Value.Date;
                query = query.Where(a => a.AppointmentDate.Date == selectedDate);
            }

            return query.ToList();
        }

        public static string GetCustomerName(int customerId)
        {
            Customer? customer = Customers.FirstOrDefault(c => c.CustomerId == customerId);
            return customer == null ? string.Empty : customer.FullName;
        }

        public static string GetServiceName(int serviceId)
        {
            Service? service = Services.FirstOrDefault(s => s.ServiceId == serviceId);
            return service == null ? string.Empty : service.ServiceName;
        }

        public static string GetStylistName(int stylistId)
        {
            Stylist? stylist = Stylists.FirstOrDefault(s => s.StylistId == stylistId);
            return stylist == null ? string.Empty : stylist.Name;
        }

        public static int GetTodayAppointmentCount()
        {
            return Appointments.Count(a => a.AppointmentDate.Date == DateTime.Today);
        }

        public static decimal GetTotalRevenue()
        {
            return Appointments.Sum(a => a.TotalCost);
        }

        public static string GetTopServiceName()
        {
            var topService = Appointments
                .GroupBy(a => a.ServiceId)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            return topService == null ? "N/A" : GetServiceName(topService.Key);
        }

        public static List<string> GetReportLines()
        {
            return Services
                .Select(service => new
                {
                    service.ServiceName,
                    Count = Appointments.Count(a => a.ServiceId == service.ServiceId)
                })
                .OrderByDescending(item => item.Count)
                .Select(item => item.ServiceName + ": " + item.Count.ToString())
                .ToList();
        }

        private static void SeedDefaults()
        {
            if (Services.Count == 0)
            {
                Services.Add(new Service(GetNextServiceId(), "Haircut", 25.00m, "Cut"));
                Services.Add(new Service(GetNextServiceId(), "Color", 55.00m, "Color"));
                Services.Add(new Service(GetNextServiceId(), "Shampoo and Style", 30.00m, "Style"));
                SaveServices();
            }

            if (Stylists.Count == 0)
            {
                Stylists.Add(new Stylist(GetNextStylistId(), "Taylor", "Cuts", true));
                Stylists.Add(new Stylist(GetNextStylistId(), "Jordan", "Color", true));
                Stylists.Add(new Stylist(GetNextStylistId(), "Alex", "Style", true));
                SaveStylists();
            }
        }

        private static void LoadCustomers()
        {
            Customers.Clear();

            if (!File.Exists(CustomerFile))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(CustomerFile))
            {
                string[] parts = line.Split('\t');
                if (parts.Length >= 5)
                {
                    Customers.Add(new Customer(
                        int.Parse(parts[0]),
                        Unescape(parts[1]),
                        Unescape(parts[2]),
                        Unescape(parts[3]),
                        Unescape(parts[4])));
                }
            }
        }

        private static void LoadServices()
        {
            Services.Clear();

            if (!File.Exists(ServiceFile))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(ServiceFile))
            {
                string[] parts = line.Split('\t');
                if (parts.Length >= 4)
                {
                    Services.Add(new Service(
                        int.Parse(parts[0]),
                        Unescape(parts[1]),
                        decimal.Parse(parts[2], CultureInfo.InvariantCulture),
                        Unescape(parts[3])));
                }
            }
        }

        private static void LoadStylists()
        {
            Stylists.Clear();

            if (!File.Exists(StylistFile))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(StylistFile))
            {
                string[] parts = line.Split('\t');
                if (parts.Length >= 4)
                {
                    Stylists.Add(new Stylist(
                        int.Parse(parts[0]),
                        Unescape(parts[1]),
                        Unescape(parts[2]),
                        bool.Parse(parts[3])));
                }
            }
        }

        private static void LoadAppointments()
        {
            Appointments.Clear();

            if (!File.Exists(AppointmentFile))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(AppointmentFile))
            {
                string[] parts = line.Split('\t');
                if (parts.Length >= 8)
                {
                    Appointments.Add(new Appointment(
                        int.Parse(parts[0]),
                        int.Parse(parts[1]),
                        int.Parse(parts[2]),
                        int.Parse(parts[3]),
                        DateTime.Parse(parts[4], CultureInfo.InvariantCulture),
                        Unescape(parts[5]),
                        decimal.Parse(parts[6], CultureInfo.InvariantCulture),
                        Unescape(parts[7])));
                }
            }
        }

        private static void SaveCustomers()
        {
            File.WriteAllLines(CustomerFile, Customers.Select(c =>
                c.CustomerId + "\t" +
                Escape(c.FullName) + "\t" +
                Escape(c.PhoneNumber) + "\t" +
                Escape(c.Email) + "\t" +
                Escape(c.Notes)));
        }

        private static void SaveServices()
        {
            File.WriteAllLines(ServiceFile, Services.Select(s =>
                s.ServiceId + "\t" +
                Escape(s.ServiceName) + "\t" +
                s.Price.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(s.Category)));
        }

        private static void SaveStylists()
        {
            File.WriteAllLines(StylistFile, Stylists.Select(s =>
                s.StylistId + "\t" +
                Escape(s.Name) + "\t" +
                Escape(s.Specialty) + "\t" +
                s.IsActive.ToString()));
        }

        private static void SaveAppointments()
        {
            File.WriteAllLines(AppointmentFile, Appointments.Select(a =>
                a.AppointmentId + "\t" +
                a.CustomerId + "\t" +
                a.ServiceId + "\t" +
                a.StylistId + "\t" +
                a.AppointmentDate.ToString("o", CultureInfo.InvariantCulture) + "\t" +
                Escape(a.Status) + "\t" +
                a.TotalCost.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(a.Notes)));
        }

        private static string Escape(string value)
        {
            return value.Replace("\t", " ").Replace("\r", " ").Replace("\n", " ");
        }

        private static string Unescape(string value)
        {
            return value;
        }
    }
}

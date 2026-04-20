using System.Globalization;
using System.Security.Cryptography;

namespace HairSalonManagementApp
{
    internal static class SalonDB
    {
        private static readonly string DataFolder = Path.Combine(AppContext.BaseDirectory, "DataFiles");
        private static readonly string EmployeeFile = Path.Combine(DataFolder, "employees.txt");
        private static readonly string CustomerFile = Path.Combine(DataFolder, "customers.txt");
        private static readonly string ServiceFile = Path.Combine(DataFolder, "services.txt");
        private static readonly string StylistFile = Path.Combine(DataFolder, "stylists.txt");
        private static readonly string AppointmentFile = Path.Combine(DataFolder, "appointments.txt");
        private static bool _isInitialized;

        public static List<Employee> Employees { get; } = new();
        public static List<Customer> Customers { get; } = new();
        public static List<Service> Services { get; } = new();
        public static List<Stylist> Stylists { get; } = new();
        public static List<Appointment> Appointments { get; } = new();

        // init data
        public static void Initialize()
        {
            if (_isInitialized)
            {
                return;
            }

            Directory.CreateDirectory(DataFolder);

            LoadEmployees();
            LoadCustomers();
            LoadServices();
            LoadStylists();
            LoadAppointments();
            SeedDefaults();

            _isInitialized = true;
        }

        // next customer id
        public static int GetNextCustomerId()
        {
            return Customers.Count == 0 ? 1001 : Customers.Max(c => c.CustomerId) + 1;
        }

        // next employee id
        public static int GetNextEmployeeId()
        {
            return Employees.Count == 0 ? 501 : Employees.Max(e => e.EmployeeId) + 1;
        }

        // next service id
        public static int GetNextServiceId()
        {
            return Services.Count == 0 ? 2001 : Services.Max(s => s.ServiceId) + 1;
        }

        // next stylist id
        public static int GetNextStylistId()
        {
            return Stylists.Count == 0 ? 3001 : Stylists.Max(s => s.StylistId) + 1;
        }

        // next appointment id
        public static int GetNextAppointmentId()
        {
            return Appointments.Count == 0 ? 4001 : Appointments.Max(a => a.AppointmentId) + 1;
        }

        // customer lookup
        public static Customer? GetCustomerById(int customerId)
        {
            return Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        // employee lookup
        public static Employee? GetEmployeeByUsername(string username)
        {
            return Employees.FirstOrDefault(e =>
                e.IsActive &&
                string.Equals(e.Username, username.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // service lookup
        public static Service? GetServiceById(int serviceId)
        {
            return Services.FirstOrDefault(s => s.ServiceId == serviceId);
        }

        // stylist lookup
        public static Stylist? GetStylistById(int stylistId)
        {
            return Stylists.FirstOrDefault(s => s.StylistId == stylistId);
        }

        // customer list
        public static List<Customer> GetCustomersForSelection()
        {
            return Customers
                .OrderBy(c => c.FullName)
                .ThenBy(c => c.PhoneNumber)
                .ToList();
        }

        // service list
        public static List<Service> GetServicesForSelection()
        {
            return Services
                .OrderBy(s => s.Category)
                .ThenBy(s => s.ServiceName)
                .ToList();
        }

        // active stylists
        public static List<Stylist> GetActiveStylists()
        {
            return Stylists
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name)
                .ToList();
        }

        // save customer
        public static void SaveCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new InvalidOperationException("Customer data is missing.");
            }

            bool duplicateCustomer = Customers.Any(c =>
                c.CustomerId != customer.CustomerId &&
                NormalizeKey(c.FullName) == NormalizeKey(customer.FullName) &&
                NormalizePhone(c.PhoneNumber) == NormalizePhone(customer.PhoneNumber));

            if (duplicateCustomer)
            {
                throw new InvalidOperationException("A customer with the same name and phone number already exists.");
            }

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

        // save employee
        public static void SaveEmployee(Employee employee, string plainTextPassword)
        {
            if (employee == null)
            {
                throw new InvalidOperationException("Employee data is missing.");
            }

            bool duplicateUsername = Employees.Any(e =>
                e.EmployeeId != employee.EmployeeId &&
                string.Equals(e.Username, employee.Username, StringComparison.OrdinalIgnoreCase));

            if (duplicateUsername)
            {
                throw new InvalidOperationException("That username is already in use.");
            }

            string salt = CreateSalt();
            string hash = HashPassword(plainTextPassword, salt);

            Employee? existingEmployee = Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (existingEmployee == null)
            {
                employee.EmployeeId = GetNextEmployeeId();
                employee.PasswordSalt = salt;
                employee.PasswordHash = hash;
                employee.IsActive = true;
                Employees.Add(employee);
            }
            else
            {
                existingEmployee.FullName = employee.FullName;
                existingEmployee.Username = employee.Username;
                existingEmployee.PasswordSalt = salt;
                existingEmployee.PasswordHash = hash;
                existingEmployee.IsActive = employee.IsActive;
            }

            SaveEmployees();
        }

        // check login
        public static Employee? AuthenticateEmployee(string username, string password)
        {
            Employee? employee = GetEmployeeByUsername(username);

            if (employee == null)
            {
                return null;
            }

            try
            {
                string hash = HashPassword(password, employee.PasswordSalt);
                byte[] providedHash = Convert.FromBase64String(hash);
                byte[] storedHash = Convert.FromBase64String(employee.PasswordHash);

                // fixed time compare
                return CryptographicOperations.FixedTimeEquals(providedHash, storedHash) ? employee : null;
            }
            catch
            {
                return null;
            }
        }

        // save appointment
        public static void SaveAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new InvalidOperationException("Appointment data is missing.");
            }

            if (GetCustomerById(appointment.CustomerId) == null)
            {
                throw new InvalidOperationException("Select a valid customer.");
            }

            if (GetServiceById(appointment.ServiceId) == null)
            {
                throw new InvalidOperationException("Select a valid service.");
            }

            if (GetStylistById(appointment.StylistId) == null)
            {
                throw new InvalidOperationException("Select a valid stylist.");
            }

            bool stylistConflict = Appointments.Any(a =>
                a.AppointmentId != appointment.AppointmentId &&
                a.StylistId == appointment.StylistId &&
                a.AppointmentDate == appointment.AppointmentDate);

            if (stylistConflict)
            {
                throw new InvalidOperationException("That stylist already has an appointment at the selected date and time.");
            }

            bool customerConflict = Appointments.Any(a =>
                a.AppointmentId != appointment.AppointmentId &&
                a.CustomerId == appointment.CustomerId &&
                a.AppointmentDate == appointment.AppointmentDate);

            if (customerConflict)
            {
                throw new InvalidOperationException("That customer already has an appointment at the selected date and time.");
            }

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

        // delete appointment
        public static void DeleteAppointment(int appointmentId)
        {
            Appointment? appointment = Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);

            if (appointment != null)
            {
                Appointments.Remove(appointment);
                SaveAppointments();
            }
        }

        // appointment lookup
        public static Appointment? GetAppointmentById(int appointmentId)
        {
            return Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
        }

        // search appointments
        public static List<Appointment> SearchAppointments(string searchText, int? serviceId, DateTime? filterDate)
        {
            IEnumerable<Appointment> query = Appointments.OrderBy(a => a.AppointmentDate);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                string search = searchText.Trim().ToLowerInvariant();
                query = query.Where(a =>
                    a.AppointmentId.ToString().Contains(search) ||
                    GetCustomerName(a.CustomerId).ToLowerInvariant().Contains(search) ||
                    GetServiceName(a.ServiceId).ToLowerInvariant().Contains(search) ||
                    GetStylistName(a.StylistId).ToLowerInvariant().Contains(search));
            }

            if (serviceId.HasValue)
            {
                query = query.Where(a => a.ServiceId == serviceId.Value);
            }

            if (filterDate.HasValue)
            {
                DateTime selectedDate = filterDate.Value.Date;
                query = query.Where(a => a.AppointmentDate.Date == selectedDate);
            }

            return query.ToList();
        }

        // customer name
        public static string GetCustomerName(int customerId)
        {
            Customer? customer = GetCustomerById(customerId);
            return customer == null ? string.Empty : customer.FullName;
        }

        // service name
        public static string GetServiceName(int serviceId)
        {
            Service? service = GetServiceById(serviceId);
            return service == null ? string.Empty : service.ServiceName;
        }

        // stylist name
        public static string GetStylistName(int stylistId)
        {
            Stylist? stylist = GetStylistById(stylistId);
            return stylist == null ? string.Empty : stylist.Name;
        }

        // today count
        public static int GetTodayAppointmentCount()
        {
            return Appointments.Count(a => a.AppointmentDate.Date == DateTime.Today);
        }

        // total revenue
        public static decimal GetTotalRevenue()
        {
            return Appointments.Sum(a => a.TotalCost);
        }

        // top service
        public static string GetTopServiceName()
        {
            var topService = Appointments
                .GroupBy(a => a.ServiceId)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            return topService == null ? "N/A" : GetServiceName(topService.Key);
        }

        // report lines
        public static List<string> GetReportLines()
        {
            return Services
                .Select(service => new
                {
                    service.ServiceName,
                    Count = Appointments.Count(a => a.ServiceId == service.ServiceId)
                })
                .OrderByDescending(item => item.Count)
                .ThenBy(item => item.ServiceName)
                .Select(item => item.ServiceName + ": " + item.Count.ToString())
                .ToList();
        }

        // seed defaults
        private static void SeedDefaults()
        {
            if (Employees.Count == 0)
            {
                string adminSalt = CreateSalt();
                string adminHash = HashPassword("Salon123", adminSalt);

                Employees.Add(new Employee(GetNextEmployeeId(), "Administrator", "admin", adminSalt, adminHash, true));
                SaveEmployees();
            }

            if (Services.Count == 0)
            {
                Services.Add(new Service(GetNextServiceId(), "Haircut", 25.00m, "Cut", "Basic haircut"));
                Services.Add(new Service(GetNextServiceId(), "Beard Trim", 18.00m, "Cut", "Basic beard trim"));
                Services.Add(new Service(GetNextServiceId(), "Color", 55.00m, "Color", "Single process color"));
                Services.Add(new Service(GetNextServiceId(), "Shampoo and Style", 30.00m, "Style", "Wash and style"));
                SaveServices();
            }

            if (Stylists.Count == 0)
            {
                Stylists.Add(new Stylist(GetNextStylistId(), "Taylor", "Cuts", true));
                Stylists.Add(new Stylist(GetNextStylistId(), "Jordan", "Color", true));
                Stylists.Add(new Stylist(GetNextStylistId(), "Alex", "Style", true));
                SaveStylists();
            }

            if (Customers.Count == 0)
            {
                Customers.Add(new Customer(GetNextCustomerId(), "Timmy", "(555) 123-4567", "timmy@example.com", string.Empty));
                Customers.Add(new Customer(GetNextCustomerId(), "Jimmy", "(555) 987-6543", "jimmy@example.com", string.Empty));
                SaveCustomers();
            }

            if (Appointments.Count == 0 && Customers.Count > 0 && Services.Count > 0 && Stylists.Count > 0)
            {
                Service haircutService = Services.First(s => s.ServiceName == "Haircut");
                Service colorService = Services.First(s => s.ServiceName == "Color");
                Stylist taylor = Stylists.First(s => s.Name == "Taylor");
                Stylist jordan = Stylists.First(s => s.Name == "Jordan");

                Appointments.Add(new Appointment(
                    GetNextAppointmentId(),
                    Customers[0].CustomerId,
                    haircutService.ServiceId,
                    taylor.StylistId,
                    DateTime.Today.AddDays(1).AddHours(10),
                    "Scheduled",
                    haircutService.Price,
                    string.Empty));

                Appointments.Add(new Appointment(
                    GetNextAppointmentId(),
                    Customers[1].CustomerId,
                    colorService.ServiceId,
                    jordan.StylistId,
                    DateTime.Today.AddDays(2).AddHours(14),
                    "Scheduled",
                    colorService.Price,
                    string.Empty));

                SaveAppointments();
            }
        }

        // load employees
        private static void LoadEmployees()
        {
            Employees.Clear();

            if (!File.Exists(EmployeeFile))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(EmployeeFile))
            {
                try
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 6)
                    {
                        Employees.Add(new Employee(
                            int.Parse(parts[0], CultureInfo.InvariantCulture),
                            Unescape(parts[1]),
                            Unescape(parts[2]),
                            Unescape(parts[3]),
                            Unescape(parts[4]),
                            bool.Parse(parts[5])));
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        // load customers
        private static void LoadCustomers()
        {
            Customers.Clear();

            if (!File.Exists(CustomerFile))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(CustomerFile))
            {
                try
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 5)
                    {
                        Customers.Add(new Customer(
                            int.Parse(parts[0], CultureInfo.InvariantCulture),
                            Unescape(parts[1]),
                            Unescape(parts[2]),
                            Unescape(parts[3]),
                            Unescape(parts[4])));
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        // load services
        private static void LoadServices()
        {
            Services.Clear();

            if (!File.Exists(ServiceFile))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(ServiceFile))
            {
                try
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 4)
                    {
                        Services.Add(new Service(
                            int.Parse(parts[0], CultureInfo.InvariantCulture),
                            Unescape(parts[1]),
                            decimal.Parse(parts[2], CultureInfo.InvariantCulture),
                            Unescape(parts[3]),
                            parts.Length >= 5 ? Unescape(parts[4]) : string.Empty));
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        // load stylists
        private static void LoadStylists()
        {
            Stylists.Clear();

            if (!File.Exists(StylistFile))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(StylistFile))
            {
                try
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 4)
                    {
                        Stylists.Add(new Stylist(
                            int.Parse(parts[0], CultureInfo.InvariantCulture),
                            Unescape(parts[1]),
                            Unescape(parts[2]),
                            bool.Parse(parts[3])));
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        // load appointments
        private static void LoadAppointments()
        {
            Appointments.Clear();

            if (!File.Exists(AppointmentFile))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(AppointmentFile))
            {
                try
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length >= 8)
                    {
                        Appointments.Add(new Appointment(
                            int.Parse(parts[0], CultureInfo.InvariantCulture),
                            int.Parse(parts[1], CultureInfo.InvariantCulture),
                            int.Parse(parts[2], CultureInfo.InvariantCulture),
                            int.Parse(parts[3], CultureInfo.InvariantCulture),
                            DateTime.Parse(parts[4], CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                            Unescape(parts[5]),
                            decimal.Parse(parts[6], CultureInfo.InvariantCulture),
                            Unescape(parts[7])));
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        // save customers
        private static void SaveCustomers()
        {
            File.WriteAllLines(CustomerFile, Customers.Select(c =>
                c.CustomerId.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(c.FullName) + "\t" +
                Escape(c.PhoneNumber) + "\t" +
                Escape(c.Email) + "\t" +
                Escape(c.Notes)));
        }

        // save employees
        private static void SaveEmployees()
        {
            File.WriteAllLines(EmployeeFile, Employees.Select(e =>
                e.EmployeeId.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(e.FullName) + "\t" +
                Escape(e.Username) + "\t" +
                Escape(e.PasswordSalt) + "\t" +
                Escape(e.PasswordHash) + "\t" +
                e.IsActive.ToString()));
        }

        // save services
        private static void SaveServices()
        {
            File.WriteAllLines(ServiceFile, Services.Select(s =>
                s.ServiceId.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(s.ServiceName) + "\t" +
                s.Price.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(s.Category) + "\t" +
                Escape(s.Description)));
        }

        // save stylists
        private static void SaveStylists()
        {
            File.WriteAllLines(StylistFile, Stylists.Select(s =>
                s.StylistId.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(s.Name) + "\t" +
                Escape(s.Specialty) + "\t" +
                s.IsActive.ToString()));
        }

        // save appointments
        private static void SaveAppointments()
        {
            File.WriteAllLines(AppointmentFile, Appointments.Select(a =>
                a.AppointmentId.ToString(CultureInfo.InvariantCulture) + "\t" +
                a.CustomerId.ToString(CultureInfo.InvariantCulture) + "\t" +
                a.ServiceId.ToString(CultureInfo.InvariantCulture) + "\t" +
                a.StylistId.ToString(CultureInfo.InvariantCulture) + "\t" +
                a.AppointmentDate.ToString("o", CultureInfo.InvariantCulture) + "\t" +
                Escape(a.Status) + "\t" +
                a.TotalCost.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(a.Notes)));
        }

        // escape text
        private static string Escape(string value)
        {
            return value.Replace("\t", " ").Replace("\r", " ").Replace("\n", " ");
        }

        // unescape text
        private static string Unescape(string value)
        {
            return value;
        }

        // normalize text
        private static string NormalizeKey(string value)
        {
            return value.Trim().ToUpperInvariant();
        }

        // normalize phone
        private static string NormalizePhone(string value)
        {
            return new string(value.Where(char.IsDigit).ToArray());
        }

        // create salt
        private static string CreateSalt()
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
            return Convert.ToBase64String(saltBytes);
        }

        // hash password
        private static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] hashBytes = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, 100000, HashAlgorithmName.SHA256, 32);
            return Convert.ToBase64String(hashBytes);
        }
    }
}

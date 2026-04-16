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
        public static string[] ServiceCategories { get; } = new[] { "Cut", "Color", "Style", "Treatment", "Other" };

        // startup load; reads lists and seeds defaults
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

        // Generate customer ID
        public static int GetNextCustomerId()
        {
            return Customers.Count == 0 ? 1001 : Customers.Max(c => c.CustomerId) + 1;
        }

        // Generateemployee ID
        public static int GetNextEmployeeId()
        {
            return Employees.Count == 0 ? 501 : Employees.Max(e => e.EmployeeId) + 1;
        }

        // Generate service ID
        public static int GetNextServiceId()
        {
            return Services.Count == 0 ? 2001 : Services.Max(s => s.ServiceId) + 1;
        }

        // Generate stylist ID
        public static int GetNextStylistId()
        {
            return Stylists.Count == 0 ? 3001 : Stylists.Max(s => s.StylistId) + 1;
        }

        // Generate appointment ID
        public static int GetNextAppointmentId()
        {
            return Appointments.Count == 0 ? 4001 : Appointments.Max(a => a.AppointmentId) + 1;
        }

        // Look up customer by ID.
        public static Customer? GetCustomerById(int customerId)
        {
            return Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        // Look up employee account by username for login.
        public static Employee? GetEmployeeByUsername(string username)
        {
            return Employees.FirstOrDefault(e =>
                e.IsActive &&
                string.Equals(e.Username, username.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // Look up service by ID.
        public static Service? GetServiceById(int serviceId)
        {
            return Services.FirstOrDefault(s => s.ServiceId == serviceId);
        }

        // Look up stylist by ID.
        public static Stylist? GetStylistById(int stylistId)
        {
            return Stylists.FirstOrDefault(s => s.StylistId == stylistId);
        }

        // Return customers for combo boxes.
        public static List<Customer> GetCustomersForSelection()
        {
            return Customers
                .OrderBy(c => c.FullName)
                .ThenBy(c => c.PhoneNumber)
                .ToList();
        }

        // Return services for combo boxes.
        public static List<Service> GetServicesForSelection()
        {
            return Services
                .OrderBy(s => s.Category)
                .ThenBy(s => s.ServiceName)
                .ToList();
        }

        // Return stylists for appointment booking.
        public static List<Stylist> GetActiveStylists()
        {
            return Stylists
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name)
                .ToList();
        }

        // Add a new customer or update an existing one, while blocking duplicates.
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

        // Add a new employee account and store only the salted password hash (no plain text password in files)
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

            // Each password gets salt so the same password will not hash to the same value (secure coding)
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

        // Add a new service or update an existing one, while blocking duplicate names
        public static void SaveService(Service service)
        {
            if (service == null)
            {
                throw new InvalidOperationException("Service data is missing.");
            }

            bool duplicateService = Services.Any(s =>
                s.ServiceId != service.ServiceId &&
                NormalizeKey(s.ServiceName) == NormalizeKey(service.ServiceName));

            if (duplicateService)
            {
                throw new InvalidOperationException("A service with the same name already exists.");
            }

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
                existingService.Description = service.Description;
            }

            SaveServices();
        }

        // Check password against salted hash
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

                // Security thing? 
                return CryptographicOperations.FixedTimeEquals(providedHash, storedHash) ? employee : null;
            }
            catch
            {
                return null;
            }
        }

        // Add a new or update appointment.
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

        // Remove appointment from list and save
        public static void DeleteAppointment(int appointmentId)
        {
            Appointment? appointment = Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);

            if (appointment != null)
            {
                Appointments.Remove(appointment);
                SaveAppointments();
            }
        }

        // Look up appointment by ID.
        public static Appointment? GetAppointmentById(int appointmentId)
        {
            return Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
        }

        // Search appointments by text and filters.
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

        // Get customer name from ID
        public static string GetCustomerName(int customerId)
        {
            Customer? customer = GetCustomerById(customerId);
            return customer == null ? string.Empty : customer.FullName;
        }

        // Get service name from ID
        public static string GetServiceName(int serviceId)
        {
            Service? service = GetServiceById(serviceId);
            return service == null ? string.Empty : service.ServiceName;
        }

        // Get stylist name from ID
        public static string GetStylistName(int stylistId)
        {
            Stylist? stylist = GetStylistById(stylistId);
            return stylist == null ? string.Empty : stylist.Name;
        }

        // Count today's appointments for the dashboard textbox
        public static int GetTodayAppointmentCount()
        {
            return Appointments.Count(a => a.AppointmentDate.Date == DateTime.Today);
        }

        // Add appointment prices for dashboard and reports
        public static decimal GetTotalRevenue()
        {
            return Appointments.Sum(a => a.TotalCost);
        }

        // Find most-booked service for report screen
        public static string GetTopServiceName()
        {
            var topService = Appointments
                .GroupBy(a => a.ServiceId)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            return topService == null ? "N/A" : GetServiceName(topService.Key);
        }

        // Build simple "service: count" lines for report list box
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

        // Seed the default login and starter data for first-time runs
        private static void SeedDefaults()
        {
            if (Employees.Count == 0)
            {
                // Seed admin account so the app has a first login (convenient but should be removed for security LOL)
                string salt = CreateSalt();
                string hash = HashPassword("Salon123", salt);
                Employees.Add(new Employee(GetNextEmployeeId(), "Administrator", "admin", salt, hash, true));
                SaveEmployees();
            }

            if (Services.Count == 0)
            {
                Services.Add(new Service(GetNextServiceId(), "Haircut", 25.00m, "Cut", "Basic haircut service."));
                Services.Add(new Service(GetNextServiceId(), "Color", 55.00m, "Color", "Single-process hair color."));
                Services.Add(new Service(GetNextServiceId(), "Shampoo and Style", 30.00m, "Style", "Wash and styling service."));
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

        // Load employee accounts from text file
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
                    // Skip bad lines so no crashes
                    continue;
                }
            }
        }

        // Load customers from text file
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

        // Load services from text file
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

        // Load stylists from file
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

        // Load appointments from file
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

        // Write full customer list to the customer file
        private static void SaveCustomers()
        {
            File.WriteAllLines(CustomerFile, Customers.Select(c =>
                c.CustomerId.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(c.FullName) + "\t" +
                Escape(c.PhoneNumber) + "\t" +
                Escape(c.Email) + "\t" +
                Escape(c.Notes)));
        }

        // Write full employee list back to employee file.
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

        // Write full service list back to service file.
        private static void SaveServices()
        {
            File.WriteAllLines(ServiceFile, Services.Select(s =>
                s.ServiceId.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(s.ServiceName) + "\t" +
                s.Price.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(s.Category) + "\t" +
                Escape(s.Description)));
        }

        // Write full stylist list back to stylist file.
        private static void SaveStylists()
        {
            File.WriteAllLines(StylistFile, Stylists.Select(s =>
                s.StylistId.ToString(CultureInfo.InvariantCulture) + "\t" +
                Escape(s.Name) + "\t" +
                Escape(s.Specialty) + "\t" +
                s.IsActive.ToString()));
        }

        // Write full appointment list back to appointment file.
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

        // Clean tabs and line breaks out of saved text fields so file parsing doesnt blow up
        private static string Escape(string value)
        {
            return value.Replace("\t", " ").Replace("\r", " ").Replace("\n", " ");
        }

        // unescape method kept for symmetry with Escape.
        private static string Unescape(string value)
        {
            return value;
        }

        // Normalize text for duplicate checks
        private static string NormalizeKey(string value)
        {
            return value.Trim().ToUpperInvariant();
        }

        // Normalize phone numbers for duplicate checks
        private static string NormalizePhone(string value)
        {
            return new string(value.Where(char.IsDigit).ToArray());
        }

        // Create a random salt for password hashing
        private static string CreateSalt()
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
            return Convert.ToBase64String(saltBytes);
        }

        // Hash the password with PBKDF2 so only hash is stored
        private static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] hashBytes = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, 100000, HashAlgorithmName.SHA256, 32);
            return Convert.ToBase64String(hashBytes);
        }
    }
}

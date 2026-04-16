namespace HairSalonManagementApp
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = "";
        public string Username { get; set; } = "";
        public string PasswordSalt { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public bool IsActive { get; set; }

        // Empty constructor for object initializers and file loading.
        public Employee()
        {
        }

        // Constructor used when a full employee record is loaded from storage.
        public Employee(int employeeId, string fullName, string username, string passwordSalt, string passwordHash, bool isActive)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Username = username;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            IsActive = isActive;
        }

        // Display text used if employee records are shown in lists later.
        public override string ToString()
        {
            return FullName + " (" + Username + ")";
        }
    }
}

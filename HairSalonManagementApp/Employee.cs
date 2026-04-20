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

        // blank ctor
        public Employee()
        {
        }

        // full ctor
        public Employee(int employeeId, string fullName, string username, string passwordSalt, string passwordHash, bool isActive)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Username = username;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            IsActive = isActive;
        }

        // list text
        public override string ToString()
        {
            return FullName + " (" + Username + ")";
        }
    }
}

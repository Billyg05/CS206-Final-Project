namespace HairSalonManagementApp
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string Notes { get; set; } = "";

        // Empty constructor for object initializers and file loading.
        public Customer()
        {
        }

        // Constructor used when a full customer record is loaded from storage.
        public Customer(int customerId, string fullName, string phoneNumber, string email, string notes)
        {
            CustomerId = customerId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Notes = notes;
        }

        // Display text used in customer drop-down lists.
        public override string ToString()
        {
            return FullName + " - " + PhoneNumber;
        }
    }
}

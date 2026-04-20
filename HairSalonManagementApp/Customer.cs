namespace HairSalonManagementApp
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string Notes { get; set; } = "";

        // blank ctor
        public Customer()
        {
        }

        // full ctor
        public Customer(int customerId, string fullName, string phoneNumber, string email, string notes)
        {
            CustomerId = customerId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            Notes = notes;
        }

        // list text
        public override string ToString()
        {
            return FullName + " - " + PhoneNumber;
        }
    }
}

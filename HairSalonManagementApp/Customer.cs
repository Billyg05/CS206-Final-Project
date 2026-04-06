namespace HairSalonManagementApp
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string Notes { get; set; } = "";

        public override string ToString()
        {
            return FullName;
        }
    }
}

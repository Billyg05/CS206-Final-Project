namespace HairSalonManagementApp
{
    internal class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = "";
        public decimal Price { get; set; }
        public string Category { get; set; } = "";

        public override string ToString()
        {
            return ServiceName;
        }
    }
}

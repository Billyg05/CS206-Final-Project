namespace HairSalonManagementApp
{
    internal class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = "";
        public decimal Price { get; set; }
        public string Category { get; set; } = "";

        public Service()
        {
        }

        public Service(int serviceId, string serviceName, decimal price, string category)
        {
            ServiceId = serviceId;
            ServiceName = serviceName;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return ServiceName;
        }
    }
}

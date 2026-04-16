namespace HairSalonManagementApp
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = "";
        public decimal Price { get; set; }
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";

        public Service()
        {
        }

        public Service(int serviceId, string serviceName, decimal price, string category, string description = "")
        {
            ServiceId = serviceId;
            ServiceName = serviceName;
            Price = price;
            Category = category;
            Description = description;
        }

        public override string ToString()
        {
            return ServiceName + " - " + Price.ToString("C");
        }
    }
}

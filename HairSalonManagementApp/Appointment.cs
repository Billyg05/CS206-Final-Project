namespace HairSalonManagementApp
{
    internal class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public int StylistId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "";
        public decimal TotalCost { get; set; }
        public string Notes { get; set; } = "";
    }
}

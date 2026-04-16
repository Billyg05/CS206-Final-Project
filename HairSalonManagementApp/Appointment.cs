namespace HairSalonManagementApp
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public int StylistId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "";
        public decimal TotalCost { get; set; }
        public string Notes { get; set; } = "";

        // Empty constructor for object initializers and file loading
        public Appointment()
        {
        }

        // Constructor used when a full appointment record is loaded from storage
        public Appointment(int appointmentId, int customerId, int serviceId, int stylistId, DateTime appointmentDate, string status, decimal totalCost, string notes)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            ServiceId = serviceId;
            StylistId = stylistId;
            AppointmentDate = appointmentDate;
            Status = status;
            TotalCost = totalCost;
            Notes = notes;
        }

        // Short display text for debugging or simple list output
        public override string ToString()
        {
            return "Appointment " + AppointmentId.ToString();
        }
    }
}

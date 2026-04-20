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

        // blank ctor
        public Appointment()
        {
        }

        // full ctor
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

        // list text
        public override string ToString()
        {
            return "Appointment " + AppointmentId.ToString();
        }
    }
}

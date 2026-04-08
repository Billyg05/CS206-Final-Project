namespace HairSalonManagementApp
{
    public class Stylist
    {
        public int StylistId { get; set; }
        public string Name { get; set; } = "";
        public string Specialty { get; set; } = "";
        public bool IsActive { get; set; }

        public Stylist()
        {
        }

        public Stylist(int stylistId, string name, string specialty, bool isActive)
        {
            StylistId = stylistId;
            Name = name;
            Specialty = specialty;
            IsActive = isActive;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

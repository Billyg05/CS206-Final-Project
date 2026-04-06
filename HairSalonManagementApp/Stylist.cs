namespace HairSalonManagementApp
{
    internal class Stylist
    {
        public int StylistId { get; set; }
        public string Name { get; set; } = "";
        public string Specialty { get; set; } = "";
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

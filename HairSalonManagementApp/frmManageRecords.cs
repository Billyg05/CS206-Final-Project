namespace HairSalonManagementApp
{
    public partial class frmManageRecords : Form
    {
        public frmManageRecords()
        {
            InitializeComponent();
            LoadSampleRow();
        }

        private void LoadSampleRow()
        {
            dgvAppointments.Rows.Add("1001", "Sample Customer", "Haircut", "Taylor", "04/15/2026", "$25.00");
        }
    }
}

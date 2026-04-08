namespace HairSalonManagementApp
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
            SalonDB.Initialize();
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
            LoadReportData();
        }

        private void LoadReportData()
        {
            lblCustomers.Text = SalonDB.Customers.Count.ToString();
            lblAppointments.Text = SalonDB.Appointments.Count.ToString();
            lblRevenue.Text = SalonDB.GetTotalRevenue().ToString("C");
            lblTopService.Text = SalonDB.GetTopServiceName();

            lstSummary.Items.Clear();

            foreach (string line in SalonDB.GetReportLines())
            {
                lstSummary.Items.Add(line);
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadReportData();
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

namespace HairSalonManagementApp
{
    public partial class frmReports : Form
    {
        // form setup
        public frmReports()
        {
            InitializeComponent();
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
            LoadReportData();
        }

        // load report
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

        // refresh click
        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadReportData();
        }

        // close click
        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

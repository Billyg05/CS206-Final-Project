namespace HairSalonManagementApp
{
    public partial class frmReports : Form
    {
        // Reports form setup: wire buttons and load the summary data right away.
        public frmReports()
        {
            InitializeComponent();
            SalonDB.Initialize();
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
            LoadReportData();
        }

        // Fill the report labels and list box with the latest totals.
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

        // Refresh button: reload the report values from storage.
        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadReportData();
        }

        // Close button: exit the reports form.
        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

namespace HairSalonManagementApp
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            SalonDB.Initialize();
            btnAddCustomer.Click += btnAddCustomer_Click;
            btnAddService.Click += btnAddService_Click;
            btnBookAppointment.Click += btnBookAppointment_Click;
            btnManageRecords.Click += btnManageRecords_Click;
            btnReports.Click += btnReports_Click;
            btnLogout.Click += btnLogout_Click;
            LoadSummary();
        }

        private void LoadSummary()
        {
            lblCustomerCount.Text = SalonDB.Customers.Count.ToString();
            lblAppointmentCount.Text = SalonDB.Appointments.Count.ToString();
            lblTodayCount.Text = SalonDB.GetTodayAppointmentCount().ToString();
            lblRevenue.Text = SalonDB.GetTotalRevenue().ToString("C");
        }

        private void btnAddCustomer_Click(object? sender, EventArgs e)
        {
            using (frmAddCustomer addCustomerForm = new frmAddCustomer())
            {
                addCustomerForm.ShowDialog();
            }

            LoadSummary();
        }

        private void btnAddService_Click(object? sender, EventArgs e)
        {
            using (frmAddService addServiceForm = new frmAddService())
            {
                addServiceForm.ShowDialog();
            }
        }

        private void btnBookAppointment_Click(object? sender, EventArgs e)
        {
            using (frmBookAppointment bookAppointmentForm = new frmBookAppointment())
            {
                if (bookAppointmentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSummary();
                }
            }
        }

        private void btnManageRecords_Click(object? sender, EventArgs e)
        {
            using (frmManageRecords manageRecordsForm = new frmManageRecords())
            {
                manageRecordsForm.ShowDialog();
            }

            LoadSummary();
        }

        private void btnReports_Click(object? sender, EventArgs e)
        {
            using (frmReports reportsForm = new frmReports())
            {
                reportsForm.ShowDialog();
            }
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

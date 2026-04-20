namespace HairSalonManagementApp
{
    public partial class frmDashboard : Form
    {
        // form setup
        public frmDashboard()
        {
            InitializeComponent();
            btnAddCustomer.Click += btnAddCustomer_Click;
            btnAddEmployee.Click += btnAddEmployee_Click;
            btnBookAppointment.Click += btnBookAppointment_Click;
            btnManageRecords.Click += btnManageRecords_Click;
            btnReports.Click += btnReports_Click;
            btnLogout.Click += btnLogout_Click;
            LoadSummary();
        }

        // load summary
        private void LoadSummary()
        {
            lblCustomerCount.Text = SalonDB.Customers.Count.ToString();
            lblAppointmentCount.Text = SalonDB.Appointments.Count.ToString();
            lblTodayCount.Text = SalonDB.GetTodayAppointmentCount().ToString();
            lblRevenue.Text = SalonDB.GetTotalRevenue().ToString("C");
        }

        // add customer click
        private void btnAddCustomer_Click(object? sender, EventArgs e)
        {
            using (frmAddCustomer addCustomerForm = new frmAddCustomer())
            {
                addCustomerForm.ShowDialog();
            }

            LoadSummary();
        }

        // add employee click
        private void btnAddEmployee_Click(object? sender, EventArgs e)
        {
            using (frmAddEmployee addEmployeeForm = new frmAddEmployee())
            {
                addEmployeeForm.ShowDialog();
            }
        }

        // book appointment click
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

        // manage records click
        private void btnManageRecords_Click(object? sender, EventArgs e)
        {
            using (frmManageRecords manageRecordsForm = new frmManageRecords())
            {
                manageRecordsForm.ShowDialog();
            }

            LoadSummary();
        }

        // reports click
        private void btnReports_Click(object? sender, EventArgs e)
        {
            using (frmReports reportsForm = new frmReports())
            {
                reportsForm.ShowDialog();
            }
        }

        // logout click
        private void btnLogout_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

namespace HairSalonManagementApp
{
    public partial class frmDashboard : Form
    {
        // Dashboard setup: wire navigation buttons and show the latest summary totals.
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

        // Refresh the dashboard summary labels from the saved data lists.
        private void LoadSummary()
        {
            lblCustomerCount.Text = SalonDB.Customers.Count.ToString();
            lblAppointmentCount.Text = SalonDB.Appointments.Count.ToString();
            lblTodayCount.Text = SalonDB.GetTodayAppointmentCount().ToString();
            lblRevenue.Text = SalonDB.GetTotalRevenue().ToString("C");
        }

        // Add Customer button: open the customer entry form.
        private void btnAddCustomer_Click(object? sender, EventArgs e)
        {
            using (frmAddCustomer addCustomerForm = new frmAddCustomer())
            {
                addCustomerForm.ShowDialog();
            }

            LoadSummary();
        }

        // Add Employee button: open the employee account creation form.
        private void btnAddEmployee_Click(object? sender, EventArgs e)
        {
            using (frmAddEmployee addEmployeeForm = new frmAddEmployee())
            {
                addEmployeeForm.ShowDialog();
            }
        }

        // Book Appointment button: open the appointment entry form.
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

        // Manage Records button: open the appointment search/edit/delete screen.
        private void btnManageRecords_Click(object? sender, EventArgs e)
        {
            using (frmManageRecords manageRecordsForm = new frmManageRecords())
            {
                manageRecordsForm.ShowDialog();
            }

            LoadSummary();
        }

        // Reports button: open the summary and totals screen.
        private void btnReports_Click(object? sender, EventArgs e)
        {
            using (frmReports reportsForm = new frmReports())
            {
                reportsForm.ShowDialog();
            }
        }

        // Logout button: close the dashboard and return to the login form.
        private void btnLogout_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

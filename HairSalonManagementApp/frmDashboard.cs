namespace HairSalonManagementApp
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            LoadSummaryPlaceholders();
        }

        private void LoadSummaryPlaceholders()
        {
            lblCustomerCount.Text = "0";
            lblAppointmentCount.Text = "0";
            lblTodayCount.Text = "0";
            lblRevenue.Text = "$0.00";
        }
    }
}

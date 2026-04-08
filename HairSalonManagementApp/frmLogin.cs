namespace HairSalonManagementApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click;
            btnExit.Click += btnExit_Click;
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "admin" && txtPassword.Text == "salon123")
            {
                Hide();

                using (frmDashboard dashboardForm = new frmDashboard())
                {
                    dashboardForm.ShowDialog();
                }

                txtPassword.Clear();
                Show();
                txtUsername.Focus();
            }
            else
            {
                MessageBox.Show("Use username admin and password salon123.", "Login Failed");
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

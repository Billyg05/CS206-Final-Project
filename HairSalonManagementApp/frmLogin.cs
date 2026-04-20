namespace HairSalonManagementApp
{
    public partial class frmLogin : Form
    {
        // form setup
        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click;
            btnExit.Click += btnExit_Click;
        }

        // login click
        private void btnLogin_Click(object? sender, EventArgs e)
        {
            if (!Validator.TryGetUsername(txtUsername.Text, out string username, out string errorMessage))
            {
                Validator.ShowValidationError(errorMessage, txtUsername);
                return;
            }

            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                Validator.ShowValidationError("Enter the password.", txtPassword);
                return;
            }

            Employee? employee = SalonDB.AuthenticateEmployee(username, password);

            if (employee != null)
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
                MessageBox.Show("Login failed. Check the username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }

        // exit click
        private void btnExit_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

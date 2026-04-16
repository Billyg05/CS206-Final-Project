namespace HairSalonManagementApp
{
    public partial class frmAddEmployee : Form
    {
        // Employee form setup: wire the buttons used for account creation.
        public frmAddEmployee()
        {
            InitializeComponent();
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
        }

        // Save button: validate the employee fields and create the login account.
        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (!Validator.TryGetEmployeeName(txtEmployeeName.Text, out string fullName, out string errorMessage))
            {
                Validator.ShowValidationError(errorMessage, txtEmployeeName);
                return;
            }

            if (!Validator.TryGetUsername(txtUsername.Text, out string username, out errorMessage))
            {
                Validator.ShowValidationError(errorMessage, txtUsername);
                return;
            }

            if (!Validator.TryGetPassword(txtPassword.Text, out string password, out errorMessage))
            {
                Validator.ShowValidationError(errorMessage, txtPassword);
                return;
            }

            if (txtConfirmPassword.Text != password)
            {
                Validator.ShowValidationError("Password confirmation does not match.", txtConfirmPassword);
                return;
            }

            try
            {
                Employee employee = new Employee
                {
                    FullName = fullName,
                    Username = username,
                    IsActive = true
                };

                SalonDB.SaveEmployee(employee, password);
                MessageBox.Show("Employee account saved.", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                Validator.ShowDataError(ex.Message);
            }
        }

        // Clear button: wipe the current employee entry fields.
        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        // Back button: close the employee form without saving.
        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // Reset all employee account fields back to blank.
        private void ClearForm()
        {
            txtEmployeeName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtEmployeeName.Focus();
        }
    }
}

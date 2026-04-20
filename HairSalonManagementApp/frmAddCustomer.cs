namespace HairSalonManagementApp
{
    public partial class frmAddCustomer : Form
    {
        // form setup
        public frmAddCustomer()
        {
            InitializeComponent();
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
        }

        // save click
        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (!Validator.TryGetCustomerName(txtCustomerName.Text, out string customerName, out string errorMessage))
            {
                Validator.ShowValidationError(errorMessage, txtCustomerName);
                return;
            }

            if (!Validator.TryGetPhoneNumber(txtPhoneNumber.Text, out string phoneNumber, out errorMessage))
            {
                Validator.ShowValidationError(errorMessage, txtPhoneNumber);
                return;
            }

            if (!Validator.TryGetEmail(txtEmail.Text, out string emailAddress, out errorMessage))
            {
                Validator.ShowValidationError(errorMessage, txtEmail);
                return;
            }

            if (!Validator.TryGetNotes(txtNotes.Text, out string notes, out errorMessage))
            {
                Validator.ShowValidationError(errorMessage, txtNotes);
                return;
            }

            try
            {
                Customer customer = new Customer
                {
                    FullName = customerName,
                    PhoneNumber = phoneNumber,
                    Email = emailAddress,
                    Notes = notes
                };

                SalonDB.SaveCustomer(customer);
                MessageBox.Show("Customer saved.", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                Validator.ShowDataError(ex.Message);
            }
        }

        // clear click
        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        // back click
        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // clear form
        private void ClearForm()
        {
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtNotes.Clear();
            txtCustomerName.Focus();
        }
    }
}

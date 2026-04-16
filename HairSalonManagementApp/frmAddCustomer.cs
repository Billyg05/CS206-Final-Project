namespace HairSalonManagementApp
{
    public partial class frmAddCustomer : Form
    {
        // Customer form setup: wire the buttons used for add-entry workflow.
        public frmAddCustomer()
        {
            InitializeComponent();
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
        }

        // Save button: validate the fields and store the customer record.
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

        // Clear button: empty the inputs so a new customer can be entered.
        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        // Back button: close the customer form without saving anything else.
        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // Reset every customer input back to its default blank state.
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

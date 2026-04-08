namespace HairSalonManagementApp
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
            SalonDB.Initialize();
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (!Validator.IsPresent(txtCustomerName.Text) || !Validator.IsPresent(txtPhoneNumber.Text))
            {
                MessageBox.Show("Enter the customer name and phone number.", "Missing Data");
                return;
            }

            Customer customer = new Customer
            {
                FullName = txtCustomerName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Notes = txtNotes.Text.Trim()
            };

            SalonDB.SaveCustomer(customer);
            MessageBox.Show("Customer saved.", "Save Complete");
            ClearForm();
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }

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

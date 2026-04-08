namespace HairSalonManagementApp
{
    public partial class frmAddService : Form
    {
        public frmAddService()
        {
            InitializeComponent();
            SalonDB.Initialize();
            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (!Validator.IsPresent(txtServiceName.Text) || !Validator.IsDecimal(txtPrice.Text))
            {
                MessageBox.Show("Enter a service name and a valid price.", "Missing Data");
                return;
            }

            Service service = new Service
            {
                ServiceName = txtServiceName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text),
                Category = txtCategory.Text.Trim()
            };

            SalonDB.SaveService(service);
            MessageBox.Show("Service saved.", "Save Complete");
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
            txtServiceName.Clear();
            txtPrice.Clear();
            txtCategory.Clear();
            txtDescription.Clear();
            txtServiceName.Focus();
        }
    }
}

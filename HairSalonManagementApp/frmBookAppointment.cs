namespace HairSalonManagementApp
{
    public partial class frmBookAppointment : Form
    {
        public frmBookAppointment()
        {
            InitializeComponent();
            LoadSampleLists();
        }

        private void LoadSampleLists()
        {
            cmbServices.Items.Add("Haircut");
            cmbServices.Items.Add("Color");
            cmbServices.Items.Add("Shampoo and Style");

            cmbStylist.Items.Add("Taylor");
            cmbStylist.Items.Add("Jordan");
            cmbStylist.Items.Add("Alex");

            if (cmbServices.Items.Count > 0)
            {
                cmbServices.SelectedIndex = 0;
            }

            if (cmbStylist.Items.Count > 0)
            {
                cmbStylist.SelectedIndex = 0;
            }

            txtPrice.Text = "0.00";
        }
    }
}

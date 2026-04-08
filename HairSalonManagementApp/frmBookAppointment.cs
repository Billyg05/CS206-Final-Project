namespace HairSalonManagementApp
{
    public partial class frmBookAppointment : Form
    {
        private readonly Appointment? currentAppointment;

        public frmBookAppointment()
            : this(null)
        {
        }

        public frmBookAppointment(Appointment? appointment)
        {
            InitializeComponent();
            SalonDB.Initialize();
            currentAppointment = appointment;

            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
            cmbServices.SelectedIndexChanged += cmbServices_SelectedIndexChanged;

            LoadLookupLists();

            if (currentAppointment == null)
            {
                txtPrice.Text = "0.00";
                dtpDate.Value = DateTime.Today;
            }
            else
            {
                LoadAppointmentForEdit();
            }
        }

        private void LoadLookupLists()
        {
            cmbServices.Items.Clear();
            cmbStylist.Items.Clear();

            foreach (Service service in SalonDB.Services)
            {
                cmbServices.Items.Add(service);
            }

            foreach (Stylist stylist in SalonDB.Stylists)
            {
                cmbStylist.Items.Add(stylist);
            }

            if (cmbServices.Items.Count > 0)
            {
                cmbServices.SelectedIndex = 0;
            }

            if (cmbStylist.Items.Count > 0)
            {
                cmbStylist.SelectedIndex = 0;
            }
        }

        private void LoadAppointmentForEdit()
        {
            txtCustomerName.Text = SalonDB.GetCustomerName(currentAppointment!.CustomerId);

            Customer? customer = SalonDB.Customers.FirstOrDefault(c => c.CustomerId == currentAppointment.CustomerId);
            txtPhoneNumber.Text = customer == null ? string.Empty : customer.PhoneNumber;
            txtNotes.Text = currentAppointment.Notes;
            txtPrice.Text = currentAppointment.TotalCost.ToString("0.00");
            dtpDate.Value = currentAppointment.AppointmentDate;
            dtpTime.Value = DateTime.Today.Date + currentAppointment.AppointmentDate.TimeOfDay;

            SelectService(currentAppointment.ServiceId);
            SelectStylist(currentAppointment.StylistId);
        }

        private void SelectService(int serviceId)
        {
            for (int i = 0; i < cmbServices.Items.Count; i++)
            {
                Service service = (Service)cmbServices.Items[i]!;
                if (service.ServiceId == serviceId)
                {
                    cmbServices.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SelectStylist(int stylistId)
        {
            for (int i = 0; i < cmbStylist.Items.Count; i++)
            {
                Stylist stylist = (Stylist)cmbStylist.Items[i]!;
                if (stylist.StylistId == stylistId)
                {
                    cmbStylist.SelectedIndex = i;
                    break;
                }
            }
        }

        private void cmbServices_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbServices.SelectedItem is Service service)
            {
                txtPrice.Text = service.Price.ToString("0.00");
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (!Validator.IsPresent(txtCustomerName.Text) || !Validator.IsPresent(txtPhoneNumber.Text))
            {
                MessageBox.Show("Enter the customer name and phone number.", "Missing Data");
                return;
            }

            if (cmbServices.SelectedItem is not Service service || cmbStylist.SelectedItem is not Stylist stylist)
            {
                MessageBox.Show("Select a service and stylist.", "Missing Data");
                return;
            }

            if (!Validator.IsDecimal(txtPrice.Text))
            {
                MessageBox.Show("Enter a valid price.", "Invalid Price");
                return;
            }

            Customer customer = SalonDB.FindOrCreateCustomer(txtCustomerName.Text.Trim(), txtPhoneNumber.Text.Trim());
            DateTime appointmentDate = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;

            Appointment appointment = currentAppointment ?? new Appointment();
            appointment.CustomerId = customer.CustomerId;
            appointment.ServiceId = service.ServiceId;
            appointment.StylistId = stylist.StylistId;
            appointment.AppointmentDate = appointmentDate;
            appointment.Status = "Scheduled";
            appointment.TotalCost = decimal.Parse(txtPrice.Text);
            appointment.Notes = txtNotes.Text.Trim();

            SalonDB.SaveAppointment(appointment);
            MessageBox.Show("Appointment saved.", "Save Complete");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtNotes.Clear();
            txtPrice.Text = "0.00";

            if (cmbServices.Items.Count > 0)
            {
                cmbServices.SelectedIndex = 0;
            }

            if (cmbStylist.Items.Count > 0)
            {
                cmbStylist.SelectedIndex = 0;
            }
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

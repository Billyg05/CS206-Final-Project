namespace HairSalonManagementApp
{
    public partial class frmBookAppointment : Form
    {
        private readonly Appointment? currentAppointment;

        // new mode
        public frmBookAppointment()
            : this(null)
        {
        }

        // form setup
        public frmBookAppointment(Appointment? appointment)
        {
            InitializeComponent();
            currentAppointment = appointment;

            btnSave.Click += btnSave_Click;
            btnClear.Click += btnClear_Click;
            btnBack.Click += btnBack_Click;
            btnAddCustomer.Click += btnAddCustomer_Click;
            cmbServices.SelectedIndexChanged += cmbServices_SelectedIndexChanged;
            cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;

            LoadLookupLists();

            if (currentAppointment == null)
            {
                ResetForm();
            }
            else
            {
                LoadAppointmentForEdit();
            }

            if (cmbCustomer.Items.Count == 0)
            {
                MessageBox.Show("Add a customer before booking an appointment.", "Customer Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAddCustomer.Focus();
            }
        }

        // load lists
        private void LoadLookupLists()
        {
            LoadCustomers();
            LoadServices();
            LoadStylists();
        }

        // load customers
        private void LoadCustomers()
        {
            cmbCustomer.Items.Clear();

            foreach (Customer customer in SalonDB.GetCustomersForSelection())
            {
                cmbCustomer.Items.Add(customer);
            }

            if (cmbCustomer.Items.Count > 0)
            {
                cmbCustomer.SelectedIndex = 0;
            }
            else
            {
                txtPhoneNumber.Clear();
            }
        }

        // load services
        private void LoadServices()
        {
            cmbServices.Items.Clear();

            foreach (Service service in SalonDB.GetServicesForSelection())
            {
                cmbServices.Items.Add(service);
            }

            if (cmbServices.Items.Count > 0)
            {
                cmbServices.SelectedIndex = 0;
            }
        }

        // load stylists
        private void LoadStylists()
        {
            cmbStylist.Items.Clear();

            foreach (Stylist stylist in SalonDB.GetActiveStylists())
            {
                cmbStylist.Items.Add(stylist);
            }

            if (cmbStylist.Items.Count > 0)
            {
                cmbStylist.SelectedIndex = 0;
            }
        }

        // load edit data
        private void LoadAppointmentForEdit()
        {
            SelectCustomer(currentAppointment!.CustomerId);
            SelectService(currentAppointment.ServiceId);
            SelectStylist(currentAppointment.StylistId);

            txtNotes.Text = currentAppointment.Notes;
            dtpDate.Value = currentAppointment.AppointmentDate;
            dtpTime.Value = DateTime.Today.Date + currentAppointment.AppointmentDate.TimeOfDay;
            txtPrice.Text = currentAppointment.TotalCost.ToString("0.00");
        }

        // select customer
        private void SelectCustomer(int customerId)
        {
            for (int i = 0; i < cmbCustomer.Items.Count; i++)
            {
                Customer customer = (Customer)cmbCustomer.Items[i]!;
                if (customer.CustomerId == customerId)
                {
                    cmbCustomer.SelectedIndex = i;
                    return;
                }
            }
        }

        // select service
        private void SelectService(int serviceId)
        {
            for (int i = 0; i < cmbServices.Items.Count; i++)
            {
                Service service = (Service)cmbServices.Items[i]!;
                if (service.ServiceId == serviceId)
                {
                    cmbServices.SelectedIndex = i;
                    return;
                }
            }
        }

        // select stylist
        private void SelectStylist(int stylistId)
        {
            for (int i = 0; i < cmbStylist.Items.Count; i++)
            {
                Stylist stylist = (Stylist)cmbStylist.Items[i]!;
                if (stylist.StylistId == stylistId)
                {
                    cmbStylist.SelectedIndex = i;
                    return;
                }
            }
        }

        // customer changed
        private void cmbCustomer_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem is Customer customer)
            {
                txtPhoneNumber.Text = customer.PhoneNumber;
            }
            else
            {
                txtPhoneNumber.Clear();
            }
        }

        // service changed
        private void cmbServices_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbServices.SelectedItem is Service service)
            {
                txtPrice.Text = service.Price.ToString("0.00");
            }
            else
            {
                txtPrice.Clear();
            }
        }

        // add customer click
        private void btnAddCustomer_Click(object? sender, EventArgs e)
        {
            int previousMaxCustomerId = SalonDB.Customers.Count == 0 ? 0 : SalonDB.Customers.Max(c => c.CustomerId);

            using (frmAddCustomer addCustomerForm = new frmAddCustomer())
            {
                addCustomerForm.ShowDialog();
            }

            LoadCustomers();

            // select newest customer
            Customer? newCustomer = SalonDB.Customers
                .Where(c => c.CustomerId > previousMaxCustomerId)
                .OrderByDescending(c => c.CustomerId)
                .FirstOrDefault();

            if (newCustomer != null)
            {
                SelectCustomer(newCustomer.CustomerId);
            }
        }

        // save click
        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem is not Customer customer)
            {
                Validator.ShowValidationError("Select a customer before saving the appointment.", cmbCustomer);
                return;
            }

            if (cmbServices.SelectedItem is not Service service)
            {
                Validator.ShowValidationError("Select a service before saving the appointment.", cmbServices);
                return;
            }

            if (cmbStylist.SelectedItem is not Stylist stylist)
            {
                Validator.ShowValidationError("Select a stylist before saving the appointment.", cmbStylist);
                return;
            }

            if (!Validator.TryGetNotes(txtNotes.Text, out string notes, out string errorMessage))
            {
                Validator.ShowValidationError(errorMessage, txtNotes);
                return;
            }

            // combine date time
            DateTime appointmentDate = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;
            TimeSpan appointmentTime = appointmentDate.TimeOfDay;

            if (currentAppointment == null && appointmentDate < DateTime.Now)
            {
                Validator.ShowValidationError("Appointment date and time cannot be in the past.", dtpDate);
                return;
            }

            if (appointmentTime < new TimeSpan(9, 0, 0) || appointmentTime > new TimeSpan(18, 0, 0))
            {
                Validator.ShowValidationError("Appointments must be booked between 9:00 AM and 6:00 PM.", dtpTime);
                return;
            }

            Appointment appointment = currentAppointment ?? new Appointment();
            appointment.CustomerId = customer.CustomerId;
            appointment.ServiceId = service.ServiceId;
            appointment.StylistId = stylist.StylistId;
            appointment.AppointmentDate = appointmentDate;
            appointment.Status = "Scheduled";
            appointment.TotalCost = service.Price;
            appointment.Notes = notes;

            try
            {
                SalonDB.SaveAppointment(appointment);
                MessageBox.Show("Appointment saved.", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Validator.ShowDataError(ex.Message);
            }
        }

        // clear click
        private void btnClear_Click(object? sender, EventArgs e)
        {
            ResetForm();
        }

        // back click
        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // reset form
        private void ResetForm()
        {
            if (cmbCustomer.Items.Count > 0)
            {
                cmbCustomer.SelectedIndex = 0;
            }
            else
            {
                txtPhoneNumber.Clear();
            }

            if (cmbServices.Items.Count > 0)
            {
                cmbServices.SelectedIndex = 0;
            }

            if (cmbStylist.Items.Count > 0)
            {
                cmbStylist.SelectedIndex = 0;
            }

            txtNotes.Clear();
            dtpDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Today.AddHours(9);
            cmbCustomer.Focus();
        }
    }
}

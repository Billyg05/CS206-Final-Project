namespace HairSalonManagementApp
{
    public partial class frmManageRecords : Form
    {
        // Records form setup: wire action buttons and load the filters/grid once.
        public frmManageRecords()
        {
            InitializeComponent();

            btnSearch.Click += btnSearch_Click;
            btnReset.Click += btnReset_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnBack.Click += btnBack_Click;

            LoadServiceFilter();
            LoadAppointments();
        }

        // Fill the service filter drop-down, including the "all services" option.
        private void LoadServiceFilter()
        {
            cmbFilterServices.Items.Clear();
            cmbFilterServices.Items.Add("(All Services)");

            foreach (Service service in SalonDB.GetServicesForSelection())
            {
                cmbFilterServices.Items.Add(service);
            }

            cmbFilterServices.SelectedIndex = 0;
            dtpFilterDate.Checked = false;
        }

        // Load the appointment grid using the current search and filter controls.
        private void LoadAppointments()
        {
            int? serviceId = null;
            DateTime? filterDate = dtpFilterDate.Checked ? dtpFilterDate.Value.Date : null;

            if (cmbFilterServices.SelectedItem is Service selectedService)
            {
                serviceId = selectedService.ServiceId;
            }

            List<Appointment> appointments = SalonDB.SearchAppointments(
                txtSearch.Text,
                serviceId,
                filterDate);

            dgvAppointments.Rows.Clear();

            foreach (Appointment appointment in appointments)
            {
                dgvAppointments.Rows.Add(
                    appointment.AppointmentId,
                    SalonDB.GetCustomerName(appointment.CustomerId),
                    SalonDB.GetServiceName(appointment.ServiceId),
                    SalonDB.GetStylistName(appointment.StylistId),
                    appointment.AppointmentDate.ToString("MM/dd/yyyy hh:mm tt"),
                    appointment.TotalCost.ToString("C"));
            }

            if (dgvAppointments.Rows.Count > 0)
            {
                dgvAppointments.Rows[0].Selected = true;
            }
        }

        // Search button: reload the grid with the current filter values.
        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadAppointments();
        }

        // Reset button: clear every filter and show the full appointment list again.
        private void btnReset_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterServices.SelectedIndex = 0;
            dtpFilterDate.Checked = false;
            LoadAppointments();
        }

        // Edit button: open the selected appointment in the booking form.
        private void btnEdit_Click(object? sender, EventArgs e)
        {
            Appointment? appointment = GetSelectedAppointment();

            if (appointment == null)
            {
                MessageBox.Show("Select an appointment to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmBookAppointment bookAppointmentForm = new frmBookAppointment(appointment))
            {
                if (bookAppointmentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAppointments();
                }
            }
        }

        // Delete button: remove the selected appointment after confirmation.
        private void btnDelete_Click(object? sender, EventArgs e)
        {
            Appointment? appointment = GetSelectedAppointment();

            if (appointment == null)
            {
                MessageBox.Show("Select an appointment to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Delete this appointment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SalonDB.DeleteAppointment(appointment.AppointmentId);
                LoadAppointments();
            }
        }

        // Refresh button: reload filters and data from the current saved lists.
        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadServiceFilter();
            LoadAppointments();
        }

        // Back button: close the records screen.
        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // Read the appointment ID from the selected grid row and find that record in memory.
        private Appointment? GetSelectedAppointment()
        {
            if (dgvAppointments.CurrentRow?.Cells[0].Value == null)
            {
                return null;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
            return SalonDB.GetAppointmentById(appointmentId);
        }
    }
}

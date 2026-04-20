namespace HairSalonManagementApp
{
    public partial class frmManageRecords : Form
    {
        // form setup
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

        // load filters
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

        // load grid
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

        // search click
        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadAppointments();
        }

        // reset click
        private void btnReset_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterServices.SelectedIndex = 0;
            dtpFilterDate.Checked = false;
            LoadAppointments();
        }

        // edit click
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

        // delete click
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

        // refresh click
        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadServiceFilter();
            LoadAppointments();
        }

        // back click
        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // selected appointment
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

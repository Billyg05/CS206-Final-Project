namespace HairSalonManagementApp
{
    public partial class frmManageRecords : Form
    {
        public frmManageRecords()
        {
            InitializeComponent();
            SalonDB.Initialize();

            btnSearch.Click += btnSearch_Click;
            btnReset.Click += btnReset_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnBack.Click += btnBack_Click;

            LoadAppointments();
        }

        private void LoadAppointments()
        {
            DateTime? filterDate = null;

            if (!string.IsNullOrWhiteSpace(txtFilterDate.Text))
            {
                if (DateTime.TryParse(txtFilterDate.Text, out DateTime parsedDate))
                {
                    filterDate = parsedDate;
                }
                else
                {
                    MessageBox.Show("Enter the date like MM/DD/YYYY or leave it blank.", "Invalid Date");
                    return;
                }
            }

            List<Appointment> appointments = SalonDB.SearchAppointments(
                txtSearch.Text,
                txtFilterServices.Text,
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
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnReset_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            txtFilterServices.Clear();
            txtFilterDate.Clear();
            LoadAppointments();
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                MessageBox.Show("Select an appointment to edit.", "No Selection");
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);
            Appointment? appointment = SalonDB.GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                MessageBox.Show("The selected appointment could not be found.", "Not Found");
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

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null)
            {
                MessageBox.Show("Select an appointment to delete.", "No Selection");
                return;
            }

            int appointmentId = Convert.ToInt32(dgvAppointments.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Delete this appointment?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SalonDB.DeleteAppointment(appointmentId);
                LoadAppointments();
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}

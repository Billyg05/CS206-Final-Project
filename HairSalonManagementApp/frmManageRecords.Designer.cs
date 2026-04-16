namespace HairSalonManagementApp
{
    partial class frmManageRecords
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSearch;
        private ComboBox cmbFilterServices;
        private DateTimePicker dtpFilterDate;
        private Button btnSearch;
        private Button btnReset;
        private DataGridView dgvAppointments;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnBack;
        private DataGridViewTextBoxColumn colAppointmentId;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colServices;
        private DataGridViewTextBoxColumn colStylist;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colPrice;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvAppointments = new DataGridView();
            colAppointmentId = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colServices = new DataGridViewTextBoxColumn();
            colStylist = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtSearch = new TextBox();
            cmbFilterServices = new ComboBox();
            dtpFilterDate = new DateTimePicker();
            btnSearch = new Button();
            btnReset = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            SuspendLayout();
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToDeleteRows = false;
            dgvAppointments.AllowUserToResizeRows = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { colAppointmentId, colCustomer, colServices, colStylist, colDate, colPrice });
            dgvAppointments.Location = new Point(29, 171);
            dgvAppointments.MultiSelect = false;
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.ReadOnly = true;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(720, 205);
            dgvAppointments.TabIndex = 6;
            // 
            // colAppointmentId
            // 
            colAppointmentId.FillWeight = 85F;
            colAppointmentId.HeaderText = "Appointment ID";
            colAppointmentId.Name = "colAppointmentId";
            colAppointmentId.ReadOnly = true;
            // 
            // colCustomer
            // 
            colCustomer.FillWeight = 110F;
            colCustomer.HeaderText = "Customer";
            colCustomer.Name = "colCustomer";
            colCustomer.ReadOnly = true;
            // 
            // colServices
            // 
            colServices.FillWeight = 95F;
            colServices.HeaderText = "Service";
            colServices.Name = "colServices";
            colServices.ReadOnly = true;
            // 
            // colStylist
            // 
            colStylist.FillWeight = 90F;
            colStylist.HeaderText = "Stylist";
            colStylist.Name = "colStylist";
            colStylist.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.FillWeight = 120F;
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.FillWeight = 75F;
            colPrice.HeaderText = "Price";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(327, 24);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 0;
            label1.Text = "Manage Records";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 73);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 1;
            label2.Text = "Search:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(411, 73);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 2;
            label3.Text = "Filter Service:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 121);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 3;
            label4.Text = "Filter Date:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(110, 69);
            txtSearch.MaxLength = 50;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(191, 27);
            txtSearch.TabIndex = 0;
            // 
            // cmbFilterServices
            // 
            cmbFilterServices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterServices.FormattingEnabled = true;
            cmbFilterServices.Location = new Point(519, 69);
            cmbFilterServices.Name = "cmbFilterServices";
            cmbFilterServices.Size = new Size(177, 28);
            cmbFilterServices.TabIndex = 1;
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Checked = false;
            dtpFilterDate.Format = DateTimePickerFormat.Short;
            dtpFilterDate.Location = new Point(135, 117);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.ShowCheckBox = true;
            dtpFilterDate.Size = new Size(166, 27);
            dtpFilterDate.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(411, 115);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(86, 36);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "&Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(519, 115);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(86, 36);
            btnReset.TabIndex = 4;
            btnReset.Text = "&Reset";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(135, 404);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(86, 36);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "&Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(282, 404);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 36);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(430, 404);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(86, 36);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "&Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(577, 404);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(86, 36);
            btnBack.TabIndex = 10;
            btnBack.Text = "&Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // frmManageRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 473);
            Controls.Add(btnBack);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnReset);
            Controls.Add(btnSearch);
            Controls.Add(dtpFilterDate);
            Controls.Add(cmbFilterServices);
            Controls.Add(txtSearch);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvAppointments);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmManageRecords";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Records";
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

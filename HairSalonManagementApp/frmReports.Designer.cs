namespace HairSalonManagementApp
{
    partial class frmReports
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblCustomers;
        private Label lblAppointments;
        private Label lblRevenue;
        private Label lblTopService;
        private ListBox lstSummary;
        private Button btnRefresh;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblCustomers = new Label();
            lblAppointments = new Label();
            lblRevenue = new Label();
            lblTopService = new Label();
            lstSummary = new ListBox();
            btnRefresh = new Button();
            btnClose = new Button();
            SuspendLayout();
            label1.AutoSize = true;
            label1.Location = new Point(144, 16);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 0;
            label1.Text = "Reports and Summary";
            label2.AutoSize = true;
            label2.Location = new Point(29, 54);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 1;
            label2.Text = "Total Customers:";
            label3.AutoSize = true;
            label3.Location = new Point(29, 88);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 2;
            label3.Text = "All Appointments:";
            label4.AutoSize = true;
            label4.Location = new Point(29, 122);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 3;
            label4.Text = "Total Revenue:";
            label5.AutoSize = true;
            label5.Location = new Point(29, 156);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 4;
            label5.Text = "Top Service:";
            lblCustomers.BorderStyle = BorderStyle.FixedSingle;
            lblCustomers.Location = new Point(148, 50);
            lblCustomers.Name = "lblCustomers";
            lblCustomers.Size = new Size(100, 23);
            lblCustomers.TabIndex = 5;
            lblAppointments.BorderStyle = BorderStyle.FixedSingle;
            lblAppointments.Location = new Point(148, 84);
            lblAppointments.Name = "lblAppointments";
            lblAppointments.Size = new Size(100, 23);
            lblAppointments.TabIndex = 6;
            lblRevenue.BorderStyle = BorderStyle.FixedSingle;
            lblRevenue.Location = new Point(148, 118);
            lblRevenue.Name = "lblRevenue";
            lblRevenue.Size = new Size(100, 23);
            lblRevenue.TabIndex = 7;
            lblTopService.BorderStyle = BorderStyle.FixedSingle;
            lblTopService.Location = new Point(148, 152);
            lblTopService.Name = "lblTopService";
            lblTopService.Size = new Size(100, 23);
            lblTopService.TabIndex = 8;
            lstSummary.FormattingEnabled = true;
            lstSummary.ItemHeight = 15;
            lstSummary.Location = new Point(29, 193);
            lstSummary.Name = "lstSummary";
            lstSummary.Size = new Size(338, 109);
            lstSummary.TabIndex = 0;
            btnRefresh.Location = new Point(95, 322);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 28);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "&Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnClose.Location = new Point(223, 322);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 28);
            btnClose.TabIndex = 2;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 370);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(lstSummary);
            Controls.Add(lblTopService);
            Controls.Add(lblRevenue);
            Controls.Add(lblAppointments);
            Controls.Add(lblCustomers);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmReports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

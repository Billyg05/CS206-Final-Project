namespace HairSalonManagementApp
{
    partial class frmDashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label label1;
        private Button btnAddCustomer;
        private Button btnAddEmployee;
        private Button btnBookAppointment;
        private Button btnManageRecords;
        private Button btnReports;
        private Button btnLogout;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblCustomerCount;
        private Label lblAppointmentCount;
        private Label lblTodayCount;
        private Label lblRevenue;

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
            label1 = new Label();
            btnAddCustomer = new Button();
            btnAddEmployee = new Button();
            btnBookAppointment = new Button();
            btnManageRecords = new Button();
            btnReports = new Button();
            btnLogout = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblCustomerCount = new Label();
            lblAppointmentCount = new Label();
            lblTodayCount = new Label();
            lblRevenue = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(179, 24);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(40, 75);
            btnAddCustomer.Margin = new Padding(3, 4, 3, 4);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(109, 40);
            btnAddCustomer.TabIndex = 0;
            btnAddCustomer.Text = "Add customer";
            btnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Location = new Point(163, 75);
            btnAddEmployee.Margin = new Padding(3, 4, 3, 4);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(109, 40);
            btnAddEmployee.TabIndex = 1;
            btnAddEmployee.Text = "Add employee";
            btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // btnBookAppointment
            // 
            btnBookAppointment.Location = new Point(287, 75);
            btnBookAppointment.Margin = new Padding(3, 4, 3, 4);
            btnBookAppointment.Name = "btnBookAppointment";
            btnBookAppointment.Size = new Size(109, 40);
            btnBookAppointment.TabIndex = 2;
            btnBookAppointment.Text = "Book Apt";
            btnBookAppointment.UseVisualStyleBackColor = true;
            // 
            // btnManageRecords
            // 
            btnManageRecords.Location = new Point(40, 127);
            btnManageRecords.Margin = new Padding(3, 4, 3, 4);
            btnManageRecords.Name = "btnManageRecords";
            btnManageRecords.Size = new Size(109, 40);
            btnManageRecords.TabIndex = 3;
            btnManageRecords.Text = "Manage records";
            btnManageRecords.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(163, 127);
            btnReports.Margin = new Padding(3, 4, 3, 4);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(109, 40);
            btnReports.TabIndex = 4;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(287, 127);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(109, 40);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 215);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 7;
            label2.Text = "Total Customers:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 257);
            label3.Name = "label3";
            label3.Size = new Size(143, 20);
            label3.TabIndex = 8;
            label3.Text = "Total Appointments:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 300);
            label4.Name = "label4";
            label4.Size = new Size(159, 20);
            label4.TabIndex = 9;
            label4.Text = "Today's Appointments:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 343);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 10;
            label5.Text = "Total Revenue:";
            // 
            // lblCustomerCount
            // 
            lblCustomerCount.BorderStyle = BorderStyle.FixedSingle;
            lblCustomerCount.Location = new Point(205, 209);
            lblCustomerCount.Name = "lblCustomerCount";
            lblCustomerCount.Size = new Size(96, 30);
            lblCustomerCount.TabIndex = 11;
            lblCustomerCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAppointmentCount
            // 
            lblAppointmentCount.BorderStyle = BorderStyle.FixedSingle;
            lblAppointmentCount.Location = new Point(205, 252);
            lblAppointmentCount.Name = "lblAppointmentCount";
            lblAppointmentCount.Size = new Size(96, 30);
            lblAppointmentCount.TabIndex = 12;
            lblAppointmentCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTodayCount
            // 
            lblTodayCount.BorderStyle = BorderStyle.FixedSingle;
            lblTodayCount.Location = new Point(205, 295);
            lblTodayCount.Name = "lblTodayCount";
            lblTodayCount.Size = new Size(96, 30);
            lblTodayCount.TabIndex = 13;
            lblTodayCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRevenue
            // 
            lblRevenue.BorderStyle = BorderStyle.FixedSingle;
            lblRevenue.Location = new Point(205, 337);
            lblRevenue.Name = "lblRevenue";
            lblRevenue.Size = new Size(96, 30);
            lblRevenue.TabIndex = 14;
            lblRevenue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 405);
            Controls.Add(lblRevenue);
            Controls.Add(lblTodayCount);
            Controls.Add(lblAppointmentCount);
            Controls.Add(lblCustomerCount);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnLogout);
            Controls.Add(btnReports);
            Controls.Add(btnManageRecords);
            Controls.Add(btnBookAppointment);
            Controls.Add(btnAddEmployee);
            Controls.Add(btnAddCustomer);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

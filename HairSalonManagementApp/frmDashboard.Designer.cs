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
        private Button btnAddService;
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnBookAppointment = new System.Windows.Forms.Button();
            this.btnManageRecords = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCustomerCount = new System.Windows.Forms.Label();
            this.lblAppointmentCount = new System.Windows.Forms.Label();
            this.lblTodayCount = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(35, 56);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(95, 30);
            this.btnAddCustomer.TabIndex = 0;
            this.btnAddCustomer.Text = "Add customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(143, 56);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(95, 30);
            this.btnAddService.TabIndex = 1;
            this.btnAddService.Text = "Add service";
            this.btnAddService.UseVisualStyleBackColor = true;
            // 
            // btnBookAppointment
            // 
            this.btnBookAppointment.Location = new System.Drawing.Point(251, 56);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Size = new System.Drawing.Size(95, 30);
            this.btnBookAppointment.TabIndex = 2;
            this.btnBookAppointment.Text = "Book Apt";
            this.btnBookAppointment.UseVisualStyleBackColor = true;
            // 
            // btnManageRecords
            // 
            this.btnManageRecords.Location = new System.Drawing.Point(35, 95);
            this.btnManageRecords.Name = "btnManageRecords";
            this.btnManageRecords.Size = new System.Drawing.Size(95, 30);
            this.btnManageRecords.TabIndex = 3;
            this.btnManageRecords.Text = "Manage records";
            this.btnManageRecords.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(143, 95);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(95, 30);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(251, 95);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(95, 30);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total Customers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Appointments:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Today's Appointments:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total Revenue:";
            // 
            // lblCustomerCount
            // 
            this.lblCustomerCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomerCount.Location = new System.Drawing.Point(179, 157);
            this.lblCustomerCount.Name = "lblCustomerCount";
            this.lblCustomerCount.Size = new System.Drawing.Size(84, 23);
            this.lblCustomerCount.TabIndex = 11;
            this.lblCustomerCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAppointmentCount
            // 
            this.lblAppointmentCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAppointmentCount.Location = new System.Drawing.Point(179, 189);
            this.lblAppointmentCount.Name = "lblAppointmentCount";
            this.lblAppointmentCount.Size = new System.Drawing.Size(84, 23);
            this.lblAppointmentCount.TabIndex = 12;
            this.lblAppointmentCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTodayCount
            // 
            this.lblTodayCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTodayCount.Location = new System.Drawing.Point(179, 221);
            this.lblTodayCount.Name = "lblTodayCount";
            this.lblTodayCount.Size = new System.Drawing.Size(84, 23);
            this.lblTodayCount.TabIndex = 13;
            this.lblTodayCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRevenue
            // 
            this.lblRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRevenue.Location = new System.Drawing.Point(179, 253);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(84, 23);
            this.lblRevenue.TabIndex = 14;
            this.lblRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 304);
            this.Controls.Add(this.lblRevenue);
            this.Controls.Add(this.lblTodayCount);
            this.Controls.Add(this.lblAppointmentCount);
            this.Controls.Add(this.lblCustomerCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnManageRecords);
            this.Controls.Add(this.btnBookAppointment);
            this.Controls.Add(this.btnAddService);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

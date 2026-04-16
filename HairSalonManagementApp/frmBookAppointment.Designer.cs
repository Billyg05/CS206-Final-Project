namespace HairSalonManagementApp
{
    partial class frmBookAppointment
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox cmbCustomer;
        private Button btnAddCustomer;
        private TextBox txtPhoneNumber;
        private ComboBox cmbServices;
        private ComboBox cmbStylist;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpTime;
        private TextBox txtPrice;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnClear;
        private Button btnBack;

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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            cmbCustomer = new ComboBox();
            btnAddCustomer = new Button();
            txtPhoneNumber = new TextBox();
            cmbServices = new ComboBox();
            cmbStylist = new ComboBox();
            dtpDate = new DateTimePicker();
            dtpTime = new DateTimePicker();
            txtPrice = new TextBox();
            txtNotes = new TextBox();
            btnSave = new Button();
            btnClear = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(154, 16);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 0;
            label1.Text = "Book Appointment";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 56);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Customer:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 94);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 2;
            label3.Text = "Phone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 132);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 3;
            label4.Text = "Service:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 170);
            label5.Name = "label5";
            label5.Size = new Size(48, 20);
            label5.TabIndex = 4;
            label5.Text = "Stylist:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 208);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 5;
            label6.Text = "Date:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 246);
            label7.Name = "label7";
            label7.Size = new Size(43, 20);
            label7.TabIndex = 6;
            label7.Text = "Time:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 284);
            label8.Name = "label8";
            label8.Size = new Size(41, 20);
            label8.TabIndex = 7;
            label8.Text = "Price:";
            // 
            // cmbCustomer
            // 
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(144, 52);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(193, 28);
            cmbCustomer.TabIndex = 0;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(348, 51);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(66, 30);
            btnAddCustomer.TabIndex = 1;
            btnAddCustomer.Text = "&New";
            btnAddCustomer.UseVisualStyleBackColor = true;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(144, 90);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.ReadOnly = true;
            txtPhoneNumber.Size = new Size(193, 27);
            txtPhoneNumber.TabIndex = 2;
            txtPhoneNumber.TabStop = false;
            // 
            // cmbServices
            // 
            cmbServices.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServices.FormattingEnabled = true;
            cmbServices.Location = new Point(144, 128);
            cmbServices.Name = "cmbServices";
            cmbServices.Size = new Size(193, 28);
            cmbServices.TabIndex = 3;
            // 
            // cmbStylist
            // 
            cmbStylist.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStylist.FormattingEnabled = true;
            cmbStylist.Location = new Point(144, 166);
            cmbStylist.Name = "cmbStylist";
            cmbStylist.Size = new Size(193, 28);
            cmbStylist.TabIndex = 4;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(144, 204);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(193, 27);
            dtpDate.TabIndex = 5;
            // 
            // dtpTime
            // 
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(144, 242);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(193, 27);
            dtpTime.TabIndex = 6;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(144, 280);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(193, 27);
            txtPrice.TabIndex = 7;
            txtPrice.TabStop = false;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(29, 334);
            txtNotes.MaxLength = 200;
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(385, 86);
            txtNotes.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(54, 441);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 34);
            btnSave.TabIndex = 9;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(174, 441);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 34);
            btnClear.TabIndex = 10;
            btnClear.Text = "C&lear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(293, 441);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 34);
            btnBack.TabIndex = 11;
            btnBack.Text = "&Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // frmBookAppointment
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnBack;
            ClientSize = new Size(445, 495);
            Controls.Add(btnBack);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(txtNotes);
            Controls.Add(txtPrice);
            Controls.Add(dtpTime);
            Controls.Add(dtpDate);
            Controls.Add(cmbStylist);
            Controls.Add(cmbServices);
            Controls.Add(txtPhoneNumber);
            Controls.Add(btnAddCustomer);
            Controls.Add(cmbCustomer);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmBookAppointment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}

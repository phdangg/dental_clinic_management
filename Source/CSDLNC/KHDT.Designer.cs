namespace CSDLNC
{
    partial class KHDT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KHDT));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tpDentistName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpDentistID = new System.Windows.Forms.ComboBox();
            this.adjustBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tpPaymentStatus = new System.Windows.Forms.ComboBox();
            this.tpPatient = new System.Windows.Forms.TextBox();
            this.tpPlanID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.tpDentistName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tpDentistID);
            this.panel1.Controls.Add(this.adjustBtn);
            this.panel1.Controls.Add(this.delBtn);
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tpPaymentStatus);
            this.panel1.Controls.Add(this.tpPatient);
            this.panel1.Controls.Add(this.tpPlanID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(418, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 452);
            this.panel1.TabIndex = 21;
            // 
            // tpDentistName
            // 
            this.tpDentistName.Location = new System.Drawing.Point(133, 142);
            this.tpDentistName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpDentistName.Name = "tpDentistName";
            this.tpDentistName.Size = new System.Drawing.Size(214, 22);
            this.tpDentistName.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Tên nha sĩ";
            // 
            // tpDentistID
            // 
            this.tpDentistID.FormattingEnabled = true;
            this.tpDentistID.Location = new System.Drawing.Point(133, 101);
            this.tpDentistID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpDentistID.Name = "tpDentistID";
            this.tpDentistID.Size = new System.Drawing.Size(214, 24);
            this.tpDentistID.TabIndex = 39;
            // 
            // adjustBtn
            // 
            this.adjustBtn.Location = new System.Drawing.Point(261, 275);
            this.adjustBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adjustBtn.Name = "adjustBtn";
            this.adjustBtn.Size = new System.Drawing.Size(85, 31);
            this.adjustBtn.TabIndex = 38;
            this.adjustBtn.Text = "Sửa";
            this.adjustBtn.UseVisualStyleBackColor = true;
            this.adjustBtn.Click += new System.EventHandler(this.adjustBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(144, 275);
            this.delBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(85, 31);
            this.delBtn.TabIndex = 37;
            this.delBtn.Text = "Xóa";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(30, 275);
            this.addBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(85, 31);
            this.addBtn.TabIndex = 34;
            this.addBtn.Text = "Thêm";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 348);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 49);
            this.button2.TabIndex = 29;
            this.button2.Text = "Xem Danh sách điều trị";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Trạng thái";
            // 
            // tpPaymentStatus
            // 
            this.tpPaymentStatus.FormattingEnabled = true;
            this.tpPaymentStatus.Items.AddRange(new object[] {
            "Đang điều trị",
            "Đã hoàn thành"});
            this.tpPaymentStatus.Location = new System.Drawing.Point(133, 218);
            this.tpPaymentStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpPaymentStatus.Name = "tpPaymentStatus";
            this.tpPaymentStatus.Size = new System.Drawing.Size(214, 24);
            this.tpPaymentStatus.TabIndex = 16;
            // 
            // tpPatient
            // 
            this.tpPatient.Location = new System.Drawing.Point(133, 183);
            this.tpPatient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpPatient.Name = "tpPatient";
            this.tpPatient.Size = new System.Drawing.Size(214, 22);
            this.tpPatient.TabIndex = 12;
            // 
            // tpPlanID
            // 
            this.tpPlanID.Location = new System.Drawing.Point(133, 62);
            this.tpPlanID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpPlanID.Name = "tpPlanID";
            this.tpPlanID.Size = new System.Drawing.Size(214, 22);
            this.tpPlanID.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID Kế hoạch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "ID Nha sĩ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Bệnh nhân";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Location = new System.Drawing.Point(136, 394);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Kế hoạch điều trị";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 68);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(408, 320);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // KHDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "KHDT";
            this.Text = "KHDT";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox tpPaymentStatus;
        private System.Windows.Forms.TextBox tpPatient;
        private System.Windows.Forms.TextBox tpPlanID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button adjustBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ComboBox tpDentistID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tpDentistName;
    }
}
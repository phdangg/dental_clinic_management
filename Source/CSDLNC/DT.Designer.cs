namespace CSDLNC
{
    partial class DT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DT));
            this.panel1 = new System.Windows.Forms.Panel();
            this.treatingList = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewToothbtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.treatmentCategory = new System.Windows.Forms.TextBox();
            this.treatingFee = new System.Windows.Forms.TextBox();
            this.treatmentName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.delBtn = new System.Windows.Forms.Button();
            this.adjustBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.treatingDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treatmentID = new System.Windows.Forms.ComboBox();
            this.treatingPayment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treatingList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.treatingList);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 452);
            this.panel1.TabIndex = 29;
            // 
            // treatingList
            // 
            this.treatingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.treatingList.Location = new System.Drawing.Point(13, 53);
            this.treatingList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treatingList.Name = "treatingList";
            this.treatingList.RowHeadersWidth = 62;
            this.treatingList.RowTemplate.Height = 28;
            this.treatingList.Size = new System.Drawing.Size(380, 322);
            this.treatingList.TabIndex = 28;
            this.treatingList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.treatingList_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Location = new System.Drawing.Point(132, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 44);
            this.button1.TabIndex = 26;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 32);
            this.label1.TabIndex = 27;
            this.label1.Text = "Danh sách điều trị";
            // 
            // viewToothbtn
            // 
            this.viewToothbtn.Location = new System.Drawing.Point(560, 225);
            this.viewToothbtn.Name = "viewToothbtn";
            this.viewToothbtn.Size = new System.Drawing.Size(212, 38);
            this.viewToothbtn.TabIndex = 29;
            this.viewToothbtn.Text = "Xem Danh sách Răng";
            this.viewToothbtn.UseVisualStyleBackColor = true;
            this.viewToothbtn.Click += new System.EventHandler(this.viewToothbtn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(982, 308);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 23);
            this.button4.TabIndex = 27;
            this.button4.Text = "Xem";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(982, 269);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Xem";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Răng";
            // 
            // treatmentCategory
            // 
            this.treatmentCategory.Location = new System.Drawing.Point(561, 133);
            this.treatmentCategory.Name = "treatmentCategory";
            this.treatmentCategory.Size = new System.Drawing.Size(213, 22);
            this.treatmentCategory.TabIndex = 11;
            // 
            // treatingFee
            // 
            this.treatingFee.Location = new System.Drawing.Point(561, 160);
            this.treatingFee.Name = "treatingFee";
            this.treatingFee.Size = new System.Drawing.Size(213, 22);
            this.treatingFee.TabIndex = 12;
            // 
            // treatmentName
            // 
            this.treatmentName.Location = new System.Drawing.Point(561, 78);
            this.treatmentName.Name = "treatmentName";
            this.treatmentName.Size = new System.Drawing.Size(213, 22);
            this.treatmentName.TabIndex = 13;
            this.treatmentName.TextChanged += new System.EventHandler(this.treatmentName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Phí";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Danh mục";
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(687, 320);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(86, 34);
            this.delBtn.TabIndex = 35;
            this.delBtn.Text = "Xóa";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // adjustBtn
            // 
            this.adjustBtn.Location = new System.Drawing.Point(560, 320);
            this.adjustBtn.Name = "adjustBtn";
            this.adjustBtn.Size = new System.Drawing.Size(86, 34);
            this.adjustBtn.TabIndex = 34;
            this.adjustBtn.Text = "Sửa";
            this.adjustBtn.UseVisualStyleBackColor = true;
            this.adjustBtn.Click += new System.EventHandler(this.adjustBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(441, 320);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(86, 34);
            this.addBtn.TabIndex = 33;
            this.addBtn.Text = "Thêm";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // treatingDate
            // 
            this.treatingDate.Location = new System.Drawing.Point(561, 106);
            this.treatingDate.Name = "treatingDate";
            this.treatingDate.Size = new System.Drawing.Size(213, 22);
            this.treatingDate.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "Ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "ID";
            // 
            // treatmentID
            // 
            this.treatmentID.FormattingEnabled = true;
            this.treatmentID.Location = new System.Drawing.Point(561, 50);
            this.treatmentID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treatmentID.Name = "treatmentID";
            this.treatmentID.Size = new System.Drawing.Size(211, 24);
            this.treatmentID.TabIndex = 40;
            // 
            // treatingPayment
            // 
            this.treatingPayment.FormattingEnabled = true;
            this.treatingPayment.Items.AddRange(new object[] {
            "Đã thanh toán",
            "Chưa thanh toán"});
            this.treatingPayment.Location = new System.Drawing.Point(560, 186);
            this.treatingPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treatingPayment.Name = "treatingPayment";
            this.treatingPayment.Size = new System.Drawing.Size(211, 24);
            this.treatingPayment.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(453, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 43);
            this.label8.TabIndex = 41;
            this.label8.Text = "Tình trạng thanh toán";
            // 
            // DT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treatingPayment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.treatmentID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.treatingDate);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.adjustBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.viewToothbtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treatmentName);
            this.Controls.Add(this.treatingFee);
            this.Controls.Add(this.treatmentCategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DT";
            this.Text = "DT";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treatingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button viewToothbtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox treatmentCategory;
        private System.Windows.Forms.TextBox treatingFee;
        private System.Windows.Forms.TextBox treatmentName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button adjustBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox treatingDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView treatingList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox treatmentID;
        private System.Windows.Forms.ComboBox treatingPayment;
        private System.Windows.Forms.Label label8;
    }
}
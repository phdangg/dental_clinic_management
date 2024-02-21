namespace CSDLNC
{
    partial class Tooth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tooth));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toothList = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.toothName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.surfaceName = new System.Windows.Forms.TextBox();
            this.surfaceDescription = new System.Windows.Forms.TextBox();
            this.surfaceIDlb = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.surfaceID = new System.Windows.Forms.ComboBox();
            this.toothID = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toothList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách răng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID Răng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên răng";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.toothList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 229);
            this.panel1.TabIndex = 5;
            // 
            // toothList
            // 
            this.toothList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toothList.Location = new System.Drawing.Point(30, 47);
            this.toothList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toothList.Name = "toothList";
            this.toothList.RowHeadersWidth = 62;
            this.toothList.RowTemplate.Height = 28;
            this.toothList.Size = new System.Drawing.Size(741, 168);
            this.toothList.TabIndex = 1;
            this.toothList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Răng đã chọn";
            // 
            // toothName
            // 
            this.toothName.Location = new System.Drawing.Point(136, 315);
            this.toothName.Name = "toothName";
            this.toothName.Size = new System.Drawing.Size(107, 22);
            this.toothName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Tên mặt răng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(428, 346);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Mô tả";
            // 
            // surfaceName
            // 
            this.surfaceName.Location = new System.Drawing.Point(535, 310);
            this.surfaceName.Name = "surfaceName";
            this.surfaceName.Size = new System.Drawing.Size(107, 22);
            this.surfaceName.TabIndex = 13;
            // 
            // surfaceDescription
            // 
            this.surfaceDescription.Location = new System.Drawing.Point(535, 341);
            this.surfaceDescription.Name = "surfaceDescription";
            this.surfaceDescription.Size = new System.Drawing.Size(107, 22);
            this.surfaceDescription.TabIndex = 14;
            // 
            // surfaceIDlb
            // 
            this.surfaceIDlb.AutoSize = true;
            this.surfaceIDlb.Location = new System.Drawing.Point(428, 283);
            this.surfaceIDlb.Name = "surfaceIDlb";
            this.surfaceIDlb.Size = new System.Drawing.Size(75, 16);
            this.surfaceIDlb.TabIndex = 15;
            this.surfaceIDlb.Text = "ID mặt răng";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(535, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(638, 408);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button4.Location = new System.Drawing.Point(28, 408);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 30);
            this.button4.TabIndex = 20;
            this.button4.Text = "Xong";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button5.Location = new System.Drawing.Point(150, 408);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 30);
            this.button5.TabIndex = 21;
            this.button5.Text = "Hủy";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // surfaceID
            // 
            this.surfaceID.FormattingEnabled = true;
            this.surfaceID.Location = new System.Drawing.Point(534, 277);
            this.surfaceID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.surfaceID.Name = "surfaceID";
            this.surfaceID.Size = new System.Drawing.Size(108, 24);
            this.surfaceID.TabIndex = 22;
            // 
            // toothID
            // 
            this.toothID.FormattingEnabled = true;
            this.toothID.Location = new System.Drawing.Point(136, 283);
            this.toothID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toothID.Name = "toothID";
            this.toothID.Size = new System.Drawing.Size(108, 24);
            this.toothID.TabIndex = 23;
            // 
            // Tooth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toothID);
            this.Controls.Add(this.surfaceID);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.surfaceIDlb);
            this.Controls.Add(this.surfaceDescription);
            this.Controls.Add(this.surfaceName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toothName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tooth";
            this.Text = "Tooth";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toothList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox toothName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox surfaceName;
        private System.Windows.Forms.TextBox surfaceDescription;
        private System.Windows.Forms.Label surfaceIDlb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView toothList;
        private System.Windows.Forms.ComboBox surfaceID;
        private System.Windows.Forms.ComboBox toothID;
    }
}
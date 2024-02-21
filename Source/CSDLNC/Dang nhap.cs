using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLNC
{
    public partial class Form1 : Form
    {
 
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(inputLogin.Text);
            //MessageBox.Show(inputPassword.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SystemUser WHERE Username=@username", con);
            cmd.Parameters.AddWithValue("@username", inputLogin.Text);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    MessageBox.Show("Tài khoản không có trong hệ thống");
                    
                }
                if ((string)reader["Password"] != inputPassword.Text)
                {
                    MessageBox.Show("Sai mật khẩu");
                }
                string loaiTaiKhoan = reader["LoaiTaiKhoan"].ToString().Trim();
                
                if (loaiTaiKhoan == "admin")
                {                    
                    QuanTriVien qtvForm = new QuanTriVien((string)reader["UserID"]);
                    qtvForm.Show();
                }
                else if (loaiTaiKhoan == "staff")
                {
                    NhanVien nvForm = new NhanVien();
                    nvForm.Show();
                }
                else if (loaiTaiKhoan == "dentist")
                {
                    Nhasi nsForm = new Nhasi();
                    nsForm.Show();
                }
                else
                {
                    MessageBox.Show("Loại tài khoản không xác định!");
                }

            }
            con.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 dangkyForm = new Form2();
            dangkyForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

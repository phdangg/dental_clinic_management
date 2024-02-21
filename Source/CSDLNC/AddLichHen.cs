using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CSDLNC
{
    public partial class AddLichHen : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        private string DentistIDSelected = "";
        private void refreshDataGrid(string tableName)
        {
            con.Open();
            string query = $"SELECT * FROM {tableName}";
            if (tableName == "Dentist") query = $"SELECT UserID,SysUserName,SysUserGender FROM SystemUser WHERE LoaiTaiKhoan='dentist   '";
            else if (tableName == "WorkingCalendar" && this.DentistIDSelected != "") query = $"SELECT DentistID,MonthBegin,MonthEnd FROM WorkingCalendar WHERE DentistID='{this.DentistIDSelected}'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (tableName == "Dentist")
                dataGridView1.DataSource = dt;
            else if (tableName == "WorkingCalendar")
                dataGridView2.DataSource = dt;


            con.Close();
        }
        public AddLichHen()
        {
            InitializeComponent();
            refreshDataGrid("Dentist");
            addRoomCombox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Appointment(AppointmentID,AppointmentDate, RoomID, DentistID,PatientID) VALUES (@AppointmentID,@AppointmentDate,@RoomID,@DentistID,@PatientID)", con);
                cmd.Parameters.AddWithValue("@AppointmentID", getNewID("Appointment", "AppointmentID"));
                cmd.Parameters.AddWithValue("@AppointmentDate", apDateBox.Text);
                cmd.Parameters.AddWithValue("@RoomID", roomCombox.Text);
                cmd.Parameters.AddWithValue("@DentistID", DentistIDSelected);
                cmd.Parameters.AddWithValue("@PatientID", pIDBox.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm lịch hẹn thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể thêm lịch hẹn");
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            dNameBox.Text = dataGridView1.Rows[e.RowIndex].Cells["SysUserName"].Value.ToString();            
            DentistIDSelected = dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            refreshDataGrid("WorkingCalendar");


        }

        private void addRoomCombox()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Room", con);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {                

                while (reader.Read())
                {
                    roomCombox.Items.Add(reader["RoomID"].ToString());
                    
                }
            }
            con.Close();
        }
        private void roomCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public string getNewID(string tableName, string idField)
        {
            string query = $"SELECT TOP 1 * FROM {tableName} ORDER BY {idField} DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            int result = cmd.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.Read()) return "";

                string currUserID = reader[idField].ToString();

                int index = 0;
                while (index < currUserID.Length && char.IsLetter(currUserID[index]))
                {
                    index++;
                }

                string letters = currUserID.Substring(0, index);


                // Extract numbers (suffix)
                string numbersString = currUserID.Substring(2);
                int numbers = int.Parse(numbersString) + 1;

                return letters + numbers;
            }

        }
    }
}

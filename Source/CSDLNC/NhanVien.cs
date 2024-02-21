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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;

namespace CSDLNC
{
    public partial class NhanVien : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        private string currNVID = "";
        private string PatientIDSelected = "";
        private string DentistIDSelected = "";
        private string AppointmentIDSelected = "";
        private string StaffIDSelected = "";
        private void refreshDataGrid(string tableName)
        {
            con.Open();
            string query = $"SELECT * FROM {tableName}";
            if (tableName == "Dentist") query = $"SELECT UserID,SysUserName,SysUserGender FROM SystemUser WHERE LoaiTaiKhoan='dentist   '";
            else if (tableName == "Staff") query = $"SELECT UserID,SysUserName,SysUserGender FROM SystemUser WHERE LoaiTaiKhoan='staff     '";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (tableName == "PatientProfile")
                dataGridView1.DataSource = dt;
            else if (tableName == "Dentist")
            {
                dataGridView2.DataSource = dt;
                dataGridView4.DataSource = dt;
                dataGridView5.DataSource = dt;
            }
            else if (tableName == "Staff")
                dataGridView3.DataSource = dt;
            else if (tableName == "Appointment")
                dataGridView6.DataSource = dt;

            con.Close();
        }
        private void intializeTTCaNhanTab()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SystemUser WHERE UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", this.currNVID);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    MessageBox.Show("Tài khoản không có trong hệ thống");
                }
                currIDBox.Text = this.currNVID;
                currUsernameBox.Text = (string)reader["Username"];
                currPasswordBox.Text = (string)reader["Password"];
                currNameBox.Text = (string)reader["SysUserName"];
                currGenderBox.Text = (string)reader["SysUserGender"];
                currUserTypeBox.Text = (string)reader["LoaiTaiKhoan"];
            }
            con.Close();

        }
        public NhanVien(string currNVID = "US101") // Nho doi cai nay
        {
            InitializeComponent();
            refreshDataGrid("PatientProfile");
            refreshDataGrid("Dentist");
            refreshDataGrid("Appointment");
            refreshDataGrid("Staff");
            this.currNVID = currNVID;
            intializeTTCaNhanTab();
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
        private void deleteRow(string tableName, string idField)
        {
            con.Open();
            string id = "";
            if (tableName == "PatientProfile")
                id = this.PatientIDSelected;
            else if (tableName == "Dentist")
            {
                id = this.DentistIDSelected;
                tableName = "SystemUser";
                idField = "UserID";
            }
            else if (tableName == "Staff")
            {
                id = this.StaffIDSelected;
                tableName = "SystemUser";
                idField = "UserID";
            }

            try
            {
                string query = $"DELETE {tableName} WHERE {idField}=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể xóa");
                con.Close();
            }
        }
        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            pNameBox.Text = dataGridView1.Rows[e.RowIndex].Cells["PatientName"].Value.ToString();
            pComboGenBox.Text = dataGridView1.Rows[e.RowIndex].Cells["PatientGender"].Value.ToString();
            pAddressBox.Text = dataGridView1.Rows[e.RowIndex].Cells["PatientAddress"].Value.ToString();
            pDOBBox.Text = dataGridView1.Rows[e.RowIndex].Cells["PatientDOB"].Value.ToString();
            pEmailBox.Text = dataGridView1.Rows[e.RowIndex].Cells["PatientEmail"].Value.ToString();
            pPhoneBox.Text = dataGridView1.Rows[e.RowIndex].Cells["PatientPhoneNum"].Value.ToString();

            PatientIDSelected = dataGridView1.Rows[e.RowIndex].Cells["PatientID"].Value.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO PatientProfile(PatientID, PatientName,PatientGender,PatientAddress,PatientDOB,PatientEmail,PatientPhoneNum) VALUES(@PatientID,@PatientName,@PatientGender,@PatientAddress,@PatientDOB,@PatientEmail,@PatientPhoneNum)", con);
                cmd.Parameters.AddWithValue("@PatientID", getNewID("PatientProfile", "PatientID"));
                cmd.Parameters.AddWithValue("@PatientName", pNameBox.Text);
                cmd.Parameters.AddWithValue("@PatientGender", pComboGenBox.Text);
                cmd.Parameters.AddWithValue("@PatientAddress", pAddressBox.Text);
                cmd.Parameters.AddWithValue("@PatientDOB", pDOBBox.Text);
                cmd.Parameters.AddWithValue("@PatientEmail", pEmailBox.Text);
                cmd.Parameters.AddWithValue("@PatientPhoneNum", pPhoneBox.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm bệnh nhân thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể thêm bệnh nhân");
                con.Close();
            }

            refreshDataGrid("PatientProfile");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            deleteRow("PatientProfile", "PatientID");
            refreshDataGrid("PatientProfile");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE PatientProfile SET PatientName=@PatientName, PatientGender=@PatientGender, PatientAddress=@PatientAddress,PatientDOB=@PatientDOB,PatientEmail=@PatientEmail,PatientPhoneNum=@PatientPhoneNum WHERE PatientID=@PatientID", con);
                cmd.Parameters.AddWithValue("@PatientID", this.PatientIDSelected);
                cmd.Parameters.AddWithValue("@PatientName", pNameBox.Text);
                cmd.Parameters.AddWithValue("@PatientGender", pComboGenBox.Text);
                cmd.Parameters.AddWithValue("@PatientAddress", pAddressBox.Text);
                cmd.Parameters.AddWithValue("@PatientDOB", pDOBBox.Text);
                cmd.Parameters.AddWithValue("@PatientEmail", pEmailBox.Text);
                cmd.Parameters.AddWithValue("@PatientPhoneNum", pPhoneBox.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thông tin thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể sửa thông tin");
                con.Close();
            }

            refreshDataGrid("PatientProfile");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.CurrentRow.Selected = true;
            sNameBox.Text = dataGridView3.Rows[e.RowIndex].Cells["SysUserName"].Value.ToString();
            sGenderBox.Text = dataGridView3.Rows[e.RowIndex].Cells["SysUserGender"].Value.ToString();
            StaffIDSelected = dataGridView3.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            sIDBox.Text = StaffIDSelected;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            dName.Text = dataGridView2.Rows[e.RowIndex].Cells["SysUserName"].Value.ToString();
            dGender.Text = dataGridView2.Rows[e.RowIndex].Cells["SysUserGender"].Value.ToString();
            DentistIDSelected = dataGridView2.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            dID.Text = DentistIDSelected;
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE SystemUser SET Username=@Username,Password=@Password,SysUserName=@fullname, SysUserGender=@gender WHERE UserID=@userID", con);
                cmd.Parameters.AddWithValue("@userID", this.currNVID);
                cmd.Parameters.AddWithValue("@Username", currUsernameBox.Text);
                cmd.Parameters.AddWithValue("@Password", currPasswordBox.Text);
                cmd.Parameters.AddWithValue("@fullname", currNameBox.Text);
                cmd.Parameters.AddWithValue("@gender", currGenderBox.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thông tin thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể sửa thông tin");
                con.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }       


        private void button1_Click_1(object sender, EventArgs e)
        {
            AddLichHen formAddLichHen = new AddLichHen();
            formAddLichHen.Show();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView6.CurrentRow.Selected = true;
            apDateBox.Text = dataGridView6.Rows[e.RowIndex].Cells["AppointmentDate"].Value.ToString();
            apStatusBox.Text = dataGridView6.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            apRoomBox.Text = dataGridView6.Rows[e.RowIndex].Cells["RoomID"].Value.ToString();
            apDentistBox.Text = dataGridView6.Rows[e.RowIndex].Cells["DentistID"].Value.ToString();
            apPatientBox.Text = dataGridView6.Rows[e.RowIndex].Cells["PatientID"].Value.ToString();

            AppointmentIDSelected = dataGridView6.Rows[e.RowIndex].Cells["AppointmentID"].Value.ToString();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            deleteRow("Appointment", "AppointmentID");
            refreshDataGrid("Appointment");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateAppointment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AppointmentID", this.AppointmentIDSelected);
                    cmd.Parameters.AddWithValue("@Status", apStatusBox.Text);
                    cmd.Parameters.AddWithValue("@RoomID", apRoomBox.Text);
                    cmd.Parameters.AddWithValue("@DentistID", apDentistBox.Text);
                    cmd.Parameters.AddWithValue("@PatientID", apPatientBox.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa thông tin thành công");
                    refreshDataGrid("Appointment");
                }

                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể sửa thông tin");
                con.Close();
            }
        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView4.CurrentRow.Selected = true;
            dNameBCDT.Text = dataGridView4.Rows[e.RowIndex].Cells["SysUserName"].Value.ToString();
            DentistIDSelected = dataGridView4.Rows[e.RowIndex].Cells["UserID"].Value.ToString();           
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(fromDate.Text);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DateTime from = fromDate.Value;
            DateTime to = toDate.Value;
            if (from > to)
            {
                MessageBox.Show("Thời gian không hợp lệ");
                return;
            }

            try
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TreatmentPlan TP JOIN Treatment_TreatmentPlan TTP ON TP.TreatmentPlanID = TTP.TreatmentPlanID WHERE TP.DentistID = @DentistID AND @fromDate <= TTP.TreatingDate AND TTP.TreatingDate <= @toDate;", con))
                {
                    cmd.Parameters.AddWithValue("@DentistID", DentistIDSelected);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView7.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Unable to retrieve treatment plans\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView5.CurrentRow.Selected = true;
            dNameBCCH.Text = dataGridView4.Rows[e.RowIndex].Cells["SysUserName"].Value.ToString();
            DentistIDSelected = dataGridView4.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime from = from2.Value;
            DateTime to = to2.Value;
            if (from > to)
            {
                MessageBox.Show("Thời gian không hợp lệ");
                return;
            }

            try
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Appointment WHERE DentistID=@DentistID AND @fromDate <= AppointmentDate AND AppointmentDate <= @toDate;", con))
                {
                    cmd.Parameters.AddWithValue("@DentistID", DentistIDSelected);
                    cmd.Parameters.AddWithValue("@fromDate", from);
                    cmd.Parameters.AddWithValue("@toDate", to);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView8.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Unable to retrieve treatment plans\n" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            BenhNhanEdit bnEditForm = new BenhNhanEdit(this.PatientIDSelected);
            bnEditForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lichlamviec lichForm = new Lichlamviec(this.DentistIDSelected);
            lichForm.Show();
        }
    }
}

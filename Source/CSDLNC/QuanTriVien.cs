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
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace CSDLNC
{
    public partial class QuanTriVien : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        private string currQTVID = "";
        private string userIDSelected = "";
        private string MedicineIDSelected = "";
        private string PatientIDSelected = "";
        private string DentistIDSelected = "";
        private string StaffIDSelected = "";
        private string AppointmentIDSelected = "";
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

            if (tableName == "SystemUser")
                dataGridView1.DataSource = dt;
            else if (tableName == "Medicine")
                dataGridView2.DataSource = dt;
            else if (tableName == "PatientProfile")
                dataGridView3.DataSource = dt;
            else if(tableName == "Dentist")
                dataGridView4.DataSource = dt;
            else if(tableName == "Staff")
                dataGridView5.DataSource = dt;
            else if (tableName == "Appointment")
                dataGridView6.DataSource = dt;


            con.Close();
        }
        private void intializeTTCaNhanTab()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SystemUser WHERE UserID=@UserID", con);
            cmd.Parameters.AddWithValue("@UserID", this.currQTVID);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    MessageBox.Show("Tài khoản không có trong hệ thống");
                }
                currIDBox.Text = this.currQTVID;
                currUsernameBox.Text = (string)reader["Username"];
                currPasswordBox.Text = (string)reader["Password"];
                currNameBox.Text = (string)reader["SysUserName"];
                currGenderBox.Text = (string)reader["SysUserGender"];
                currUserTypeBox.Text = (string)reader["LoaiTaiKhoan"];
            }
            con.Close();

        }
        public QuanTriVien(string currQTVID="US101") // Nho doi cai nay
        {
            InitializeComponent();            
            refreshDataGrid("Medicine");
            refreshDataGrid("SystemUser");
            refreshDataGrid("PatientProfile");
            refreshDataGrid("Dentist");
            refreshDataGrid("Staff");
            refreshDataGrid("Appointment");
            this.currQTVID = currQTVID.Trim();
            intializeTTCaNhanTab();
        }

        private void button2_Click(object sender, EventArgs e)
        {
  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //caifen
            dataGridView1.CurrentRow.Selected = true;
            usernameBox.Text = dataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString();
            passwordBox.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();
            fullnameBox.Text = dataGridView1.Rows[e.RowIndex].Cells["SysUserName"].Value.ToString();
            comboGenderBox.Text = dataGridView1.Rows[e.RowIndex].Cells["SysUserGender"].Value.ToString();
            comboUserTypeBox.Text = dataGridView1.Rows[e.RowIndex].Cells["LoaiTaiKhoan"].Value.ToString();

            userIDSelected = dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void typeUserBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
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
        private void deleteRow(string tableName, string idField)
        {
            con.Open();
            string id = "";
            if (tableName == "SystemUser")
                id = this.userIDSelected;
            else if (tableName == "Medicine")
                id = this.MedicineIDSelected;
            else if (tableName == "PatientProfile")
                id = this.PatientIDSelected;
            else if (tableName == "Appointment")
                id = this.AppointmentIDSelected;
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

        private void button17_Click(object sender, EventArgs e)
        {
            con.Open();            
            try
            {
                
                using (SqlCommand cmd = new SqlCommand("sp_InsertSystemUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userID", getNewID("SystemUser", "UserID"));

                    cmd.Parameters.AddWithValue("@username", usernameBox.Text);
                    cmd.Parameters.AddWithValue("@password", passwordBox.Text);
                    cmd.Parameters.AddWithValue("@fullname", fullnameBox.Text);
                    cmd.Parameters.AddWithValue("@gender", comboGenderBox.Text);
                    cmd.Parameters.AddWithValue("@userType", comboUserTypeBox.Text);        
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể thêm tài khoản");
                con.Close();
            }

            refreshDataGrid("SystemUser");

        }

        private void button18_Click(object sender, EventArgs e)
        {
            deleteRow("SystemUser", "UserID");
            refreshDataGrid("SystemUser");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateSystemUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@userID", this.userIDSelected);
                    cmd.Parameters.AddWithValue("@fullname", fullnameBox.Text);
                    cmd.Parameters.AddWithValue("@gender", comboGenderBox.Text);

                    // Add OUTPUT parameter for result
                    SqlParameter resultParam = new SqlParameter("@result", SqlDbType.NVarChar, 50);
                    resultParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(resultParam);

                    cmd.ExecuteNonQuery();

                    // Retrieve the result
                    string result = resultParam.Value.ToString();
                    MessageBox.Show(result);
                }
            }
            catch
            {
                MessageBox.Show("Error: Unable to update information");
            }
            finally
            {
                con.Close();
            }

            refreshDataGrid("SystemUser");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateMedicine", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MedicineID", this.MedicineIDSelected);
                    cmd.Parameters.AddWithValue("@MedicineName", nameThuocBox.Text);
                    cmd.Parameters.AddWithValue("@MedicinePrice", Convert.ToDouble(thuocPriceBox.Text));
                    cmd.Parameters.AddWithValue("@MedicineDescription", desBox.Text);

                    cmd.ExecuteNonQuery();

                    // Retrieve the result
                    MessageBox.Show("Sửa thuốc thông tin thành công");
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể sửa thông tin thuốc");
                con.Close();
            }

            refreshDataGrid("Medicine");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true;
            nameThuocBox.Text = dataGridView2.Rows[e.RowIndex].Cells["MedicineName"].Value.ToString();
            thuocPriceBox.Text = dataGridView2.Rows[e.RowIndex].Cells["MedicinePrice"].Value.ToString();
            desBox.Text = dataGridView2.Rows[e.RowIndex].Cells["MedicineDescription"].Value.ToString();
 
            MedicineIDSelected = dataGridView2.Rows[e.RowIndex].Cells["MedicineID"].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertMedicine", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MedicineID", getNewID("Medicine", "MedicineID"));
                    cmd.Parameters.AddWithValue("@MedicineName", nameThuocBox.Text);
                    cmd.Parameters.AddWithValue("@MedicinePrice", Convert.ToDouble(thuocPriceBox.Text));
                    cmd.Parameters.AddWithValue("@MedicineDescription", desBox.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thuốc thành công");
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể thêm thuốc");
                con.Close();
            }

            refreshDataGrid("Medicine");
        }
        
        private void button20_Click(object sender, EventArgs e)
        {
            deleteRow("Medicine", "MedicineID");
            refreshDataGrid("Medicine");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.CurrentRow.Selected = true;
            pNameBox.Text = dataGridView3.Rows[e.RowIndex].Cells["PatientName"].Value.ToString();
            pComboGenBox.Text = dataGridView3.Rows[e.RowIndex].Cells["PatientGender"].Value.ToString();
            pAddressBox.Text = dataGridView3.Rows[e.RowIndex].Cells["PatientAddress"].Value.ToString();
            pDOBBox.Text = dataGridView3.Rows[e.RowIndex].Cells["PatientDOB"].Value.ToString();
            pEmailBox.Text = dataGridView3.Rows[e.RowIndex].Cells["PatientEmail"].Value.ToString();
            pPhoneBox.Text = dataGridView3.Rows[e.RowIndex].Cells["PatientPhoneNum"].Value.ToString();

            PatientIDSelected = dataGridView3.Rows[e.RowIndex].Cells["PatientID"].Value.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPatientProfile", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientID", getNewID("PatientProfile", "PatientID"));

                    cmd.Parameters.AddWithValue("@PatientName", pNameBox.Text);
                    cmd.Parameters.AddWithValue("@PatientGender", pComboGenBox.Text);
                    cmd.Parameters.AddWithValue("@PatientAddress", pAddressBox.Text);
                    cmd.Parameters.AddWithValue("@PatientDOB", pDOBBox.Text); // Assuming pDOBBox.Text contains a valid date
                    cmd.Parameters.AddWithValue("@PatientEmail", pEmailBox.Text);
                    cmd.Parameters.AddWithValue("@PatientPhoneNum", pPhoneBox.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm bệnh nhân thành công");
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể thêm bệnh nhân");
                con.Close();
            }

            refreshDataGrid("PatientProfile");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdatePatientProfile", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientID", this.PatientIDSelected);
                    cmd.Parameters.AddWithValue("@PatientName", pNameBox.Text);
                    cmd.Parameters.AddWithValue("@PatientGender", pComboGenBox.Text);
                    cmd.Parameters.AddWithValue("@PatientAddress", pAddressBox.Text);
                    cmd.Parameters.AddWithValue("@PatientDOB", pDOBBox.Text); // Assuming pDOBBox.Text contains a valid date
                    cmd.Parameters.AddWithValue("@PatientEmail", pEmailBox.Text);
                    cmd.Parameters.AddWithValue("@PatientPhoneNum", pPhoneBox.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa thông tin thành công");
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể sửa thông tin");
                con.Close();
            }

            refreshDataGrid("PatientProfile");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            deleteRow("PatientProfile", "PatientID");
            refreshDataGrid("PatientProfile");
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void pDOBBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pEmailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void pPhoneBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            BenhNhanEdit bnEditForm = new BenhNhanEdit(this.PatientIDSelected);
            bnEditForm.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView4.CurrentRow.Selected = true;
            dName.Text = dataGridView4.Rows[e.RowIndex].Cells["SysUserName"].Value.ToString();
            dGender.Text = dataGridView4.Rows[e.RowIndex].Cells["SysUserGender"].Value.ToString();       
            DentistIDSelected = dataGridView4.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            dID.Text = DentistIDSelected;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteRow("Dentist", "DentistID");
            refreshDataGrid("Dentist");
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void updateInfoUser(string tableName)
        {
            string id="",name = "", gender = "";

            if (tableName == "Dentist")
            {
                id = this.DentistIDSelected;
                name = dName.Text;
                gender = dGender.Text;
            }
            else if (tableName== "Staff")
            {
                id = this.StaffIDSelected;
                name = sNameBox.Text;
                gender = sGenderBox.Text;
            }
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE SystemUser SET SysUserName=@fullname, SysUserGender=@gender WHERE UserID=@userID", con);
                cmd.Parameters.AddWithValue("@userID", id);
                cmd.Parameters.AddWithValue("@fullname", name);
                cmd.Parameters.AddWithValue("@gender", gender);
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


        private void button6_Click(object sender, EventArgs e)
        {
            updateInfoUser("Dentist");
            refreshDataGrid("Dentist");
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView5.CurrentRow.Selected = true;
            sNameBox.Text = dataGridView5.Rows[e.RowIndex].Cells["SysUserName"].Value.ToString();
            sGenderBox.Text = dataGridView5.Rows[e.RowIndex].Cells["SysUserGender"].Value.ToString();
            StaffIDSelected = dataGridView5.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            sIDBox.Text = StaffIDSelected;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            deleteRow("Staff", "StaffID");
            refreshDataGrid("Staff");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            updateInfoUser("Staff");
            refreshDataGrid("Staff");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateProfileSystemUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@userID", this.currQTVID);
                    cmd.Parameters.AddWithValue("@Username", currUsernameBox.Text);
                    cmd.Parameters.AddWithValue("@Password", currPasswordBox.Text);
                    cmd.Parameters.AddWithValue("@fullname", currNameBox.Text);
                    cmd.Parameters.AddWithValue("@gender", currGenderBox.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa thông tin thành công");
                }
                
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể sửa thông tin");
                con.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            deleteRow("Appointment", "AppointmentID");
            refreshDataGrid("Appointment");
        }

        private void button7_Click_1(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Lichlamviec lichForm = new Lichlamviec(this.DentistIDSelected);
            lichForm.Show();  
        }
    }
}

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
    public partial class KHDT : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");

        private string PatientID = "";
        private string TreatmentPlanID = "";
        private void refreshDataGrid(string tableName)
        {
            con.Open();
            string query = $"SELECT * FROM {tableName} WHERE PatientID=@PatientID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PatientID", this.PatientID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
            addDentistCombox();
        }
        public KHDT(string PatientID="TP101")
        {
            InitializeComponent();
            this.PatientID = PatientID;
            refreshDataGrid("TreatmentPlan");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private string getName(string key, string table, string field, string returnField)
        {
            con.Open();
            string value = "Invalid data";
            string query = $"SELECT * FROM {table} WHERE {field} = @keyValue";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@keyValue", key);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                 value = dt.Rows[0][returnField].ToString();

            }
           

            con.Close();
            return value;
        }

        private string getDentistName(string dentistID)
        {
           

            return getName(dentistID, "SystemUser", "UserID", "SysUserName");
        }
        private string getPatientName(string patientID)
        {
            return getName(patientID, "PatientProfile", "PatientID", "PatientName");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            this.TreatmentPlanID = dataGridView1.Rows[e.RowIndex].Cells["TreatmentPlanID"].Value.ToString();
            this.PatientID = dataGridView1.Rows[e.RowIndex].Cells["PatientID"].Value.ToString();
            tpPlanID.Text = this.TreatmentPlanID;
            tpDentistID.Text = dataGridView1.Rows[e.RowIndex].Cells["DentistID"].Value.ToString();
            tpDentistName.Text = getDentistName(dataGridView1.Rows[e.RowIndex].Cells["DentistID"].Value.ToString());
            tpPatient.Text = getPatientName(dataGridView1.Rows[e.RowIndex].Cells["PatientID"].Value.ToString());
            tpPaymentStatus.Text = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DT treatingListForm = new DT(this.TreatmentPlanID);
            treatingListForm.Show();
        }

        private void addDentistCombox()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Dentist", con);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    tpDentistID.Items.Add(reader["DentistID"].ToString());

                }
            }
            con.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TreatmentPlan(TreatmentPlanID,DentistID,PatientID) VALUES(@TreatmentPlanID,@DentistID,@PatientID)", con);
                cmd.Parameters.AddWithValue("@TreatmentPlanID", getNewID("TreatmentPlan", "TreatmentPlanID"));
                cmd.Parameters.AddWithValue("@DentistID", tpDentistID.Text);
                cmd.Parameters.AddWithValue("@PatientID", this.PatientID);
              
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm Kế hoạch điều trị thành công");
                
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể thêm Kế hoạch điều trị mới");
                con.Close();
            }

            refreshDataGrid("TreatmentPlan");
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

                MessageBox.Show(letters + numbers);
                return letters + numbers;
            }

        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            deleteRow("TreatmentPlan", "TreatmentPlanID", this.TreatmentPlanID);
        }

        private void deleteRow(string tableName, string field, string key)
        {
            con.Open();
            try
            {
                string query = $"DELETE FROM {tableName} WHERE {field} = @key";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@key", key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể xóa");
                con.Close();
            }
            refreshDataGrid("TreatmentPlan");
        }

        private void adjustBtn_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                string query = "UPDATE TreatmentPlan SET DentistID=@DentistID,Status=@Status WHERE TreatmentPlanID=@TreatmentPlanID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TreatmentPlanID", this.TreatmentPlanID);
                cmd.Parameters.AddWithValue("@DentistID", tpDentistID.Text);
                cmd.Parameters.AddWithValue("@Status", tpPaymentStatus.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Cập nhật thất bại");
                con.Close();
            }

            refreshDataGrid("TreatmentPlan");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

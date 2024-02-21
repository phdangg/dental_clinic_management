using System;
using System.Collections.Generic;
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
    public partial class DT : Form
    {
        private string TreatmentPlanID = "";
        private string TreatingID = "";
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        public DT(string TreatmentPlanID)
        {
            InitializeComponent();
            this.TreatmentPlanID = TreatmentPlanID;
            refreshDataGrid("Treatment_TreatmentPlan");
            loadTreatmentCombox();
        }

        private void refreshDataGrid(string tableName)
        {
            con.Open();
            string query = $"SELECT * FROM {tableName} WHERE TreatmentPlanID=@TreatmentPlanID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TreatmentPlanID", this.TreatmentPlanID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            treatingList.DataSource = dt;


            con.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treatingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            treatingList.CurrentRow.Selected = true;
            treatmentID.Text = treatingList.Rows[e.RowIndex].Cells["TreatmentID"].Value.ToString();
            treatmentName.Text = getTreatmentName(treatingList.Rows[e.RowIndex].Cells["TreatmentID"].Value.ToString());
            treatingDate.Text = treatingList.Rows[e.RowIndex].Cells["TreatingDate"].Value.ToString();
            treatmentCategory.Text = getCategoryName(treatingList.Rows[e.RowIndex].Cells["TreatmentID"].Value.ToString());
            treatingFee.Text = treatingList.Rows[e.RowIndex].Cells["TreatingFee"].Value.ToString();
            treatingPayment.Text = treatingList.Rows[e.RowIndex].Cells["Paymentstatus"].Value.ToString();
            this.TreatingID = treatingList.Rows[e.RowIndex].Cells["TreatingID"].Value.ToString();
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

            if (dt.Rows.Count > 0)
            {
                value = dt.Rows[0][returnField].ToString();

            }


            con.Close();
            return value;
        }

        private string getTreatmentName(string treatmentID)
        {
            return getName(treatmentID, "Treatment", "TreatmentID", "TreatmentName");
        }

        private string getCategoryName(string treatmentID)
        {
            con.Open();
            string categoryID="";
            
            string query = $"SELECT * FROM Treatment WHERE TreatmentID=@TreatmentID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TreatmentID", treatmentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                categoryID = dt.Rows[0]["CategoryID"].ToString();
             
            }

            con.Close();

            return getName(categoryID, "TreatmentCategory", "CategoryID", "CategoryName");
        }

        private void viewToothbtn_Click(object sender, EventArgs e)
        {
            Tooth toothForm = new Tooth(this.TreatingID);
            toothForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                string query = "INSERT INTO Treatment_TreatmentPlan(TreatingID,TreatmentID,TreatmentPlanID, TreatingDate, TreatingFee) VALUES(@TreatingID, @TreatmentID, @TreatmentPlanID,@TreatingDate,@TreatingFee)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TreatingID", getNewID("Treatment_TreatmentPlan", "TreatingID"));
                cmd.Parameters.AddWithValue("@TreatmentID", treatmentID.Text);
                cmd.Parameters.AddWithValue("@TreatmentPlanID", this.TreatmentPlanID);
                cmd.Parameters.AddWithValue("@TreatingDate", "2023-01-01");
                cmd.Parameters.AddWithValue("@TreatingFee", 1f);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể thêm điều trị");
                con.Close();
            }

            refreshDataGrid("Treatment_TreatmentPlan");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void treatmentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadTreatmentCombox()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Treatment", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    treatmentID.Items.Add(reader["TreatmentID"].ToString());
                }
            }

            con.Close();
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
                string numbersString = currUserID.Substring(1);
                int numbers = int.Parse(numbersString) + 1;
                return letters + numbers;
            }

        }

        private void adjustBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string query = "UPDATE Treatment_TreatmentPlan SET TreatmentID=@TreatmentID,TreatingFee=@TreatingFee,PaymentStatus=@PaymentStatus WHERE TreatingID=@TreatingID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TreatmentID", treatmentID.Text);
                cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);
                cmd.Parameters.AddWithValue("@TreatingFee", float.Parse(treatingFee.Text));
                cmd.Parameters.AddWithValue("@PaymentStatus", treatingPayment.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại");
                con.Close();
            }

            refreshDataGrid("Treatment_TreatmentPlan");
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                string query = "DELETE FROM Treatment_TreatmentPlan WHERE TreatingID=@TreatingID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể xóa");
                con.Close();
            }
            refreshDataGrid("Treatment_TreatmentPlan");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

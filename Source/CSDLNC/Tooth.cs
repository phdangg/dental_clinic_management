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
    public partial class Tooth : Form
    {
        private string TreatingID = "";
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        private string toothIDcurr = "";
        private string surfaceIDcurr = "";

        public Tooth(string treatingID)
        {
            InitializeComponent();
            this.TreatingID = treatingID;
            loadSurfaceCombox();
            loadToothIDCombox();
            refreshDataGrid("Treating_Tooth");
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private string getToothName(string toothID)
        {

            return getName(toothID, "Tooth", "ToothID", "ToothName");
        }

        private string getToothSurfaceName(string toothSurfaceID)
        {
            return getName(toothSurfaceID, "ToothSurface", "ToothSurfaceID", "ToothSurfaceName");
        }

        private string getToothSurfaceDes(string toothSurfaceID)
        {
            return getName(toothSurfaceID, "ToothSurface", "ToothSurfaceID", "ToothSurfaceDescription");
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

        private void refreshDataGrid(string tableName)
        {
            con.Open();
         
            string query = $"SELECT * FROM {tableName} WHERE TreatingID=@TreatingID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            toothList.DataSource = dt;


            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            toothList.CurrentRow.Selected = true;
            this.toothIDcurr = toothList.Rows[e.RowIndex].Cells["ToothID"].Value.ToString();
            this.surfaceIDcurr = toothList.Rows[e.RowIndex].Cells["ToothSurfaceID"].Value.ToString();
            toothID.Text = toothIDcurr;
            toothName.Text = getToothName(toothList.Rows[e.RowIndex].Cells["ToothID"].Value.ToString());
            surfaceID.Text = surfaceIDcurr;
            surfaceName.Text = getToothSurfaceName(toothList.Rows[e.RowIndex].Cells["ToothSurfaceID"].Value.ToString());
            surfaceDescription.Text = getToothSurfaceDes(toothList.Rows[e.RowIndex].Cells["ToothSurfaceID"].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                string query = "INSERT INTO Treating_Tooth(TreatingID, ToothID, ToothSurfaceID) VALUES(@TreatingID,@ToothID,@ToothSurfaceID)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);
                cmd.Parameters.AddWithValue("@ToothID", toothID.Text);
                cmd.Parameters.AddWithValue("@ToothSurfaceID", surfaceID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Thêm thất bại");
                con.Close();
            }
            refreshDataGrid("Treating_Tooth");
        }

        private void loadToothIDCombox()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tooth", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    toothID.Items.Add(reader["ToothID"].ToString());
                }
            }

            con.Close();
        }

        private void loadSurfaceCombox()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ToothSurface", con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    surfaceID.Items.Add(reader["ToothSurfaceID"].ToString());
                }
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                string query = "UPDATE Treating_Tooth SET ToothSurfaceID=@ToothSurfaceID, ToothID=@ToothID WHERE ToothSurfaceID=@surfaceIDcurr AND ToothID=@toothIDcurr AND TreatingID=@TreatingID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);
                cmd.Parameters.AddWithValue("@surfaceIDcurr", this.surfaceIDcurr);
                cmd.Parameters.AddWithValue("@toothIDcurr", this.toothIDcurr);
                cmd.Parameters.AddWithValue("@ToothSurfaceID", surfaceID.Text);
                cmd.Parameters.AddWithValue("@ToothID", toothID.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Cập nhật thất bại");
                con.Close();
            }
            refreshDataGrid("Treating_Tooth");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                string query = "DELETE FROM Treating_Tooth WHERE ToothSurfaceID=@surfaceIDcurr AND ToothID=@toothIDcurr AND TreatingID=@TreatingID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);
                cmd.Parameters.AddWithValue("@surfaceIDcurr", this.surfaceIDcurr);
                cmd.Parameters.AddWithValue("@toothIDcurr", this.toothIDcurr);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Không thể xóa");
                con.Close();
            }
            refreshDataGrid("Treating_Tooth");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

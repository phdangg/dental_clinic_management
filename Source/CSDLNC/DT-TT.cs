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
using System.Xml.Linq;

namespace CSDLNC
{
    public partial class DT_TT : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        private string TreatingID = "";
        public DT_TT(string TreatingID = "P1001")
        {
            InitializeComponent();
            this.TreatingID = TreatingID;
            loadData();
        }

        private void DT_TT_Load(object sender, EventArgs e)
        {

        }
        private void loadData()
        {
            con.Open();            
            
            // LOAD DATA TREATMENT

            SqlCommand cmd = new SqlCommand("SELECT TreatmentName,Description,TreatmentFee,TreatingDate FROM Treatment_TreatmentPlan TTP JOIN Treatment T ON TTP.TreatmentID = T.TreatmentID WHERE TTP.TreatingID=@TreatingID", con);
            cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);           
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return;   
                }
                tmID.Text = reader["TreatmentName"].ToString();
                tmDes.Text = reader["Description"].ToString();
                tmPrice.Text = reader["TreatmentFee"].ToString();
                tmDate.Text = reader["TreatingDate"].ToString();
            }
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            tmID.Text = dataGridView1.Rows[e.RowIndex].Cells["TreatmentName"].Value.ToString();
            tmDes.Text = dataGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            tmPrice.Text = dataGridView1.Rows[e.RowIndex].Cells["TreatmentFee"].Value.ToString();
            tmDate.Text = dataGridView1.Rows[e.RowIndex].Cells["TreatingDate"].Value.ToString();

        }
    }
}

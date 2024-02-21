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
    public partial class TT : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        private string TreatingID = "";
        public TT(string TreatingID = "P1001")
        {
            InitializeComponent();
            this.TreatingID = TreatingID;
            loadData();
        }
        
        private void loadData()
        {
            con.Open();
            // LOAD PATIENT NAME AND DENTIST NAME
            SqlCommand cmd = new SqlCommand("SELECT * FROM Treatment_TreatmentPlan TTP JOIN TreatmentPlan TP ON TTP.TreatmentPlanID = TP.TreatmentPlanID WHERE TTP.TreatingID=@TreatingID", con);
            cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    dName.Text = reader["DentistID"].ToString();
                    pName.Text = reader["PatientID"].ToString();
                }
                
            }
            // LOAD DATA TREATMENT
            
            cmd = new SqlCommand("SELECT T.TreatmentID,Description,TreatmentName,TreatmentFee,CategoryID FROM Treatment_TreatmentPlan TTP JOIN Treatment T ON TTP.TreatmentID = T.TreatmentID WHERE TTP.TreatingID=@TreatingID", con);
            cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);
            float totalTMPrice = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    totalTMPrice += float.Parse(reader["TreatmentFee"].ToString());
                }
            }
            tmPrice.Text = totalTMPrice.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // LOAD DATA TREATMENT-MEDICINE
            cmd = new SqlCommand("SELECT M.MedicineID,MedicineName,MedicinePrice,MedicineDescription FROM Treatment_TreatmentPlan TTP JOIN Treating_Medicine TM ON TTP.TreatingID = TM.TreatingID JOIN Medicine M ON M.MedicineID=TM.MedicineID WHERE TTP.TreatingID=@TreatingID", con);
            cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);
            float totalMPrice = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    totalMPrice += float.Parse(reader["MedicinePrice"].ToString());
                }
            }
            mPrice.Text = totalMPrice.ToString();
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            //LOAD DATA PAYMENT
            float sumPrice = totalMPrice + totalTMPrice;
            cmd = new SqlCommand("SELECT * FROM PaymentRecord WHERE TreatingID=@TreatingID",con);
            cmd.Parameters.AddWithValue("@TreatingID", this.TreatingID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    payDate.Text = reader["PaymentDate"].ToString();
                    payPaid.Text = reader["MoneyPaid"].ToString();
                    payChange.Text = reader["MoneyChange"].ToString();
                    totalPrice.Text = sumPrice.ToString();
                }

            }
            con.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DT_TT dtttForm = new DT_TT(this.TreatingID);
            dtttForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

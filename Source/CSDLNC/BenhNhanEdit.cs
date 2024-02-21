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
    public partial class BenhNhanEdit : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        private string currPatientID = "";
        private void intializeInfomation()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PatientProfile WHERE PatientID=@PatientID", con);
            cmd.Parameters.AddWithValue("@PatientID", this.currPatientID);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    MessageBox.Show("Bệnh nhân không có trong hệ thống");
                }
                pName.Text = reader["PatientName"].ToString();
                pGender.Text = reader["PatientGender"].ToString();
                pAddress.Text = reader["PatientAddress"].ToString();
                pDOB.Text = reader["PatientDOB"].ToString();
                pEmail.Text = reader["PatientEmail"].ToString();
                pPhone.Text = reader["PatientPhoneNum"].ToString();
                pTotalBill.Text = reader["TotalBill"].ToString();
                pTotalPayment.Text = reader["TotalPayment"].ToString();
                pTeethDes.Text = reader["TeethDescription"].ToString();
                pNote.Text = reader["Note"].ToString();
            }
            con.Close();
        }
        private void refreshDataGrid(string tableName)
        {
            con.Open();
            string query = $"SELECT * FROM {tableName} WHERE PatientID=@PatientID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PatientID", this.currPatientID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (tableName == "TreatmentPlan")
                dataGridView1.DataSource = dt;           
            

            con.Close();
        }
        private void refreshTT()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 P.Total,P.PaymentType,P.PaymentDate FROM Treatment_TreatmentPlan TTP JOIN TreatmentPlan TP ON TTP.TreatmentPlanID = TP.TreatmentPlanID JOIN PaymentRecord P ON P.TreatingID = TTP.TreatingID WHERE TP.PatientID=@PatientID", con);
            cmd.Parameters.AddWithValue("@PatientID", this.currPatientID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public BenhNhanEdit(string currPatientID = "PT101")
        {
            InitializeComponent();
            this.currPatientID = currPatientID;
            intializeInfomation();
            refreshDataGrid("TreatmentPlan");
            refreshTT();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE PatientProfile " +
                    "SET PatientName=@PatientName, PatientGender=@PatientGender, PatientAddress=@PatientAddress,PatientEmail=@PatientEmail,PatientPhoneNum=@PatientPhoneNum,TotalBill=@TotalBill,TotalPayment=@TotalPayment,TeethDescription=@TeethDescription,Note=@Note " +
                    "WHERE PatientID=@PatientID", con);
                cmd.Parameters.AddWithValue("@PatientID", this.currPatientID);
                cmd.Parameters.AddWithValue("@PatientName", pName.Text);
                cmd.Parameters.AddWithValue("@PatientGender", pGender.Text);
                cmd.Parameters.AddWithValue("@PatientAddress", pAddress.Text);
                //cmd.Parameters.AddWithValue("@PatientDOB", pDOB.Text);
                cmd.Parameters.AddWithValue("@PatientEmail", pEmail.Text);
                cmd.Parameters.AddWithValue("@PatientPhoneNum", pPhone.Text);
                cmd.Parameters.AddWithValue("@TotalBill", pTotalBill.Text);
                cmd.Parameters.AddWithValue("@TotalPayment", pTotalPayment.Text);
                cmd.Parameters.AddWithValue("@TeethDescription", pTeethDes.Text);
                cmd.Parameters.AddWithValue("@Note", pNote.Text);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            KHDT khdtForm = new KHDT(this.currPatientID);
            khdtForm.Show();
        }
        private string getTreatingID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 TreatingID FROM Treatment_TreatmentPlan TTP JOIN TreatmentPlan TP ON TTP.TreatmentPlanID = TP.TreatmentPlanID WHERE TP.PatientID=@PatientID", con);
            cmd.Parameters.AddWithValue("@PatientID", this.currPatientID);
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return "P1001";
                    }                
                    string treatingID = reader["TreatingID"].ToString();
                    con.Close();
                    return treatingID;
                
                
                }
            }
            catch
            {
                con.Close();
                return "P1001";
            }
            
        }
        private void button7_Click(object sender, EventArgs e)
        {
            TT ttForm = new TT(getTreatingID());
            ttForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

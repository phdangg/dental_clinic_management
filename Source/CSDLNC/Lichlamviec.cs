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
    public partial class Lichlamviec : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CSDLNC;Integrated Security=True");
        private string dentistID = "";
        private string workingCalID = "";
        public Lichlamviec(string dentistID="US100") //TESt
        {
            this.dentistID = dentistID;
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            con.Open();
            string query = "SELECT * FROM SystemUser WHERE UserID=@userID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userID", dentistID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                dentistIDbox.Text = dt.Rows[0]["UserID"].ToString();
                dentistName.Text = dt.Rows[0]["SysUserName"].ToString();
               
            }

            con.Close();
            getWorkingCal();
            getGridData();
        }

        private void getWorkingCal()
        {
            con.Open();
            string query = "SELECT * FROM WorkingCalendar WHERE DentistID=@dentistID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@dentistID", this.dentistID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                begin.Text = dt.Rows[0]["MonthBegin"].ToString();
                end.Text = dt.Rows[0]["MonthEnd"].ToString();
                workingCalID = dt.Rows[0]["WorkingCalendarID"].ToString();
            }

            con.Close();
        }

        private void getGridData()
        {
            con.Open();
            string query1 = "SELECT * FROM Cal_DayInMonth WHERE WorkingCalendarID=@calID";
            string query2 = "SELECT * FROM Cal_DayInWeek WHERE WorkingCalendarID=@calID";
            string query3 = "SELECT * FROM Cal_FreeDay WHERE WorkingCalendarID=@calID";

            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            SqlCommand cmd3 = new SqlCommand(query3, con);

            cmd1.Parameters.AddWithValue("@calID", workingCalID);
            cmd2.Parameters.AddWithValue("@calID", workingCalID);
            cmd3.Parameters.AddWithValue("@calID", workingCalID);


            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            monthlyGrid.DataSource = dt1;
            weeklyGrid.DataSource= dt2;
            freedayGrid.DataSource = dt3;

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
                string numbersString = currUserID.Substring(2);
                int numbers = int.Parse(numbersString) + 1;

                MessageBox.Show(letters + numbers);
                return letters + numbers;
            }

        }

        private void addNewDay(string table, string field, string value)
        {
            con.Open();
            try
            {
                string query = $"INSERT INTO {table}({field}, WorkingCalendarID) VALUES(@value, @calID)";
                SqlCommand cmd = new SqlCommand(query, con);
                if (table == "Cal_FreeDay")
                {
                    cmd.Parameters.AddWithValue("@value", value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@value", int.Parse(value));
                }
                cmd.Parameters.AddWithValue("@calID", this.workingCalID);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công");
                con.Close();
            }
            catch
            {

                MessageBox.Show("Lỗi: Thêm thất bại");
                con.Close();
            }

            getGridData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addNewDay("Cal_DayInMonth", "DayInMonth", dayInMonthBox.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addNewDay("Cal_DayInWeek", "DayInWeek", dayInWeekBox.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            addNewDay("Cal_FreeDay", "DayFree", freeDayBox.Text);
        }

        private void monthlyGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            monthlyGrid.CurrentRow.Selected = true;
        }

        private void deleteDay(string table)
        {
            con.Open();
            SqlCommand cmd;
            string query;
            int intValue;
            string strValue;
            string key;
            string field;
            if(table == "Cal_DayInMonth")
            {
                key = "DayInMonth";
                intValue = int.Parse(monthlyGrid.CurrentRow.Cells[key].Value.ToString());
                query = $"DELETE FROM {table} WHERE {key}=@value AND WorkingCalendarID=@calID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", intValue);
           
            }
            else if(table == "Cal_DayInWeek"){
                key = "DayInWeek";
                intValue = int.Parse(weeklyGrid.CurrentRow.Cells[key].Value.ToString());
                query = $"DELETE FROM {table} WHERE {key}=@value AND WorkingCalendarID=@calID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", intValue);
            }
            else
            {
                key = "DayFree";
                strValue = freedayGrid.CurrentRow.Cells[key].Value.ToString();
                query = $"DELETE FROM {table} WHERE {key}=@value AND WorkingCalendarID=@calID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", strValue);
            }
            cmd.Parameters.AddWithValue("@calID", this.workingCalID);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Xóa thất bại");
                con.Close();
            }

            getGridData();
        }

        private void updateDay(string table)
        {
            con.Open();
            SqlCommand cmd;
            string query;
            string currStrVal;
            int currIntVal;
            int intValue;
            string strValue;
            string key;
            string field;
            if (table == "Cal_DayInMonth")
            {
                key = "DayInMonth";
                currIntVal = int.Parse(monthlyGrid.CurrentRow.Cells[key].Value.ToString());
                intValue = int.Parse(dayInMonthBox.Text);
                query = $"UPDATE {table} SET {key}=@value WHERE {key}=@currValue AND WorkingCalendarID=@calID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", intValue);
                cmd.Parameters.AddWithValue("@currValue", currIntVal);
            }
            else if (table == "Cal_DayInWeek")
            {
                key = "DayInWeek";
                currIntVal = int.Parse(weeklyGrid.CurrentRow.Cells[key].Value.ToString());
                intValue = int.Parse(dayInWeekBox.Text);
                query = $"UPDATE {table} SET {key}=@value WHERE {key}=@currValue AND WorkingCalendarID=@calID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", intValue);
                cmd.Parameters.AddWithValue("@currValue", currIntVal);
            }
            else
            {
                key = "DayFree";
                currStrVal = freedayGrid.CurrentRow.Cells[key].Value.ToString();
                strValue = freeDayBox.Text;
                query = $"UPDATE {table} SET {key}=@value WHERE {key}=@currValue AND WorkingCalendarID=@calID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", strValue);
                cmd.Parameters.AddWithValue("@currValue", currStrVal);
            }
            cmd.Parameters.AddWithValue("@calID", this.workingCalID);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Cập nhật thất bại");
                con.Close();
            }

            getGridData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            deleteDay("Cal_DayInMonth");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            deleteDay("Cal_DayInWeek");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            deleteDay("Cal_FreeDay");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateDay("Cal_DayInMonth");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updateDay("Cal_DayInWeek");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            updateDay("Cal_FreeDay");
        }

        private void updateWorkingCal(string field)
        {
            con.Open();

            string value;

            if(field == "MonthBegin")
            {
                value = begin.Text;
            }
            else
            {
                value = end.Text;
            }
            
            try
            {
                string query = $"UPDATE WorkingCalendar SET {field}=@value WHERE WorkingCalendarID=@calID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@calID", this.workingCalID);
                cmd.Parameters.AddWithValue("@value", value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi: Cập nhật thất bại");
                con.Close();
            }
            getWorkingCal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateWorkingCal("MonthBegin");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateWorkingCal("MonthEnd");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

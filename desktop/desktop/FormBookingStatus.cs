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

namespace desktop
{
    public partial class FormBookingStatus : Form
    {
        DbHelper dbHelper = new DbHelper();
        int id;
        public FormBookingStatus()
        {
            InitializeComponent();
        }

        public void setValue(int cid)
        {
            id = cid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbHelper.Insert($"Update tbl_bus set status = 'Available' where id = {id}");
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbHelper.Insert($"Update tbl_bus set status = 'Unavailable' where id = {id}");
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbHelper.Insert($"Update tbl_bus set status = 'On The Way' where id = {id}");
            this.Hide();
        }

        private void FormBookingStatus_Load(object sender, EventArgs e)
        {
            DataTable dt = dbHelper.GetTable($"select * from tbl_bus where id = {id}");
            DataRow row = dt.Rows[0];
            if(row["status"].ToString() == "Available")
            {
                button1.Enabled = false;
            }
            if (row["status"].ToString() == "Unavailable")
            {
                button3.Enabled = false;
                button4.Enabled = false;
                date_departure.Enabled = false;
                date_arrive.Enabled = false;
            }
            if (row["status"].ToString() == "On The Way")
            { 
                button4.Enabled = false;
            }
            date_departure.Value = DateTime.Parse(row["date_departure"].ToString());
            date_arrive.Value = DateTime.Parse(row["date_arrive"].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void date_departure_ValueChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update tbl_bus set date_departure = @date");
            cmd.Parameters.AddWithValue("@date", date_departure.Value);
            dbHelper.InsertCmd(cmd);
        }

        private void date_arrive_ValueChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update tbl_bus set date_arrive = @date");
            cmd.Parameters.AddWithValue("@date", date_arrive.Value);
            dbHelper.InsertCmd(cmd);
        }
    }
}

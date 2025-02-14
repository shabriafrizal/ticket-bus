using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        DbHelper dbHelper = new DbHelper();

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            label_name.Text = Session_login.Name;
            label_role.Text = Session_login.Role;
            TotalPassenger();
            TotalBus();
            TotalRoute();
            TotalBooking();
            TotalBookingMonth();
            TotalSalaryMonth();
            UCBooking();
            ChartSalary();
        }

        private void TotalPassenger()
        {
            SqlCommand cmd = new SqlCommand("Select count(*) as count from tbl_passenger");
            DataTable dt = dbHelper.GetTableCmd(cmd);
            label_passenger.Text = dt.Rows[0]["count"].ToString();
        }
        private void TotalBus()
        {
            SqlCommand cmd = new SqlCommand("Select count(*) as count from tbl_bus");
            DataTable dt = dbHelper.GetTableCmd(cmd);
            label_bus.Text = dt.Rows[0]["count"].ToString();
        }
        private void TotalRoute()
        {
            SqlCommand cmd = new SqlCommand("Select count(*) as count from tbl_route");
            DataTable dt = dbHelper.GetTableCmd(cmd);
            label_route.Text = dt.Rows[0]["count"].ToString();
        }
        private void TotalBooking()
        {
            SqlCommand cmd = new SqlCommand("Select count(*) as count from tbl_booking");
            DataTable dt = dbHelper.GetTableCmd(cmd);
            label_booking.Text = dt.Rows[0]["count"].ToString();
        }
        private void TotalBookingMonth()
        {
            SqlCommand cmd = new SqlCommand("Select count(*) as count from tbl_booking where date_booking between @dateFrom and @dateTo");
            cmd.Parameters.AddWithValue("@dateFrom", DateTime.Today.AddMonths(-1));
            cmd.Parameters.AddWithValue("@dateTo", DateTime.Today.AddMonths(1));
            DataTable dt = dbHelper.GetTableCmd(cmd);
            label_booking_month.Text = dt.Rows[0]["count"].ToString();
        }
        private void TotalSalaryMonth()
        {
            SqlCommand cmd = new SqlCommand("Select sum(price) as count from tbl_booking inner join tbl_bus on tbl_bus.id = tbl_booking.id_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where date_booking between @dateFrom and @dateTo");
            cmd.Parameters.AddWithValue("@dateFrom", DateTime.Today.AddMonths(-1));
            cmd.Parameters.AddWithValue("@dateTo", DateTime.Today.AddMonths(1));
            DataTable dt = dbHelper.GetTableCmd(cmd);
            label_salary_month.Text = string.Format(new CultureInfo("id-ID"), "{0:C}", dt.Rows[0]["count"]);
        }

        private void UCBooking()
        {
            flowLayoutPanel1.Controls.Clear();
            DataTable dt = dbHelper.GetTable("SELECT * FROM tbl_booking inner join tbl_passenger on tbl_passenger.id = tbl_booking.id_passenger inner join tbl_bus on tbl_bus.id = tbl_booking.id_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route");
            UC_DashboardBooking[] uc = new UC_DashboardBooking[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                uc[i] = new UC_DashboardBooking();
                uc[i].Nama = row["name"].ToString();
                uc[i].Bus = row["code_bus"].ToString();

                flowLayoutPanel1.Controls.Add(uc[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDashboardPassenger obj = new FormDashboardPassenger();
            obj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDashboardBus obj = new FormDashboardBus();
            obj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDashboardRoute obj = new FormDashboardRoute();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormDashboardBooking obj = new FormDashboardBooking();
            obj.ShowDialog();
        }

        private void ChartSalary()
        {
            DataTable dt = dbHelper.GetTable("select * from tbl_route");
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow rowRoute = dt.Rows[i];
                DataTable dt1 = dbHelper.GetTable($"select sum(price) as total from tbl_booking inner join tbl_bus on tbl_bus.id = tbl_booking.id_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where id_route = {rowRoute["id"]} and tbl_booking.status != 'Pending'");
                chart1.Series["Salary Per Route"].Points.AddXY(rowRoute["id"], dt1.Rows[0]["total"]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop
{
    public partial class FormDashboardBooking : Form
    {
        DataTable dt_passenger = new DataTable();
        DbHelper dbHelper = new DbHelper();
        public FormDashboardBooking()
        {
            InitializeComponent();
            loadDgv();
        }

        public void loadDgv()
        {
            dt_passenger = dbHelper.GetTable($"SELECT tbl_booking.id as ID, name as Name, code_bus as Bus, price as Price, date_booking as [Date Booking], tbl_booking.status as Status FROM tbl_booking inner join tbl_passenger on tbl_passenger.id = tbl_booking.id_passenger inner join tbl_bus on tbl_bus.id = tbl_booking.id_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route");
            dgv_passenger.DataSource = dt_passenger;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

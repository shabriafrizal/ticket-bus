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
    public partial class FormPaymentShowPaid : Form
    {
        DataTable dt_payment = new DataTable();
        DbHelper dbHelper = new DbHelper();
        public FormPaymentShowPaid()
        {
            InitializeComponent();
        }

        private void FormPaymentShowPaid_Load(object sender, EventArgs e)
        {
            loadDgv();
        }
        private void loadDgv()
        {
            dt_payment = dbHelper.GetTable("SELECT tbl_booking.id as ID, name as Name, code_bus as Bus, price as Price, date_booking as [Date Booking], tbl_booking.status as Status FROM tbl_booking inner join tbl_passenger on tbl_passenger.id = tbl_booking.id_passenger inner join tbl_bus on tbl_bus.id = tbl_booking.id_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where tbl_booking.status != 'Pending'");
            dgv_payment.DataSource = dt_payment;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

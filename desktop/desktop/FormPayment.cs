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
    public partial class FormPayment : Form
    {
        DataTable dt_payment = new DataTable();
        DbHelper dbHelper = new DbHelper();
        public FormPayment()
        {
            InitializeComponent();
            loadDgv();
            label_name.Text = Session_login.Name;
            label_role.Text = Session_login.Role;
        }

        private void loadDgv()
        {
            dt_payment = dbHelper.GetTable("SELECT tbl_booking.id as ID, name as Name, code_bus as Bus, price as Price, date_booking as [Date Booking], tbl_booking.status as Status FROM tbl_booking inner join tbl_passenger on tbl_passenger.id = tbl_booking.id_passenger inner join tbl_bus on tbl_bus.id = tbl_booking.id_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where tbl_booking.status = 'Pending'");
            dgv_payment.DataSource = dt_payment;
        }

        private void searchDgv()
        {
            dt_payment = dbHelper.GetTable($"SELECT tbl_booking.id as ID, name as Name, code_bus as Bus, price as Price, date_booking as [Date Booking], tbl_booking.status as Status FROM tbl_booking inner join tbl_passenger on tbl_passenger.id = tbl_booking.id_passenger inner join tbl_bus on tbl_bus.id = tbl_booking.id_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where (tbl_booking.id like '{tbox_search.Text}' or name like '%{tbox_search.Text}%' or tbl_booking.status like '%{tbox_search.Text}%' or code_bus like '{tbox_search.Text}%') and tbl_booking.status = 'Pending'");
            dgv_payment.DataSource = dt_payment;
        }

        private void tbox_search_TextChanged(object sender, EventArgs e)
        {
            searchDgv();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            if (dgv_payment.RowCount != 0)
            {

                if (dgv_payment.SelectedRows != null)
                {
                    int cid = int.Parse(dt_payment.Rows[dgv_payment.CurrentCell.RowIndex][0].ToString());
                    DataTable dt = dbHelper.GetTable($"SELECT * FROM tbl_booking inner join tbl_passenger on tbl_passenger.id = tbl_booking.id_passenger inner join tbl_bus on tbl_bus.id = tbl_booking.id_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where tbl_booking.id = {cid}");
                    DataRow row = dt.Rows[0];
                    if (row["status"].ToString() == "Pending")
                    {
                        FormPaymentMethod obj = new FormPaymentMethod();
                        obj.setValue(int.Parse(row["id"].ToString()), row["name"].ToString(), row["price"].ToString());
                        obj.ShowDialog();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPaymentShowPaid obj = new FormPaymentShowPaid();
            obj.ShowDialog();
        }
    }
}

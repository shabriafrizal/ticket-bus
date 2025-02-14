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
    public partial class FormRouteDetail : Form
    {
        DbHelper dbHelper = new DbHelper();
        DataTable dt_bus = new DataTable();
        public FormRouteDetail()
        {
            InitializeComponent();
            loadDgv(0);
        }

        public void SetValue(int cid, string origin, string destination, string note, string price, string class_bus)
        {
            label_origin.Text = origin;
            label_destination.Text = destination;
            label_note.Text = note;
            label_price.Text = price;
            label_class.Text = class_bus;
            loadDgv(cid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadDgv(int id)
        {
            dt_bus = dbHelper.GetTable($"SELECT id as ID, code_bus as Bus, type as Type, status as Status from tbl_bus where id_route = {id}");
            dgv_bus.DataSource = dt_bus;
        }

        private void dgv_bus_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_bus.SelectedRows != null)
            {
                int cid = int.Parse(dt_bus.Rows[dgv_bus.CurrentCell.RowIndex][0].ToString());
                DataTable dt = dbHelper.GetTable($"Select * from tbl_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where tbl_bus.id = {cid}");
                FormBusDetail obj = new FormBusDetail();
                DataRow row = dt.Rows[0];
                obj.SetValue(int.Parse(row["id"].ToString()), row["code_bus"].ToString(), row["type"].ToString(), row["status"].ToString(), row["route"].ToString(), row["city_origin"].ToString(), row["city_destination"].ToString(), row["class"].ToString(), row["price"].ToString(), row["note"].ToString(), DateTime.Parse(row["date_departure"].ToString()), DateTime.Parse(row["date_arrive"].ToString()), (byte[])row["image"]);
                obj.ShowDialog();
            }
        }
    }
}

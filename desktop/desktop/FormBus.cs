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
    public partial class FormBus : Form
    {
        DbHelper dbHelper = new DbHelper();
        DataTable dt_bus = new DataTable();
        public FormBus()
        {
            InitializeComponent();
            loadDgv();
            label_name.Text = Session_login.Name;
            label_role.Text = Session_login.Role;
        }

        private void loadDgv()
        {
            dt_bus = dbHelper.GetTable("SELECT id as ID, code_bus as Bus, type as Type, status as Status from tbl_bus");
            dgv_bus.DataSource = dt_bus;
        }

        private void searchDgv()
        {
            dt_bus = dbHelper.GetTable($"SELECT id as ID, code_bus as Bus, type as Type, status as Status from tbl_bus where id like '{textBox1.Text}' or code_bus like '%{textBox1.Text}%' or type like '%{textBox1.Text}%'");
            dgv_bus.DataSource = dt_bus;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchDgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBusCreate obj = new FormBusCreate();
            obj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dgv_bus.SelectedRows != null)
            {
                int cid = int.Parse(dt_bus.Rows[dgv_bus.CurrentCell.RowIndex][0].ToString());
                DataTable dt = dbHelper.GetTable($"Select * from tbl_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where tbl_bus.id = {cid}");
                FormBusDetail obj = new FormBusDetail();
                DataRow row = dt.Rows[0];
                obj.SetValue(int.Parse(row["id"].ToString()), row["code_bus"].ToString(), row["type"].ToString(), row["status"].ToString(), row["route"].ToString(), row["city_origin"].ToString(), row["city_destination"].ToString(), row["class"].ToString(), row["price"].ToString(), row["note"].ToString(), DateTime.Parse(row["date_departure"].ToString()), DateTime.Parse(row["date_arrive"].ToString()), (byte[])row["image"]);
                obj.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dgv_bus.SelectedRows != null)
            {
                int cid = int.Parse(dt_bus.Rows[dgv_bus.CurrentCell.RowIndex][0].ToString());
                DataTable dt = dbHelper.GetTable($"Select * from tbl_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where tbl_bus.id = {cid}");
                FormBusCreate obj = new FormBusCreate();
                DataRow row = dt.Rows[0];
                obj.SetValue(int.Parse(row["id"].ToString()), row["code_bus"].ToString(), row["type"].ToString(), row["status"].ToString(), int.Parse(row["id_route"].ToString()), row["note"].ToString(), DateTime.Parse(row["date_departure"].ToString()), DateTime.Parse(row["date_arrive"].ToString()), (byte[])row["image"]);
                obj.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes && dgv_bus.SelectedRows != null)
            {
                int cid = int.Parse(dt_bus.Rows[dgv_bus.CurrentCell.RowIndex][0].ToString());
                var res = dbHelper.Insert($"Delete from tbl_bus where id = {cid}");
                loadDgv();
            }
        }
    }
}

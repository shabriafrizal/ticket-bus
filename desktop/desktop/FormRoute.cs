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
    public partial class FormRoute : Form
    {
        DbHelper dbHelper = new DbHelper();
        DataTable dt_route = new DataTable();

        public FormRoute()
        {
            InitializeComponent();
            loadDgv();
            label_name.Text = Session_login.Name;
            label_role.Text = Session_login.Role;
        }

        private void loadDgv()
        {
            string sql = "SELECT id as ID, city_origin as [City Origin], city_destination as [City Destination], class as Class, price as Price FROM tbl_route";
            dt_route = dbHelper.GetTable(sql);
            dgv_route.DataSource = dt_route;
        }

        private void searchDgv()
        {
            string sql = $"SELECT id as ID, city_origin as [City Origin], city_destination as [City Destination], class as Class, price as Price FROM tbl_route where id like '{tbox_search.Text}' or city_origin like '%{tbox_search.Text}%' or city_destination like '%{tbox_search.Text}%' or price like '{tbox_search.Text}%' or class like '{tbox_search.Text}%'";
            dt_route = dbHelper.GetTable(sql);
            dgv_route.DataSource = dt_route;
        }

        private void tbox_search_TextChanged(object sender, EventArgs e)
        {
            searchDgv();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            FormRouteCreate obj = new FormRouteCreate();
            obj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dgv_route.SelectedRows != null)
            {
                int cid = int.Parse(dt_route.Rows[dgv_route.CurrentCell.RowIndex][0].ToString());
                DataTable dt = dbHelper.GetTable($"select * from tbl_route where id = {cid}");
                FormRouteCreate obj = new FormRouteCreate();
                DataRow row = dt.Rows[0];
                obj.SetValue(int.Parse(row["id"].ToString()), row["city_origin"].ToString(), row["city_destination"].ToString(), row["note"].ToString(), row["price"].ToString(), row["class"].ToString());
                obj.ShowDialog();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgv_route.SelectedRows != null)
            {
                int cid = int.Parse(dt_route.Rows[dgv_route.CurrentCell.RowIndex][0].ToString());
                DataTable dt = dbHelper.GetTable($"select * from tbl_route where id = {cid}");
                FormRouteDetail obj = new FormRouteDetail();
                DataRow row = dt.Rows[0];
                obj.SetValue(int.Parse(row["id"].ToString()), row["city_origin"].ToString(), row["city_destination"].ToString(), row["note"].ToString(), row["price"].ToString(), row["class"].ToString());
                obj.ShowDialog();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes && dgv_route.SelectedRows != null)
            {
                int cid = int.Parse(dt_route.Rows[dgv_route.CurrentCell.RowIndex][0].ToString());
                var res = dbHelper.Insert($"Delete from tbl_route where id = {cid}");
                loadDgv();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_role_Click(object sender, EventArgs e)
        {

        }

        private void label_name_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

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
    public partial class FormPassenger : Form
    {
        DbHelper dbHelper = new DbHelper();
        DataTable dt_passenger = new DataTable();
        public FormPassenger()
        {
            InitializeComponent();
            loadDgv();
            label_name.Text = Session_login.Name;
            label_role.Text = Session_login.Role;
        }

        private void loadDgv()
        {
            dt_passenger = dbHelper.GetTable("Select id as ID, name as Name, address as Address, birthday as Birthday, gender as Gender, phone as Phone, date_created as Created FROM tbl_passenger");
            dgv_passenger.DataSource = dt_passenger;
        }

        private void searchDgv()
        {
            dt_passenger = dbHelper.GetTable($"Select id as ID, name as Name, address as Address, birthday as Birthday, gender as Gender, phone as Phone, date_created as Created FROM tbl_passenger where id like '{tbox_search.Text}' or name like '%{tbox_search.Text}%' or address like '%{tbox_search.Text}%' or gender like '{tbox_search.Text}%' or phone like '{tbox_search.Text}%'");
            dgv_passenger.DataSource = dt_passenger;
        }

        private void tbox_search_TextChanged(object sender, EventArgs e)
        {
            searchDgv();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            FormPassengerCreate obj = new FormPassengerCreate();
            obj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dgv_passenger.SelectedRows != null)
            {
                int cid = int.Parse(dt_passenger.Rows[dgv_passenger.CurrentCell.RowIndex][0].ToString());
                DataTable dt = dbHelper.GetTable($"SELECT * FROM tbl_passenger where id = '{cid}'");
                FormPassengerCreate obj = new FormPassengerCreate();
                DataRow row = dt.Rows[0];
                obj.setValue(int.Parse(row["id"].ToString()), row["Name"].ToString(), row["Address"].ToString(), row["Gender"].ToString(), row["Phone"].ToString(), DateTime.Parse(row["Birthday"].ToString()));
                obj.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes && dgv_passenger.SelectedRows != null)
            {
                int cid = int.Parse(dt_passenger.Rows[dgv_passenger.CurrentCell.RowIndex][0].ToString());
                var res = dbHelper.Insert($"Delete from tbl_passenger where id = {cid}");
                loadDgv();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgv_passenger.SelectedRows != null)
            {
                int cid = int.Parse(dt_passenger.Rows[dgv_passenger.CurrentCell.RowIndex][0].ToString());
                DataTable dt = dbHelper.GetTable($"SELECT * FROM tbl_passenger where id = '{cid}'");
                FormPassengerDetail obj = new FormPassengerDetail();
                DataRow row = dt.Rows[0];
                obj.setValue(int.Parse(row["id"].ToString()), row["Name"].ToString(), row["Address"].ToString(), row["Gender"].ToString(), row["Phone"].ToString(), DateTime.Parse(row["Birthday"].ToString()), DateTime.Parse(row["date_created"].ToString()));
                obj.ShowDialog();
            }
        }
    }
}

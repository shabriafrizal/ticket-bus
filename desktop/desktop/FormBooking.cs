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
    public partial class FormBooking : Form
    {
        DbHelper dbHelper = new DbHelper();
        public FormBooking()
        {
            InitializeComponent();
            label_name.Text = Session_login.Name;
            label_role.Text = Session_login.Role;
        }



        private void loadPanel()
        {
            //flowLayoutPanel1.Controls.Add(new UCBus());
            flowLayoutPanel1.Controls.Clear();
            DataTable dt = dbHelper.GetTable("Select * from tbl_bus Order by status asc");
            UCBus[] uCBus = new UCBus[dt.Rows.Count]; 

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                uCBus[i] = new UCBus();
                uCBus[i].Id = int.Parse(row["id"].ToString());
                uCBus[i].Bus = row["code_bus"].ToString();
                uCBus[i].Status = row["status"].ToString();
                uCBus[i].ImageBus = (byte[])row["image"];

                flowLayoutPanel1.Controls.Add(uCBus[i]);
            }
        }

        private void searchPanel()
        {
            //flowLayoutPanel1.Controls.Add(new UCBus());
            flowLayoutPanel1.Controls.Clear();
            DataTable dt = dbHelper.GetTable($"Select * from tbl_bus where code_bus like '%{tbox_search.Text}%' or type like '%{tbox_search.Text}%' or status like '%{tbox_search.Text}%' Order by status asc");
            UCBus[] uCBus = new UCBus[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                uCBus[i] = new UCBus();
                uCBus[i].Id = int.Parse(row["id"].ToString());
                uCBus[i].Bus = row["code_bus"].ToString();
                uCBus[i].Status = row["status"].ToString();
                uCBus[i].ImageBus = (byte[])row["image"];

                flowLayoutPanel1.Controls.Add(uCBus[i]);
            }
        }

        private void tbox_search_TextChanged(object sender, EventArgs e)
        {
            searchPanel();
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            if(tbox_search.Text == "")
            {
                loadPanel();
            }
        }
    }
}

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
    public partial class FormDashboardRoute : Form
    {
        DataTable dt_passenger = new DataTable();
        DbHelper dbHelper = new DbHelper();
        public FormDashboardRoute()
        {
            InitializeComponent();
            loadDgv();
        }
        public void loadDgv()
        {
            dt_passenger = dbHelper.GetTable($"SELECT id as ID, city_origin as [City Origin], city_destination as [City Destination], class as Class, price as Price FROM tbl_route");
            dgv_passenger.DataSource = dt_passenger;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

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
    public partial class FormDashboardPassenger : Form
    {
        DataTable dt_passenger = new DataTable();
        DbHelper dbHelper = new DbHelper();
        public FormDashboardPassenger()
        {
            InitializeComponent();
            loadDgv();
        }
        public void loadDgv()
        {
            dt_passenger = dbHelper.GetTable($"Select id as ID, name as Name, address as Address, birthday as Birthday, gender as Gender, phone as Phone, date_created as Created FROM tbl_passenger");
            dgv_passenger.DataSource = dt_passenger;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

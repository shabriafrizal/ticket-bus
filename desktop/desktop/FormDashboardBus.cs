﻿using System;
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
    public partial class FormDashboardBus : Form
    {
        DataTable dt_passenger = new DataTable();
        DbHelper dbHelper = new DbHelper();
        public FormDashboardBus()
        {
            InitializeComponent();
            loadDgv();
        }

        public void loadDgv()
        {
            dt_passenger = dbHelper.GetTable($"SELECT id as ID, code_bus as Bus, type as Type, status as Status from tbl_bus");
            dgv_passenger.DataSource = dt_passenger;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

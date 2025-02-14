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
    public partial class UC_DashboardBooking : UserControl
    {
        public UC_DashboardBooking()
        {
            InitializeComponent();
        }

        private string _nama;
        private string _bus;

        public string Nama
        {
            get { return _nama; }
            set { _nama = value; label1.Text = value; }
        }

        public string Bus
        {
            get { return _bus; }
            set { _nama = value; label2.Text = value; }
        }
    }
}

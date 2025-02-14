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
    public partial class FormPassengerDetail : Form
    {
        public FormPassengerDetail()
        {
            InitializeComponent();
        }

        public void setValue(int id, String name, string address, string gender, string phone, DateTime birthday, DateTime created)
        {
            //id = id;
            label_name.Text = name;
            label_address.Text = address;
            label_gender.Text = gender;
            label_phone.Text = phone;
            date_birthday.Value = birthday;
            date_created.Value = created;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

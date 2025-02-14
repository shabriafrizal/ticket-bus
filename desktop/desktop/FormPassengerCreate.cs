using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop
{
    public partial class FormPassengerCreate : Form
    {
        DbHelper dbHelper = new DbHelper();
        public int id = 0;

        public FormPassengerCreate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setValue(int cid, String Name, string Address, string Gender, string Phone, DateTime Birthday)
        {
            id = cid;
            tbox_name.Text = Name;
            tbox_address.Text = Address;
            tbox_phone.Text = Phone;
            if(Gender == "Male")
            {
                rb_male.Checked = true;
            }
            if(Gender == "Female")
            {
                rb_female.Checked = true;
            }
            date_birthday.Value = Birthday;
        }

        string getGender()
        {
            if (rb_male.Checked)
            {
                return "Male";
            }
            if (rb_female.Checked)
            {
                return "Female";
            }
            else
            {
                return "";
            }
        }

        string insert() => $"Insert into tbl_passenger values (" +
            $"'{tbox_name.Text}'," +
            $"'{tbox_address.Text}'," +
            $"'{getGender()}'," +
            $"{tbox_phone.Text}," +
            $"@date_created," +
            $"@birthday)";

        string update() => $"Update tbl_passenger set " +
            $"name = '{tbox_name.Text}'," +
            $"address = '{tbox_address.Text}'," +
            $"gender = '{getGender()}'," +
            $"phone = {tbox_phone.Text}," +
            $"birthday = @birthday where id = {id}";

        private void button_create_Click(object sender, EventArgs e)
        {
            string sql = id == 0 ? insert() : update();
            SqlCommand cmd = new SqlCommand(sql);
            this.Hide();
            cmd.Parameters.AddWithValue("@birthday", date_birthday.Value);

            if(id == 0)
            {
                cmd.Parameters.AddWithValue("@date_created", DateTime.Now);
            }
            try
            {
                var res = dbHelper.InsertCmd(cmd);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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
    public partial class FormRouteCreate : Form
    {
        DbHelper dbHelper = new DbHelper();
        int id = 0;
        public FormRouteCreate()
        {
            InitializeComponent();
            SetComboBox();
        }

        public void SetValue(int cid, string origin, string destination, string note, string price, string class_bus)
        {
            id = cid;
            tbox_origin.Text = origin;
            tbox_destination.Text = destination;
            tbox_note.Text = note;
            tbox_price.Text = price;
            cbox_class.Text = class_bus;
        }

        private void SetComboBox()
        {
            cbox_class.Items.Add("Economy");
            cbox_class.Items.Add("Executive");
            cbox_class.Items.Add("Slipper");
            cbox_class.Items.Add("Business");
            cbox_class.Items.Add("Luxury");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string insert() => $"insert into tbl_route values ( " +
            $"'{tbox_origin.Text}'," +
            $"'{tbox_destination.Text}'," +
            $"'{tbox_note.Text}'," +
            $"'{tbox_price.Text}'," +
            $"'{cbox_class.Text}'," +
            $"'{tbox_origin.Text} - {tbox_destination.Text} ({cbox_class.Text})')";

        string update() => $"update Tbl_route set " +
            $"city_origin = '{tbox_origin.Text}'," +
            $"city_destination = '{tbox_destination.Text}'," +
            $"note = '{tbox_note.Text}'," +
            $"price = '{tbox_price.Text}'," +
            $"class = '{cbox_class.Text}'," +
            $"route = '{tbox_origin.Text} - {tbox_destination.Text} ({cbox_class.Text})' " +
            $"where id = {id}";

        private void button_create_Click(object sender, EventArgs e)
        {
            string sql = id == 0 ? insert() : update();
            try
            {
                var res = dbHelper.Insert(sql);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

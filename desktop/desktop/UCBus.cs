using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop
{
    public partial class UCBus : UserControl
    {
        public UCBus()
        {
            InitializeComponent();
        }

        DbHelper dbHelper = new DbHelper();
        Function function = new Function();
        private int _id;
        private string _label1;
        private string _label2;
        private byte[] _image;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Bus
        {
            get { return _label1; }
            set { _label1 = value; label1.Text = value; }
        }

        public string Status
        {
            get { return _label2; }
            set { _label2 = value; label2.Text = value; }
        }

        public byte[] ImageBus
        {
            get { return _image; }
            set { _image = value; pictureBox1.Image = function.byteToImage(value); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(label2.Text == "Available")
            {
                FormBookingPassenger obj = new FormBookingPassenger();
                obj.setValue(_id);
                obj.ShowDialog();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBookingStatus obj = new FormBookingStatus();
            obj.setValue(_id);
            obj.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt = dbHelper.GetTable($"Select * from tbl_bus inner join tbl_route on tbl_route.id = tbl_bus.id_route where tbl_bus.id = {_id}");
            FormBusDetail obj = new FormBusDetail();
            DataRow row = dt.Rows[0];
            obj.SetValue(int.Parse(row["id"].ToString()), row["code_bus"].ToString(), row["type"].ToString(), row["status"].ToString(), row["route"].ToString(), row["city_origin"].ToString(), row["city_destination"].ToString(), row["class"].ToString(), row["price"].ToString(), row["note"].ToString(), DateTime.Parse(row["date_departure"].ToString()), DateTime.Parse(row["date_arrive"].ToString()), (byte[])row["image"]);
            obj.ShowDialog();
        }
    }
}

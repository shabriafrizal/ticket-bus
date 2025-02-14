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
    public partial class FormBusDetail : Form
    {
        Function function = new Function();
        public FormBusDetail()
        {
            InitializeComponent();
        }

        public void SetValue(int cid, string code, string type, string status, string route, string city_origin, string city_destination, string bus_class, string price, string note, DateTime arrive, DateTime departure, byte[] image)
        {
            //cid = cid;
            label_code.Text = code;
            label_type.Text = type;
            label_status.Text = status;
            label_route.Text = route;
            label_origin.Text = city_origin;
            label_destination.Text = city_destination;
            label_class.Text = bus_class;
            label_price.Text = price;
            label_note.Text = note;
            date_departure.Value = departure;
            date_arrive.Value = arrive;
            pictureBox1.Image = function.byteToImage(image);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

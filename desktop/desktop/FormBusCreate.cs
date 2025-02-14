using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop
{
    public partial class FormBusCreate : Form
    {
        Function function = new Function();
        DbHelper dbHelper = new DbHelper();
        public int id = 0;
        string status = "Unavailable";

        public FormBusCreate()
        {
            InitializeComponent();
            SetComboBox();
        }

        public void SetValue(int cid, string code, string type, string cstatus, int id_route, string note, DateTime arrive, DateTime departure, byte[] image)
        {
            id = cid;
            status = cstatus;
            tbox_code.Text = code;
            cbox_type.Text = type;
            cbox_route.SelectedValue = id_route;
            tbox_note.Text = note;
            date_departure.Value = departure;
            date_arrive.Value = arrive;
            pictureBox1.Image = function.byteToImage(image);
        }

        public void SetComboBox()
        {
            DataTable dt = dbHelper.GetTable("select * from tbl_route");
            cbox_route.DataSource = dt;
            cbox_route.DisplayMember = "route";
            cbox_route.ValueMember = "id";

            cbox_type.Items.Add("Pariwisata");
            cbox_type.Items.Add("Transportasi Umum");
            cbox_type.Items.Add("Sewa");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string insert() => $"insert into tbl_bus values(" +
            $"'{tbox_code.Text}'," +
            $"'{cbox_type.Text}'," +
            $"'{tbox_note.Text}'," +
            $"{cbox_route.SelectedValue}," +
            $"'{status}'," +
            $"@datedeparture," +
            $"@datearrive," +
            $"@img)";

        string update() => $"update tbl_bus set " +
            $"code_bus = '{tbox_code.Text}'," +
            $"type = '{cbox_type.Text}'," +
            $"note = '{tbox_note.Text}'," +
            $"id_route = {cbox_route.SelectedValue}, " +
            $"status = '{status}'," +
            $"date_departure = @datedeparture," +
            $"date_arrive = @datearrive," +
            $"image = @img " +
            $"where id = {id}";
        private void button_create_Click(object sender, EventArgs e)
        {
            string sql = id == 0 ? insert() : update();
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@datedeparture", date_departure.Value);
            cmd.Parameters.AddWithValue("@datearrive", date_arrive.Value);
            try
            {
                cmd.Parameters.AddWithValue("@img", function.saveImage(pictureBox1));
                var res = dbHelper.InsertCmd(cmd);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.jpg; *.jpeg; *.png;) | *.jpg;*.jpeg;*.png;";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
    }
}

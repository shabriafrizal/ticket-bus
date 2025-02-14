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
    public partial class FormBookingPassenger : Form
    {
        DbHelper dbHelper = new DbHelper();
        DataTable dt_passenger;
        public int id = 0;

        public FormBookingPassenger()
        {
            InitializeComponent();
        }

        private void FormBookingPassenger_Load(object sender, EventArgs e)
        {

            loadDgv();
            SetComboBox();
        }

        public void SetComboBox()
        {
            DataTable dt = dbHelper.GetTable("select * from tbl_passenger");
            cbox_passenger.DataSource = dt;
            cbox_passenger.DisplayMember = "name";
            cbox_passenger.ValueMember = "id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void setValue(int cid)
        {
            id = cid;
        }

        private void loadDgv()
        {
            dt_passenger = dbHelper.GetTable($"SELECT tbl_booking.id as ID, name as Name, date_booking as [Date Booking], status as Status FROM tbl_booking inner join tbl_passenger on tbl_passenger.id = tbl_booking.id_passenger where id_bus = {id}");
            dgv_passenger.DataSource = dt_passenger;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = $"Insert into tbl_booking values(" +
                    $"@datecreated," +
                    $"{cbox_passenger.SelectedValue}," +
                    $"{Session_login.ID}," +
                    $"{id}," +
                    $"'Pending')";
                SqlCommand cmd = new SqlCommand(sql);
                cmd.Parameters.AddWithValue("@datecreated", DateTime.Now);
                var res = dbHelper.InsertCmd(cmd);
                loadDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgv_passenger.RowCount != 0)
            {
                if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes && dgv_passenger.SelectedRows != null)
                {
                    int cid = int.Parse(dt_passenger.Rows[dgv_passenger.CurrentCell.RowIndex][0].ToString());
                    var res = dbHelper.Insert($"Delete from tbl_booking where id = {cid}");
                    loadDgv();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dgv_passenger.RowCount != 0)
            {
                if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes && dgv_passenger.SelectedRows != null)
                {
                    int cid = int.Parse(dt_passenger.Rows[dgv_passenger.CurrentCell.RowIndex][0].ToString());
                    var res = dbHelper.Insert($"Delete from tbl_booking where id_bus = {id}");
                    loadDgv();
                }
            }
        }
    }
}

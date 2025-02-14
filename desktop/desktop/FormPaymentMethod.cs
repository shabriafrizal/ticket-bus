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
    public partial class FormPaymentMethod : Form
    {
        DbHelper dbHelper = new DbHelper();
        int id;
        public FormPaymentMethod()
        {
            InitializeComponent();
        }

        public void setValue(int cid, string name, string price)
        {
            id = cid;
            label_name.Text = name;
            label_price.Text = price;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = $"update tbl_booking set " +
                        $"status = 'Paid ({cbox_type.Text})' where id = {id}";
                    SqlCommand cmd = new SqlCommand(sql);
                    var res = dbHelper.InsertCmd(cmd);
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormPaymentMethod_Load(object sender, EventArgs e)
        {
            setComboBox();
        }

        private void setComboBox()
        {
            cbox_type.Items.Add("Cash");
            cbox_type.Items.Add("Debit");
            cbox_type.Items.Add("Bank");
            cbox_type.Items.Add("QRIS");
        }
    }
}

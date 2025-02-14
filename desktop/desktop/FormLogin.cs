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
    public partial class FormLogin : Form
    {
        DbHelper dbHelper = new DbHelper();

        public FormLogin()
        {
            InitializeComponent();
            label_status.Hide();
            this.KeyPreview = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbox_username.Text != "" || tbox_password.Text != "")
                {
                    DataTable dt = dbHelper.GetTable($"Select * from tbl_staff join tbl_level on tbl_level.id = tbl_staff.id_level where username = '{tbox_username.Text}' and password = '{tbox_password.Text}'");
                    if(dt.Rows.Count == 1)
                    {
                        DataRow row = dt.Rows[0];
                        Session_login.ID = int.Parse(row["id"].ToString());
                        Session_login.Name = row["name"].ToString();
                        Session_login.Username = row["username"].ToString();
                        Session_login.Role = row["role"].ToString();
                        FormMain obj = new FormMain();
                        obj.Show();
                        this.Hide();
                    } else
                    {
                        label_status.Show();
                        label_status.Text = "User not found.";
                    }
                } else
                {
                    label_status.Show();
                    label_status.Text = "Field is empty.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}

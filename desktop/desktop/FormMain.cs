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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            btn_dashboard_Click(sender, e);
        }

        private void openForm (Form form)
        {
            form.TopLevel = false;
            //form.Dock = DockStyle.Fill;
            panel_main.Controls.Add(form);
            panel_main.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void colorNav()
        {
            btn_dashboard.BackColor = Color.Maroon;
            btn_passenger.BackColor = Color.Maroon;
            btn_bus.BackColor = Color.Maroon;
            btn_route.BackColor = Color.Maroon;
            btn_booking.BackColor = Color.Maroon;
            btn_payment.BackColor = Color.Maroon;
        } 

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            openForm(new FormDashboard());
            colorNav();
            btn_dashboard.BackColor = Color.Firebrick;
            panel_side.Top = btn_dashboard.Top;
        }

        public void btn_passenger_Click(object sender, EventArgs e)
        {
            openForm(new FormPassenger());
            colorNav();
            btn_passenger.BackColor = Color.Firebrick;
            panel_side.Top = btn_passenger.Top;
        }

        private void btn_bus_Click(object sender, EventArgs e)
        {
            openForm(new FormBus());
            colorNav();
            btn_bus.BackColor = Color.Firebrick;
            panel_side.Top = btn_bus.Top;
        }

        private void btn_route_Click(object sender, EventArgs e)
        {
            openForm(new FormRoute());
            colorNav();
            btn_route.BackColor = Color.Firebrick;
            panel_side.Top = btn_route.Top;
        }

        private void btn_booking_Click(object sender, EventArgs e)
        {
            openForm(new FormBooking());
            colorNav();
            btn_booking.BackColor = Color.Firebrick;
            panel_side.Top = btn_booking.Top;
        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            openForm(new FormPayment());
            colorNav();
            btn_payment.BackColor = Color.Firebrick;
            panel_side.Top = btn_payment.Top;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin obj = new FormLogin();
            obj.Show();
            this.Close();
        }
    }
}

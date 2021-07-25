using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShineWay.Messages;

namespace ShineWay.UI
{
    public partial class Home : Form
    {
        string userType;

        public Home(String userType, String userName)
        {
            InitializeComponent();
            setUserControl(homeControl1, btn_Home);
            label_userType.Text = userType;
            this.userType = userType;
            if (userType.Equals("User"))
            {
                btnUsers.Enabled = false;
            }
            Welcome message =new Welcome("Nice to see yoo " + userName.Split(" ")[0] + "!");
            message.hideCloseButton();
            message.Show();
            StartTimer();

        }

        private void btn_ownerPayments_Click(object sender, EventArgs e)
        {
            setUserControl(ownerPayment1,btn_ownerPayments);
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            setUserControl(homeControl1,btn_Home);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            setUserControl(booking1,btnBooking);
        }



        private void setUserControl(UserControl control, Button btn)
        {
            btn_Home.BackColor = System.Drawing.Color.White;
            btn_Home.ForeColor = getColor(64, 64, 64);
            btnBooking.BackColor = System.Drawing.Color.White;
            btnBooking.ForeColor = getColor(64, 64, 64);
            btnCustomer.BackColor = System.Drawing.Color.White;
            btnCustomer.ForeColor = getColor(64, 64, 64);
            btn_ownerPayments.BackColor = System.Drawing.Color.White;
            btn_ownerPayments.ForeColor = getColor(64, 64, 64);
            btn_payments.BackColor = System.Drawing.Color.White;
            btn_payments.ForeColor = getColor(64, 64, 64);
            btnUsers.BackColor = System.Drawing.Color.White;
            btnUsers.ForeColor = getColor(64, 64, 64);
            btn_vehicleOwner.BackColor = System.Drawing.Color.White;
            btn_vehicleOwner.ForeColor = getColor(64, 64, 64);
            btnVehicles.BackColor = System.Drawing.Color.White;
            btnVehicles.ForeColor = getColor(64, 64, 64);
            btn_reports.BackColor = System.Drawing.Color.White;
            btn_reports.ForeColor = getColor(64, 64, 64);
            btn.BackColor = getColor(219, 238, 253);
            btn.ForeColor = getColor(33, 150, 243);
            booking1.Hide();
            customer1.Hide();
            homeControl1.Hide();
            ownerPayment1.Hide();
            payment1.Hide();
            users1.Hide();
            vehicleOwner1.Hide();
            vehicles1.Hide();
            control.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            setUserControl(customer1,btnCustomer);
        }

        private void btn_vehicleOwner_Click(object sender, EventArgs e)
        {
            setUserControl(vehicleOwner1,btn_vehicleOwner);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            setUserControl(vehicles1,btnVehicles);
        }

        private void btn_payments_Click(object sender, EventArgs e)
        {
            setUserControl(payment1,btn_payments);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            setUserControl(users1,btnUsers);
        }

        private void btn_ownerPayments_Click_1(object sender, EventArgs e)
        {
            setUserControl(ownerPayment1,btn_ownerPayments);
        }


        private Color getColor(int r, int g, int b)
        {
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(r,g,b);
            return myRgbColor;
        }

        private void pb_btnExit_Click(object sender, EventArgs e)
        {
           //new LogOut().ShowDialog();
           DialogResult result = new CustomMessage("Do you really want to exit?","Exit Dialog",ShineWay.Properties.Resources.question,DialogResult.Yes).ShowDialog();
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pb_btnExit_MouseHover(object sender, EventArgs e)
        {
            pb_btnExit.Image = ShineWay.Properties.Resources.logoutRed;
        }

        private void pb_btnExit_MouseLeave(object sender, EventArgs e)
        {
            pb_btnExit.Image = ShineWay.Properties.Resources.logoutHover;
        }


        System.Windows.Forms.Timer t = null;
        private void StartTimer()
        {
            t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            label_time.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            
        }

        private void customer1_Load(object sender, EventArgs e)
        {

        }
    }
}

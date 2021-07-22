using System;
using ShineWay.UI;
using System.Windows.Forms;

namespace ShineWay.Messages
{
    public partial class LogOut : Form
    {
        public LogOut()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = new CustomMessage("Do you really want to exit?", "Exit Dialog", ShineWay.Properties.Resources.question, DialogResult.Yes).ShowDialog();
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = new CustomMessage("Do you really want to Logout?", "Exit Dialog", ShineWay.Properties.Resources.question, DialogResult.Yes).ShowDialog();
            if (result == DialogResult.Yes)
            {
                this.Hide();
                var form2 = new form_Login();
                form2.Closed += (s, args) => this.Close();
                form2.Show();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new form_Login();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            
        }
    }
}

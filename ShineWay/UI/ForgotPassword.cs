using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShineWay.UI
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            btn_Close.ForeColor = Color.Red;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_Close.ForeColor = Color.FromArgb(130, 130, 130);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btn_register_MouseHover(object sender, EventArgs e)
        {
            btn_register.Image = ShineWay.Properties.Resources.proceedHover;
        }

        private void btn_register_MouseLeave(object sender, EventArgs e)
        {
            btn_register.Image = ShineWay.Properties.Resources.proceed;
        }
    }
}

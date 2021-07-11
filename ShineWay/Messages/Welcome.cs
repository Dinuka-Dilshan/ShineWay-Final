using ShineWay.Beautify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShineWay.Messages
{
    public partial class Welcome : Form
    {
        public Welcome(String message)
        {
            InitializeComponent();
            new DropShadow().ApplyShadows(this);
            label1.Text = message;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

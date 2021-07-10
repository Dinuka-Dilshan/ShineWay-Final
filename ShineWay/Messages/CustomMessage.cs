using ShineWay.Beautify;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShineWay.Messages
{
    public partial class CustomMessage : Form
    {
        DialogResult resultType;

        public CustomMessage(String message, String title, System.Drawing.Bitmap icon , DialogResult resultType )
        {
            InitializeComponent();
            new DropShadow().ApplyShadows(this);
            label_message.Text = message;
            label_messageTitle.Text = title;
            pb_icon.Image = icon;
            this.resultType = resultType;

            if(resultType == DialogResult.Yes || resultType == DialogResult.No){
                btn_btn1.Text = "Yes";
                btn_btn2.Text = "No";
            }else if(resultType == DialogResult.OK || resultType == DialogResult.Cancel){
                btn_btn1.Text = "OK";
                btn_btn2.Text = "Cancel";
            }
        }


        private void btn_btn1_Click(object sender, EventArgs e)
        {
            if (resultType == DialogResult.Yes || resultType == DialogResult.No){
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
                
        }

        private void btn_btn2_Click(object sender, EventArgs e)
        {
            if (resultType == DialogResult.Yes || resultType == DialogResult.No)
            {
                this.DialogResult = DialogResult.No;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            
        }

        public void convertToOkButton()
        {
            btn_btn1.Hide();
            btn_btn2.Text = "OK";
            btn_btn2.BackColor = getColor(18,124,207);
            this.DialogResult = DialogResult.OK;
        }


        private Color getColor(int r, int g, int b)
        {
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(r, g, b);
            return myRgbColor;
        }
    }
}

using ShineWay.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShineWay.UI
{
    public partial class NewUser : Form
    {
        System.Drawing.Color closeBtnColor;
        string passwordPattern = "[a-zA-Z]+[0-9]+";
        string userName;

        public NewUser(string userName, string name)
        {
            InitializeComponent();
            closeBtnColor = btn_Close.ForeColor;
            this.userName = userName;
            label_welcome.Text = $"Welcome {name.Split(" ")[0]}!";
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            btn_Close.ForeColor = System.Drawing.Color.Red;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_Close.ForeColor = closeBtnColor;
        }

        private void btn_register_MouseHover(object sender, EventArgs e)
        {
            btn_register.Image = ShineWay.Properties.Resources.registerHover;
        }

        private void btn_register_MouseLeave(object sender, EventArgs e)
        {
            btn_register.Image = ShineWay.Properties.Resources.register;
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if(txt_newPassword.Text.Trim().Length == 0 || txt_confirmPassword.Text.Trim().Length == 0)
            {
                CustomMessage message = new CustomMessage("Password cannot be Empty!", "Error Dialog", ShineWay.Properties.Resources.error, DialogResult.OK);
                message.convertToOkButton();
                message.ShowDialog();
            }
            else
            {
                if (Regex.IsMatch(txt_newPassword.Text, passwordPattern) && txt_newPassword.Text.Length >= 8 && txt_newPassword.Text.Length <= 15 && txt_newPassword.Text == txt_confirmPassword.Text)
                {

                }
                else
                {
                    if (!(txt_newPassword.Text == txt_confirmPassword.Text))
                    {
                        CustomMessage message = new CustomMessage("Password fields Does \nnot match!", "Error Dialog", ShineWay.Properties.Resources.error, DialogResult.OK);
                        message.convertToOkButton();
                        message.ShowDialog();
                    }
                    else if (txt_newPassword.Text.Length < 8)
                    {
                        CustomMessage message = new CustomMessage("Minimum length of the \npassword is 8 charactors!", "Error Dialog", ShineWay.Properties.Resources.information, DialogResult.OK);
                        message.convertToOkButton();
                        message.ShowDialog();
                    }
                    else if (txt_newPassword.Text.Length > 15)
                    {
                        CustomMessage message = new CustomMessage("Maximum length of the \npassword is 15 charactors!", "Error Dialog", ShineWay.Properties.Resources.information, DialogResult.OK);
                        message.convertToOkButton();
                        message.ShowDialog();
                    }
                    else
                    {
                        CustomMessage message = new CustomMessage("Password should contain \nboth numbers and letters!", "Error Dialog", ShineWay.Properties.Resources.information, DialogResult.OK);
                        message.convertToOkButton();
                        message.ShowDialog();
                    }

                }
            }
            
        }
    }
}

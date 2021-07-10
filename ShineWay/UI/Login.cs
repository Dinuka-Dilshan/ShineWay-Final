using System;
using ShineWay.Beautify;
using System.Windows.Forms;
using ShineWay.DataBase;
using MySql.Data.MySqlClient;
using ShineWay.Messages;

namespace ShineWay.UI
{
    public partial class form_Login : Form
    {
        bool isSelectedToShowPassword = false;
        System.Drawing.Color closeBtnColor;

        public form_Login()
        {
            InitializeComponent();
            new DropShadow().ApplyShadows(this);
            closeBtnColor = btn_Close.ForeColor;
        }

        private void pb_loginBtn_MouseHover(object sender, EventArgs e)
        {
            pb_loginBtn.Image = ShineWay.Properties.Resources.loginHoverbtn;
        }

        private void pb_loginBtn_MouseLeave(object sender, EventArgs e)
        {
            pb_loginBtn.Image = ShineWay.Properties.Resources.loginbtn;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pb_loginBtn_Click(object sender, EventArgs e)
        {

            
            String userName = txt_userName.Text.Trim();
            String password = txt_password.Text.Trim();
            bool isPasswordCorrect = false;


            if (userName.Equals("") && password.Equals(""))
            {
                CustomMessage message = new CustomMessage("  Username and password \n  are empty!", "Error Dialog", ShineWay.Properties.Resources.information, DialogResult.OK);
                message.convertToOkButton();
                message.ShowDialog();
            }else if (password.Equals(""))
            {
                CustomMessage message = new CustomMessage("  Password is empty!", "Error Dialog", ShineWay.Properties.Resources.error, DialogResult.OK);
                message.convertToOkButton();
                message.ShowDialog();
            }else if (userName.Equals(""))
            {
                CustomMessage message = new CustomMessage(" Username is empty!", "Error Dialog", ShineWay.Properties.Resources.error, DialogResult.OK);
                message.convertToOkButton();
                message.ShowDialog();
            }
            else
            {
                string query = " SELECT `username`,`user_type` ,`name` FROM `users`   WHERE username = '" + userName + "' AND password = '" + password + "';";

                try
                {
                    MySqlDataReader reader = DbConnection.Read(query);
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == userName)
                        {
                            isPasswordCorrect = true;
                            this.Hide();
                            var form2 = new Home(reader[1].ToString(),reader[2].ToString());
                            form2.Closed += (s, args) => this.Close();
                            form2.Show();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }

                    if (!isPasswordCorrect)
                    {
                        CustomMessage message = new CustomMessage("     Username or password is \n     incorrect!", "Error Dialog", ShineWay.Properties.Resources.error, DialogResult.OK);
                        message.convertToOkButton();
                        message.ShowDialog();
                    }



                }
                catch (Exception ex)
                {
                    CustomMessage message = new CustomMessage("  Unable to connect to the \n  Database!", "Error Dialog", ShineWay.Properties.Resources.error, DialogResult.OK);
                    message.convertToOkButton();
                    message.ShowDialog();
                }
            }


            
        }

        private void btn_showPassword_Click(object sender, EventArgs e)
        {
            if (isSelectedToShowPassword)
            {
                isSelectedToShowPassword = false;
                txt_password.UseSystemPasswordChar = true;
                btn_showPassword.Image = ShineWay.Properties.Resources.eye;
            }
            else
            {
                isSelectedToShowPassword = true;
                txt_password.UseSystemPasswordChar = false;
                btn_showPassword.Image = ShineWay.Properties.Resources.hideEye;
            }
            
            
        }

        private void txt_userName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txt_password.Focus();
                e.SuppressKeyPress = true; //to remove the 'ding' sound
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                txt_password.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                txt_password.Focus();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                pb_loginBtn_Click(sender,e);
                e.SuppressKeyPress = true; //to remove the 'ding' sound
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                txt_userName.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                txt_userName.Focus();
            }
        }

        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            btn_Close.ForeColor = System.Drawing.Color.Red;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_Close.ForeColor = closeBtnColor;
        }

        private void label_forgotPassword_MouseClick(object sender, MouseEventArgs e)
        {
            //forgrt password

        }

        private void label_forgotPassword_MouseHover(object sender, EventArgs e)
        {
            label_forgotPassword.ForeColor = System.Drawing.Color.Black;
        }

        private void label_forgotPassword_MouseLeave(object sender, EventArgs e)
        {
            label_forgotPassword.ForeColor = System.Drawing.Color.FromArgb(64,64,64);
        }
    }
}

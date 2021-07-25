using MySql.Data.MySqlClient;
using System;
using ShineWay.DataBase;
using System.Drawing;
using System.Windows.Forms;
using ShineWay.Messages;
using ShineWay.Classes;

namespace ShineWay.UI
{
    public partial class ForgotPassword : Form
    {
        

        public ForgotPassword(string userName)
        {
            InitializeComponent();
            txt_username.Text = userName;
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
            btn_proceed.Image = ShineWay.Properties.Resources.proceedHover;
        }

        private void btn_register_MouseLeave(object sender, EventArgs e)
        {
            btn_proceed.Image = ShineWay.Properties.Resources.proceed;
        }

        private void btn_proceed_Click(object sender, EventArgs e)
        {
            

            string userName = txt_username.Text.Trim();
            string queryForExistence = $"SELECT `username`, `name`, `email` FROM `users` WHERE `username` = \"{userName}\"";

            MySqlDataReader reader = null;

            try
            {
                reader = DbConnection.Read(queryForExistence);

                while (reader.Read())
                {
                    if (reader[0].ToString().Equals(userName))
                    {

                        try
                        {
                            string temporaryPassword = randomString();
                            string query = $"UPDATE `users` SET`password`=\"{Encrypt.encryption(temporaryPassword)}\", `isFirstTimeUser`= 1 WHERE `username` = \"{reader[0].ToString()}\";";
                            DbConnection.Update(query);
                            string emailMessage = $"Dear {reader[1].ToString()},\nYour Password Has been Reset!.Please use the Username and the temporary password given below to login!\n\nUsername:  {reader[0].ToString()} \nTemporary password:  {temporaryPassword} \n\nThank you.\nShineWay Rental 2021";
                            Emails.sendEmail(reader[2].ToString(), "Welcome to ShineWay!", emailMessage);
                            CustomMessage message = new CustomMessage("Successfully Updated!", "Update", ShineWay.Properties.Resources.correct, DialogResult.OK);
                            message.convertToOkButton();
                            message.ShowDialog();
                            btn_Close.PerformClick();
                            return;
                        }
                        catch (Exception ex)
                        {
                            
                            CustomMessage message2 = new CustomMessage("Unable to Update!", "Error", ShineWay.Properties.Resources.error, DialogResult.OK);
                            message2.convertToOkButton();
                            message2.ShowDialog();
                            return;
                        }

                    }
                    else
                    {
                        return;
                        
                    }

                }

                CustomMessage message3 = new CustomMessage("Username Does Not Exist!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                message3.convertToOkButton();
                message3.ShowDialog();


            }
            catch (Exception exc)
            {
                reader.Close();
            }


            reader.Close();

        }


        public string randomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        private void btn_proceed_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}

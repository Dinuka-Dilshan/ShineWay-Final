using System;
using ShineWay.DataBase;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ShineWay.Validation;
using ShineWay.Messages;

namespace ShineWay.UI
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            combo_userType.SelectedIndex = 1;
        }

        private void pb_btnReset_MouseHover(object sender, EventArgs e)
        {
            pb_btnReset.Image = ShineWay.Properties.Resources.resetHover;
        }

        private void pb_btnReset_MouseLeave(object sender, EventArgs e)
        {
            pb_btnReset.Image = ShineWay.Properties.Resources.reset;
        }

        private void pb_btnAdd_MouseHover(object sender, EventArgs e)
        {
            pb_btnAdd.Image = ShineWay.Properties.Resources.addHover;
        }

        private void pb_btnAdd_MouseLeave(object sender, EventArgs e)
        {
            pb_btnAdd.Image = ShineWay.Properties.Resources.add;
        }

        private void pb_btnUpdate_MouseHover(object sender, EventArgs e)
        {
            pb_btnDelete.Image = ShineWay.Properties.Resources.updateHover;
        }

        private void pb_btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            pb_btnDelete.Image = ShineWay.Properties.Resources.update;
        }

        private void pb_btnDelete_MouseHover(object sender, EventArgs e)
        {
            pb_btnDelete.Image = ShineWay.Properties.Resources.deleteHover;
        }

        private void pb_btnDelete_MouseLeave(object sender, EventArgs e)
        {
            pb_btnDelete.Image = ShineWay.Properties.Resources.delete;
        }

        private void pb_btnReset_Click(object sender, EventArgs e)
        {
            //reset button code goes here
        }

        private void pb_btnAdd_Click(object sender, EventArgs e)
        {
            // add button code goes here
            MySqlDataReader reader;
            
            try
            {
                reader = DbConnection.Read("SELECT COUNT(`ID`) FROM `users`");
                while (reader.Read())
                {
                   
                }
                

                try
                {
                    String tempUserName = txt_name.Text.Trim().Split(" ")[0]+ (Int32.Parse(reader[0].ToString()) + 1);
                    String addQuery = $"INSERT INTO `users`(`username`, `password`, `NIC`, `name`, `user_type`, `Telephone`, `Address`) VALUES (  \"{tempUserName}\",  \"{ randomString()}\",  \"{txt_NIC.Text}\",   \"{txt_name.Text}\",   \"{combo_userType.Text}\",   \"{txt_telephoneNumber.Text}\",  \"{txt_address.Text}\")";

                    DbConnection.Write(addQuery);
                    CustomMessage message = new CustomMessage("User Added Successfully!", "Added", ShineWay.Properties.Resources.correct, DialogResult.OK);
                    message.convertToOkButton();
                    message.ShowDialog();

                }
                catch (Exception exe)
                {
                    new CustomMessage(exe.Message, "Inserted", ShineWay.Properties.Resources.correct, DialogResult.OK).ShowDialog();
                }
            }
            catch (Exception exe)
            {
                new CustomMessage(exe.Message, "Inserted", ShineWay.Properties.Resources.correct, DialogResult.OK).ShowDialog();
            }
            
           
            ;


        }

        private void pb_btnUpdate_Click(object sender, EventArgs e)
        {
            //update button code goes here
        }

        private void pb_btnDelete_Click(object sender, EventArgs e)
        {
            //delete button code goes here
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void txt_NIC_MouseLeave(object sender, EventArgs e)
        {



        }

        private void txt_telephoneNumber_MouseLeave(object sender, EventArgs e)
        {
            

        }

        
        private void label8_Click(object sender, EventArgs e)
        {
            CustomMessage submitmessege = new CustomMessage("Update Successfull!", "Updated", ShineWay.Properties.Resources.tick, DialogResult.OK);
            submitmessege.convertToOkButton();
            submitmessege.ShowDialog();
        }

        private void pb_btnDelete_Click_1(object sender, EventArgs e)
        {
            CustomMessage deletemessege = new CustomMessage("Deleted!", "Deleted", ShineWay.Properties.Resources.error, DialogResult.OK);

        }

        private void pb_btnReset_Click_1(object sender, EventArgs e)
        { 
            
            txt_name.Text = "";
            txt_address.Text = "";
            txt_NIC.Text = "";
            txt_telephoneNumber.Text = "";
            pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
            label_nicError.Visible = false;
            pictureBox9.Image = ShineWay.Properties.Resources.correctInput;
            label_telError.Visible = false;
            pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
            label_addressError.Visible = false;
            label_telTick.Visible = false;
            label_tickAddress.Visible = false;
            label_tickNIC.Visible = false;
            label_tickName.Visible = false;
        }

        

        private void txt_userName_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_name_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidName(txt_name.Text))
            {
                pictureBox5.Image = ShineWay.Properties.Resources.correctInput;
                label_nameError.Visible = false;
                label_tickName.Visible = true;
            }
            else
            {
                pictureBox5.Image = ShineWay.Properties.Resources.errorinput;
                label_nameError.Visible = true;
                label_tickName.Visible = false;
            }
        }

        private void txt_NIC_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidCustomerNewNIC(txt_NIC.Text)|| Validates.ValidCustomerOldNIC(txt_NIC.Text))
            {
                pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
                label_nicError.Visible = false;
                label_tickNIC.Visible = true;

            }
            else
            {
                pictureBox7.Image = ShineWay.Properties.Resources.errorinput;
                label_nicError.Visible = true;
                label_tickNIC.Visible = false;
            }
            
        }

        private void txt_telephoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidMobile(txt_telephoneNumber.Text))
            {
                pictureBox9.Image = ShineWay.Properties.Resources.correctInput;
                label_telError.Visible = false;
                label_telTick.Visible = true;

            }
            else
            {
                pictureBox9.Image = ShineWay.Properties.Resources.errorinput;
                label_telError.Visible = true;
                label_telTick.Visible = false;
            }
        }

        private void txt_address_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_address.Text.Length > 200 || (txt_address.Text.Length == 0))
            {
                pictureBox11.Image = ShineWay.Properties.Resources.errorinput;
                if((txt_address.Text.Length == 0))
                {
                    label_addressError.Text = "Address cannot be empty!";
                }
                else
                {
                    label_addressError.Text = "Cannot exceeds more than 200 charactors!";
                }
                label_addressError.Visible = true;
                label_tickAddress.Visible = false;
            }
            else
            {
                pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
                label_addressError.Visible = false;
                label_tickAddress.Visible = true;
            }
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

    }
}

using System;
using ShineWay.DataBase;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ShineWay.Validation;
using ShineWay.Messages;
using ShineWay.Classes;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace ShineWay.UI
{
    public partial class Users : UserControl
    {
        bool isNameValid = false;
        bool isNICValid = false;
        bool isTelephoneNumberValid = false;
        bool isAddressValid = false;
        bool isEmailValid = false;
        List<User> users = new List<User>();



        public Users()
        {
            InitializeComponent();
            combo_userType.SelectedIndex = 0;
            setDataToTable("SELECT  `NIC`, `name`, `user_type`, `Telephone`, `Address` FROM `users`");

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

        private void pb_btnReset_Click(object sender, EventArgs e)
        {
            //reset button code goes here
        }

        private void pb_btnAdd_Click(object sender, EventArgs e)
        {
            // add button code goes here
            
            MySqlDataReader reader;

            if(txt_NIC.Text.Trim() == "" || txt_name.Text.Trim() == "" || txt_telephoneNumber.Text.Trim() == "" || txt_address.Text.Trim() == "" || txt_email.Text.Trim() == "")
            {
                CustomMessage submitmessege = new CustomMessage("Please fill all the fields!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                submitmessege.convertToOkButton();
                submitmessege.ShowDialog();
            }
            else
            { 

                if (isAllValid())
                {
                    try
                    {
                        reader = DbConnection.Read("SELECT COUNT(`ID`) FROM `users`");
                        while (reader.Read())
                        {

                        }


                        try
                        {
                            String tempUserName = txt_name.Text.Trim().Split(" ")[0] + (Int32.Parse(reader[0].ToString()) + 1);
                            string temporaryPassword = randomString();
                            String addQuery = $"INSERT INTO `users`(`username`, `password`, `NIC`, `name`, `user_type`, `Telephone`, `Address` , `isFirstTimeUser`) VALUES (  \"{tempUserName}\",  \"{Encrypt.encryption(temporaryPassword)}\",  \"{txt_NIC.Text}\",   \"{txt_name.Text}\",   \"{combo_userType.Text}\",   \"{txt_telephoneNumber.Text}\",  \"{txt_address.Text}\", 1)";

                            string emailMessage = $"Welcome to Shineway rental!\nShineWay Rental Admin has added you to the system.Please use the Username and the temporary password to login!\n\nUsername:  {tempUserName} \nTemporary password:  {temporaryPassword} \n\nThank you.\nShineWay Rental 2021";
                            Emails.sendEmail(txt_email.Text.Trim(), "Welcome to ShineWay!", emailMessage);



                            DbConnection.Write(addQuery);
                            CustomMessage message = new CustomMessage("User Added Successfully!", "Added", ShineWay.Properties.Resources.correct, DialogResult.OK);
                            message.convertToOkButton();
                            message.ShowDialog();
                            pb_btnReset_Click_1(sender, e);

                        }
                        catch (Exception exe)
                        {
                            new CustomMessage("Connot insert!", "Error", ShineWay.Properties.Resources.correct, DialogResult.OK).ShowDialog();
                        }
                    }
                    catch (Exception exe)
                    {
                        new CustomMessage("Unable to connect!", "Error", ShineWay.Properties.Resources.correct, DialogResult.OK).ShowDialog();
                    }


                }
                else
                {
                    CustomMessage submitmessege = new CustomMessage("All fields must be corrected\n before submit!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                    submitmessege.convertToOkButton();
                    submitmessege.ShowDialog();
                }

            }

            setDataToTable("SELECT  `NIC`, `name`, `user_type`, `Telephone`, `Address` FROM `users`");

        }

        private void pb_btnUpdate_Click(object sender, EventArgs e)
        {
            //update button code goes here
        }

        private void pb_btnDelete_Click(object sender, EventArgs e)
        {
            //delete button code goes here
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


        private void pb_btnReset_Click_1(object sender, EventArgs e)
        { 
            
            txt_name.Text = "";
            txt_address.Text = "";
            txt_NIC.Text = "";
            txt_telephoneNumber.Text = "";
            txt_email.Text = "";
            pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox5.Image = ShineWay.Properties.Resources.correctInput;
            label_nicError.Visible = false;
            pictureBox9.Image = ShineWay.Properties.Resources.correctInput;
            label_telError.Visible = false;
            pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox3.Image = ShineWay.Properties.Resources.correctInput;
            label_addressError.Visible = false;
            label_telTick.Visible = false;
            label_tickAddress.Visible = false;
            label_tickNIC.Visible = false;
            label_tickName.Visible = false;
            label_tickEmail.Visible = false;
            label_emailError.Visible = false;
            label_nameError.Visible = false;
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
                isNameValid = true;
            }
            else
            {
                pictureBox5.Image = ShineWay.Properties.Resources.errorinput;
                label_nameError.Visible = true;
                label_tickName.Visible = false;
                isNameValid = false;
            }
        }

        private void txt_NIC_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidCustomerNewNIC(txt_NIC.Text)|| Validates.ValidCustomerOldNIC(txt_NIC.Text))
            {
                pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
                label_nicError.Visible = false;
                label_tickNIC.Visible = true;
                isNICValid = true;

            }
            else
            {
                pictureBox7.Image = ShineWay.Properties.Resources.errorinput;
                label_nicError.Visible = true;
                label_tickNIC.Visible = false;
                isNICValid = false;
            }
            
        }

        private void txt_telephoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidMobile(txt_telephoneNumber.Text.Trim()))
            {
                pictureBox9.Image = ShineWay.Properties.Resources.correctInput;
                label_telError.Visible = false;
                label_telTick.Visible = true;
                isTelephoneNumberValid = true;

            }
            else
            {
                pictureBox9.Image = ShineWay.Properties.Resources.errorinput;
                label_telError.Visible = true;
                label_telTick.Visible = false;
                isTelephoneNumberValid = false;
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
                isAddressValid = false;
            }
            else
            {
                pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
                label_addressError.Visible = false;
                label_tickAddress.Visible = true;
                isAddressValid = true;
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


        private bool isAllValid()
        {
            return (isNICValid && isNameValid && isTelephoneNumberValid && isAddressValid && isEmailValid);
        }



        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_MouseHover(object sender, EventArgs e)
        {
            btn_delete.Image = ShineWay.Properties.Resources.deleteHover;
        }

        private void btn_delete_MouseLeave(object sender, EventArgs e)
        {
            btn_delete.Image = ShineWay.Properties.Resources.delete;
        }

        private void txt_email_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidEmail(txt_email.Text.Trim()))
            {
                pictureBox3.Image = ShineWay.Properties.Resources.correctInput;
                label_emailError.Visible = false;
                label_tickEmail.Visible = true;
                isEmailValid = true;

            }
            else
            {
                pictureBox3.Image = ShineWay.Properties.Resources.errorinput;
                label_emailError.Visible = true;
                label_tickEmail.Visible = false;
                isEmailValid = false;
            }
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            string query = $"SELECT  `NIC`, `name`, `user_type`, `Telephone`, `Address` FROM `users` WHERE `NIC` LIKE \"%{txt_search.Text}%\" OR `name` LIKE \"%{txt_search.Text}%\" OR `user_type` LIKE \"%{txt_search.Text}%\"  OR `Telephone` LIKE \"%{txt_search.Text}%\" OR `Address` LIKE \"%{txt_search.Text}%\"";
            setDataToTable(query);
        }

        private void Users_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            //this.dataGridView1.GridColor = Color.BlueViolet;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(26,139,9);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.FromArgb(255, 255, 255);
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic bold", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridView1.ColumnHeadersDefaultCellStyle.BackColor;

        }


        void setDataToTable(string query)
        {
            MySqlDataReader reader = DbConnection.Read(query);

            

            while (reader.Read())
            {
                int x = dataGridView1.Rows.Add();
                dataGridView1.Rows[x].Cells[0].Value = reader.GetString("NIC");
                dataGridView1.Rows[x].Cells[1].Value = reader.GetString("name");
                dataGridView1.Rows[x].Cells[2].Value = reader.GetString("user_type");
                dataGridView1.Rows[x].Cells[3].Value = reader.GetString("Telephone");
                dataGridView1.Rows[x].Cells[4].Value = reader.GetString("Address");

                
            }
        }
    }
}

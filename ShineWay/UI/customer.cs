using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ShineWay.Messages;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShineWay.Validation;
using ShineWay.DataBase;
using ShineWay.Classes;

namespace ShineWay.UI
{
    public partial class customer : UserControl
    {
        //Validation.Validates obj1 = new Validation.Validates();
        
        bool isNICValid = false;
        bool isLicensenumberValid = false;
        bool isCusNameValid = false;
        bool isTelNumValid = false;
        bool isEmailValid = false;


        public customer()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

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
            pb_btnUpdate.Image = ShineWay.Properties.Resources.updateHover;
        }

        private void pb_btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            pb_btnUpdate.Image = ShineWay.Properties.Resources.update;
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
            // reset button code goes here
            txt_nicNumber.Text = "";
            txt_licenseNumber.Text = "";
            txt_customerName.Text = "";
            txt_telephoneNumber.Text = "";
            txt_email.Text = "";
            txt_address.Text = "";
            label_tickNIC.Visible = false;
            label_tickLicenseNum.Visible = false;
            label_tickName.Visible = false;
            label_tickTelNum.Visible = false;
            label_tickEmail.Visible = false;
            label_tickAddress.Visible = false;

        }

        private void pb_btnAdd_Click(object sender, EventArgs e)
        {
            // add button code goes here
            
                try
                {
                    DataBase.DbConnection.Read("insert into customer (Cus_NIC , Licen_num, Cus_name, Tel_num, Email , Cus_Address) Values" +
                    "('" + txt_nicNumber.Text + "','" + txt_licenseNumber.Text + "','" + txt_customerName.Text + "','" + txt_telephoneNumber.Text + "','" + txt_email.Text + "','"
                    + txt_address.Text + "')");

                CustomMessage message = new CustomMessage("User Added Successfully!", "Added", ShineWay.Properties.Resources.correct, DialogResult.OK);
                message.convertToOkButton();
                message.ShowDialog();
               
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void pb_btnUpdate_Click(object sender, EventArgs e)
        {
            // update button code goes here
        }

        private void pb_btnDelete_Click(object sender, EventArgs e)
        {
            //delete button code goes here
        }

        

        private void txt_nicNumber_Validated(object sender, EventArgs e)
        {
            
           
        }

        private void ValidCustomerOldNIC(object sender, EventArgs e)
        {

        }

        
        
        private void pictureBox3_Click_2(object sender, EventArgs e)
        {

        }

        private void txt_nicNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidCustomerNewNIC(txt_nicNumber.Text) || Validates.ValidCustomerOldNIC(txt_nicNumber.Text))
            {
                pictureBox2.Image = ShineWay.Properties.Resources.correctInput;
                label_nicError.Visible = false;
                label_tickNIC.Visible = true;
                isNICValid = true;

            }
            else
            {
                pictureBox2.Image = ShineWay.Properties.Resources.errorinput;
                label_nicError.Visible = true;
                label_tickNIC.Visible = false;
                isNICValid = false;
            }
        }

        private void txt_licenseNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidLicensenumber(txt_licenseNumber.Text))
            {
                pictureBox5.Image = ShineWay.Properties.Resources.correctInput;
                label_licenseError.Visible = false;
                label_tickLicenseNum.Visible = true;
                isLicensenumberValid = true;

            }
            else
            {
                pictureBox5.Image = ShineWay.Properties.Resources.errorinput;
                label_licenseError.Visible = true;
                label_tickLicenseNum.Visible = false;
                isLicensenumberValid = false;
            }
        }

        private void txt_customerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidName(txt_customerName.Text))
            {
                pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
                label_nameError.Visible = false;
                label_tickName.Visible = true;
                isCusNameValid = true;

            }
            else
            {
                pictureBox7.Image = ShineWay.Properties.Resources.errorinput;
                label_nameError.Visible = true;
                label_tickName.Visible = false;
                isCusNameValid = false;
            }
        }

        private void txt_telephoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidMobile(txt_telephoneNumber.Text))
            {
                pictureBox9.Image = ShineWay.Properties.Resources.correctInput;
                label_telnumberError.Visible = false;
                label_tickTelNum.Visible = true;
                isTelNumValid = true;

            }
            else
            {
                pictureBox9.Image = ShineWay.Properties.Resources.errorinput;
                label_telnumberError.Visible = true;
                label_tickTelNum.Visible = false;
                isTelNumValid = false;
            }
        }

        private void txt_email_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidEmail(txt_email.Text))
            {
                pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
                label_emailError.Visible = false;
                label_tickEmail.Visible = true;
                isEmailValid = true;

            }
            else
            {
                pictureBox11.Image = ShineWay.Properties.Resources.errorinput;
                label_emailError.Visible = true;
                label_tickEmail.Visible = false;
                isEmailValid = false;
            }
        }

        private void txt_address_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidateDescription(txt_address.Text))
            {
                pictureBox13.Image = ShineWay.Properties.Resources.correctInput;
                label_addressError.Visible = false;
                label_tickAddress.Visible = true;
                isEmailValid = true;

            }
            else
            {
                pictureBox13.Image = ShineWay.Properties.Resources.errorinput;
                label_addressError.Visible = true;
                label_tickAddress.Visible = false;
                isEmailValid = false;
            }
        }
    }
}

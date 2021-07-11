using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShineWay.Validation;

namespace ShineWay.UI
{
    public partial class customer : UserControl
    {
        //Validation.Validates obj1 = new Validation.Validates();
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
        }

        private void pb_btnAdd_Click(object sender, EventArgs e)
        {
            // add button code goes here
            
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

        

        private void txt_address_MouseLeave(object sender, EventArgs e)
        {
            bool address = Validates.ValidateDescription(txt_address.Text);

            if (address == false)
            {
                txt_address.ForeColor = Color.Red;
                Messages.CustomMessage errormessege = new Messages.CustomMessage("Maxium lenght of description is\n 150 charcters", "Too long", ShineWay.Properties.Resources.error, DialogResult.OK);
                errormessege.convertToOkButton();
                errormessege.ShowDialog();
            }
            else
            {
                txt_address.ForeColor = Color.Green;
            }
        }

      
        private void txt_nicNumber_Leave(object sender, EventArgs e)
        {
            bool oldnic = Validates.ValidCustomerOldNIC(txt_nicNumber.Text);
            bool newnic = Validates.ValidCustomerNewNIC(txt_nicNumber.Text);

            if (oldnic == true || newnic == true)
            {
                txt_nicNumber.ForeColor = Color.Green;
            }
            else
            {
                txt_nicNumber.ForeColor = Color.Red;
            }
        }

        private void txt_email_Leave(object sender, EventArgs e)
        {
            bool email = Validates.ValidEmail(txt_email.Text);
            if (email == false)
            {
                txt_email.ForeColor = Color.Red;
            }
            else
            {
                txt_email.ForeColor = Color.Green;
            }
        }

        private void txt_telephoneNumber_Leave(object sender, EventArgs e)
        {
            bool mobilenum = Validates.ValidMobile(txt_telephoneNumber.Text);
            if (mobilenum == false)
            {
                txt_telephoneNumber.ForeColor = Color.Red;
            }
            else
            {
                txt_telephoneNumber.ForeColor = Color.Green;
            }
        }

        private void txt_licenseNumber_Leave(object sender, EventArgs e)
        {
            bool licensenum = Validates.ValidLicensenumber(txt_licenseNumber.Text);
            if (licensenum == false)
            {
                txt_licenseNumber.ForeColor = Color.Red;
            }
            else
            {
                txt_licenseNumber.ForeColor = Color.Green;
            }
        }

        private void txt_customerName_Leave(object sender, EventArgs e)
        {
            bool cusname = Validates.ValidName(txt_customerName.Text);
            if (cusname == false)
            {
                txt_customerName.ForeColor = Color.Red;
            }
            else
            {
                txt_customerName.ForeColor = Color.Green;
            }
        }
    }
}

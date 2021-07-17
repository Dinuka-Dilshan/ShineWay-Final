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
using ShineWay.Messages;

namespace ShineWay.UI
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
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
            CustomMessage submitmessege = new CustomMessage("Recorded Successfull!", "Inserted", ShineWay.Properties.Resources.correct, DialogResult.OK);
            submitmessege.convertToOkButton();
            submitmessege.ShowDialog();


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

        private void txt_NIC_Leave(object sender, EventArgs e)
        {
            bool isValidOwnerNic1 = Validates.ValidCustomerNewNIC(txt_NIC.Text);
            bool isValidOwnerNic2 = Validates.ValidCustomerOldNIC(txt_NIC.Text);

            if (isValidOwnerNic1 == true || isValidOwnerNic2 == true)
            {
                txt_NIC.ForeColor = Color.Black;
            }
            else
            {
                txt_NIC.ForeColor = Color.Red;
                CustomMessage errmsg = new CustomMessage("Please Enter Correct \n NIC Number!", "Incorrect", ShineWay.Properties.Resources.error, DialogResult.OK);
                errmsg.convertToOkButton();
                errmsg.ShowDialog();
            }
        }

        private void txt_telephoneNumber_Leave(object sender, EventArgs e)
        {
            bool isValidTeleNo = Validates.validMobileNumber(txt_telephoneNumber.Text);
            if (isValidTeleNo == true)
            {
                txt_telephoneNumber.ForeColor = Color.Black;
            }
            else
            {
                txt_telephoneNumber.ForeColor = Color.Red;
                CustomMessage errmsg = new CustomMessage("Please Enter Correct \n Telephone Number!", "Incorrect", ShineWay.Properties.Resources.error, DialogResult.OK);
                errmsg.convertToOkButton();
                errmsg.ShowDialog();
            }
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
            txt_userName.Text = ""; 
            txt_name.Text = "";
            txt_address.Text = "";
            txt_NIC.Text = "";
            txt_telephoneNumber.Text = "";
            txt_password.Text="";
        }

        private void txt_name_Leave(object sender, EventArgs e)
        {
            bool cusname = Validates.ValidName(txt_name.Text);
            if (cusname == false)
            {
                txt_name.ForeColor = Color.Red;
                CustomMessage errmsg = new CustomMessage("Please Enter your Correct Name!\n Digits not allowed", "Incorrect", ShineWay.Properties.Resources.error, DialogResult.OK);
                errmsg.convertToOkButton();
                errmsg.ShowDialog();
            }
            else
            {
                txt_name.ForeColor = Color.Green;
            }
        }

        private void txt_userName_KeyUp(object sender, KeyEventArgs e)
        {
            pictureBox2.Image = ShineWay.Properties.Resources.errorinput;
            label_userNameError.Visible = true;
        }

        private void txt_name_KeyUp(object sender, KeyEventArgs e)
        {
            pictureBox2.Image = ShineWay.Properties.Resources.correctInput;
            label_userNameError.Visible = false;
        }
    }
}

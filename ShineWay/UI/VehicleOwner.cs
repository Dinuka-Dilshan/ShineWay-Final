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
    public partial class VehicleOwner : UserControl
    {
        public VehicleOwner()
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

        private void txt_nicNumber_MouseLeave(object sender, EventArgs e)
        {
            bool isNameValid = Validates.ValidCustomerNewNIC(txt_nicNumber.Text);
        }

        private void txt_email_MouseLeave(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (txt_email.Text.Length > 0)
            {
                if (!rEmail.IsMatch(txt_email.Text))
                {
                    MessageBox.Show("Invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Valid email address");
                }
            }
            }

        private void txt_nicNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nicNumber_Leave(object sender, EventArgs e)
        {
            
            bool validcustomernic1 = Validates.ValidCustomerOldNIC(txt_nicNumber.Text);
            bool validcustomernic2 = Validates.ValidCustomerNewNIC(txt_nicNumber.Text);

            if (validcustomernic1 == true || validcustomernic2 == true)
            {
                txt_nicNumber.ForeColor = Color.Green;
            }
            else
            {
                txt_nicNumber.ForeColor = Color.Red;
            }

            //Salutation

            if (validcustomernic1 == true || validcustomernic2 == true)
            {
                bool IsMaleN = Validates.ValidCustomermaleNewNIC(txt_nicNumber.Text);
                bool IsMaleO = Validates.ValidCustomermaleOldNIC(txt_nicNumber.Text);
                if (IsMaleN == true || IsMaleO == true)
                {
                    lbl_salutation.Text = "Mr";
                }
                else
                {
                    lbl_salutation.Text = "Ms";
                }
            }
            else
            {
                lbl_salutation.Text = "--";
            }

        }

        private void txt_ownerName_Leave(object sender, EventArgs e)
        {
            
            bool validname = Validates.ValidName(txt_ownerName.Text);
           

            if (validname == false)
            {
                txt_ownerName.ForeColor = Color.Red;
            }
            else
            {
                txt_ownerName.ForeColor = Color.Green;
            }
            
        }

        private void txt_telephone_Leave(object sender, EventArgs e)
        {
            
            bool validtelephone = Validates.ValidTelephone(txt_telephone.Text);
            

            if (validtelephone == false)
            {
                txt_telephone.ForeColor = Color.Red;
            }
            else
            {
                txt_telephone.ForeColor = Color.Green;
            }

        }

        private void txt_email_Leave(object sender, EventArgs e)
        {

            bool validemail = Validates.ValidownerEmail(txt_email.Text);


            if (validemail == false)
            {
                txt_email.ForeColor = Color.Red;
            }
            else
            {
                txt_email.ForeColor = Color.Green;
            }

        }

        private void txt_address_Leave(object sender, EventArgs e)
        {
            bool validaddress = Validates.ValidateDescription(txt_address.Text);

            if (validaddress == false)
            {
                txt_address.ForeColor = Color.Red;
            }
            else
            {
                txt_address.ForeColor = Color.Green;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void pb_btnReset_Click(object sender, EventArgs e)
        {
            txt_nicNumber.Text = "";
            txt_ownerName.Text = "";
            txt_telephone.Text = "";
            txt_email.Text = "";
            txt_address.Text = "";
            lbl_salutation.Text = "";
        }

        private void pb_btnAdd_Click(object sender, EventArgs e)
        {
            if (txt_nicNumber.ForeColor == Color.Green && txt_ownerName.ForeColor == Color.Green && txt_telephone.ForeColor == Color.Green && txt_email.ForeColor == Color.Green && txt_address.ForeColor == Color.Green)
            {
                try
                {
                    CustomMessage submitmessege = new CustomMessage("Recorded Successfull!", "Inserted", ShineWay.Properties.Resources.correct, DialogResult.OK);
                    submitmessege.convertToOkButton();
                    submitmessege.ShowDialog();

                    //add button database connection

                }
                catch (Exception ex)
                {
                    //  MessageBox.Show(ex.Message);
                }
            }
            else
            {
                CustomMessage errormessege1 = new CustomMessage("Unsuccessfull Record!\n\n Enter correct details", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege1.convertToOkButton();
                errormessege1.ShowDialog();
            }
        }

        private void pb_btnUpdate_Click(object sender, EventArgs e)
        {
            if (txt_nicNumber.ForeColor == Color.Green && txt_ownerName.ForeColor == Color.Green && txt_telephone.ForeColor == Color.Green && txt_email.ForeColor == Color.Green && txt_address.ForeColor == Color.Green)
            {
                try
                {
                    CustomMessage submitmessege = new CustomMessage("Update Successfull!", "Updated", ShineWay.Properties.Resources.tick, DialogResult.OK);
                    submitmessege.convertToOkButton();
                    submitmessege.ShowDialog();

                    // update button database connect

                }
                catch (Exception ex)
                {
                    //  MessageBox.Show(ex.Message);
                }
            }
            else
            {
                CustomMessage errormessege2 = new CustomMessage("Cannot Update\n\n Enter correct details", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege2.convertToOkButton();
                errormessege2.ShowDialog();
            }
        }

        private void pb_btnDelete_Click(object sender, EventArgs e)
        {
            CustomMessage deletemessege = new CustomMessage("Deleted!", "Deleted", ShineWay.Properties.Resources.error, DialogResult.OK);
            deletemessege.convertToOkButton();
            deletemessege.ShowDialog();

            // delete button datebase connect
      
        }
    }
}

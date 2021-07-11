using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShineWay.Validation;
using ShineWay.Messages;

namespace ShineWay.UI
{
    public partial class Booking : UserControl
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_depositAmount_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        // ++++++++++++++++ hoverings ++++++++++++++++

        private void pb_btnUpdatePrint_MouseHover(object sender, EventArgs e)
        {
            pb_btnUpdatePrint.Image = ShineWay.Properties.Resources.update_printHover;
        }

        private void pb_btnUpdatePrint_MouseLeave(object sender, EventArgs e)
        {
            pb_btnUpdatePrint.Image = ShineWay.Properties.Resources.update_print;
        }

        private void pb_btnReset_MouseHover(object sender, EventArgs e)
        {
            pb_btnReset.Image = ShineWay.Properties.Resources.resetHover;
        }

        private void pb_btnReset_MouseLeave(object sender, EventArgs e)
        {
            pb_btnReset.Image = ShineWay.Properties.Resources.reset;
        }

        private void pb_btnSubmitPrint_MouseHover(object sender, EventArgs e)
        {
            pb_btnSubmitPrint.Image = ShineWay.Properties.Resources.submit_printHover;
        }

        private void pb_btnSubmitPrint_MouseLeave(object sender, EventArgs e)
        {
            pb_btnSubmitPrint.Image = ShineWay.Properties.Resources.submit_print;
        }



        // ++++++++++++++++ button actions ++++++++++++++++

        private void pb_btnReset_Click(object sender, EventArgs e)
        {
             txt_bookingId.Text = "";
             txt_vehicleRegNumber.Text = "";
             txt_customerNic.Text = "";
             txt_licenseNumber.Text = "";
             txt_startingOdometer.Text = "";
             txt_depositAmount.Text = "";
             txt_advancedPayment.Text = "";
             txt_description.Text = "";
             date_startingDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
             date_endDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            
        }

        private void pb_btnUpdatePrint_Click(object sender, EventArgs e)
        {
            // update actions
        }

        private void pb_btnSubmitPrint_Click(object sender, EventArgs e)
        {
                if (    txt_bookingId.ForeColor==Color.Green &&
                        txt_vehicleRegNumber.ForeColor == Color.Green &&
                        txt_customerNic.ForeColor == Color.Green &&
                        txt_licenseNumber.ForeColor == Color.Green &&
                        //date_startingDate..ForeColor == Color.Green &&
                        txt_startingOdometer.ForeColor == Color.Green &&
                        //date_endDate.ForeColor == Color.Green &&
                        combo_packageType.ForeColor == Color.Green &&
                        txt_depositAmount.ForeColor == Color.Green &&
                        txt_advancedPayment.ForeColor == Color.Green &&
                        txt_description.ForeColor == Color.Green 
                )
            {
                try
                {
                    CustomMessage submitmessege = new CustomMessage("Booking Successfull!", "Inserted", ShineWay.Properties.Resources.tick, DialogResult.OK);
                    submitmessege.convertToOkButton();
                    submitmessege.ShowDialog();

                    //   MySqlDataReader reader1 = DbConnection.Read("INSERT INTO `booking` (`Vehicle_num`, `Booking_ID`, `Licen_num`, `Start_date`, `Start_ODO`, `Package_Type`, `Cus_NIC`, `Discription`) VALUES ('" + txt_vehicleRegNumber.Text + "', '" + txt_bookingId.Text + "', '" + txt_licenseNumber.Text + "', '" + date_startingDate.Text + "', '" + txt_startingOdometer.Text + "', '" + combo_packageType.Text + "', '" + txt_customerNic.Text + "', '" + txt_description.Text + "');");


                }
                catch (Exception ex)
                {
                    //  MessageBox.Show(ex.Message);
                }
            }
            else
            {
                CustomMessage errormessege1 = new CustomMessage("Booking Unsuccessfull!\n\n Enter correct values", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege1.convertToOkButton();
                errormessege1.ShowDialog();
            }
        }

        // ++++++++++++++++ validations ++++++++++++++++

        private void txt_bookingId_Leave(object sender, EventArgs e)
        {
            bool validbookingID = Validates.ValidBookingID(txt_bookingId.Text);
            if (validbookingID == false)
            {
                txt_bookingId.ForeColor = Color.Red;
            }
            else
            {
                txt_bookingId.ForeColor = Color.Green;
            }
        }

        private void txt_vehicleRegNumber_Leave(object sender, EventArgs e)
        {
            bool validVehicleNumber1 = Validates.ValidVehiclenumber1(txt_vehicleRegNumber.Text);
            bool validVehicleNumber2 = Validates.ValidVehiclenumber2(txt_vehicleRegNumber.Text);

            if (validVehicleNumber1 == true || validVehicleNumber2 == true)
            {
                txt_vehicleRegNumber.ForeColor = Color.Green;
            }
            else
            {
                txt_vehicleRegNumber.ForeColor = Color.Red;
            }
        }

       
        private void txt_customerNic_Leave(object sender, EventArgs e)
        {
            bool validcustomernic1 = Validates.ValidCustomerOldNIC(txt_customerNic.Text);
            bool validcustomernic2 = Validates.ValidCustomerNewNIC(txt_customerNic.Text);

            if (validcustomernic1 == true || validcustomernic2 == true)
            {
                txt_customerNic.ForeColor = Color.Green;
            }
            else
            {
                txt_customerNic.ForeColor = Color.Red;
            }
        }



        private void txt_licenseNumber_Leave(object sender, EventArgs e)
        {
            bool licensenumber = Validates.ValidLicensenumber(txt_licenseNumber.Text);

            if (licensenumber == false)
            {
                txt_licenseNumber.ForeColor = Color.Red;
            }
            else
            {
                txt_licenseNumber.ForeColor = Color.Green;
            }
        }



        private void txt_startingOdometer_MouseLeave(object sender, EventArgs e)
        {
            bool startodo = Validates.ValidOdometer(txt_startingOdometer.Text);

            if (startodo == false)
            {
                txt_startingOdometer.ForeColor = Color.Red;
            }
            else
            {
                txt_startingOdometer.ForeColor = Color.Green;
            }
        }

        private void txt_startingOdometer_Leave(object sender, EventArgs e)
        {
            bool startodo = Validates.ValidOdometer(txt_startingOdometer.Text);

            if (startodo == false)
            {
                txt_startingOdometer.ForeColor = Color.Red;
            }
            else
            {
                txt_startingOdometer.ForeColor = Color.Green;
            }
        }

        private void txt_depositAmount_Enter(object sender, EventArgs e)
        {
            txt_depositAmount.TextAlign = HorizontalAlignment.Left;
        }

        private void txt_depositAmount_Leave(object sender, EventArgs e)
        {
            bool depositeamount = Validates.ValidAmount(txt_depositAmount.Text);

            if (depositeamount == false)
            {
                txt_depositAmount.ForeColor = Color.Red;
            }
            else
            {
                txt_depositAmount.ForeColor = Color.Green;
                txt_depositAmount.TextAlign = HorizontalAlignment.Right;
            }
        }

        private void txt_advancedPayment_Enter(object sender, EventArgs e)
        {
            txt_advancedPayment.TextAlign = HorizontalAlignment.Left;
        }

        private void txt_advancedPayment_Leave(object sender, EventArgs e)
        {
            bool advanceamount = Validates.ValidAmount(txt_advancedPayment.Text);
            if (advanceamount == false)
            {
                txt_advancedPayment.ForeColor = Color.Red;
            }
            else
            {
                txt_advancedPayment.ForeColor = Color.Green;
                txt_advancedPayment.TextAlign = HorizontalAlignment.Right;
            }
        }

        private void txt_description_Leave(object sender, EventArgs e)
        {
            bool description = Validates.ValidateDescription(txt_description.Text);

            if (description == false)
            {
                txt_description.ForeColor = Color.Red;
              //  MessageBox.Show("Maxium lenght of description is 150 charcters", "Too long", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CustomMessage errormessege = new CustomMessage("Maxium lenght of description is\n 150 charcters", "Too long", ShineWay.Properties.Resources.error, DialogResult.OK);
                errormessege.convertToOkButton();
                errormessege.ShowDialog();
            }
            else
            {
                txt_description.ForeColor = Color.Green;
            }
        }


        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            // search in database
        }

        private void combo_packageType_TextChanged(object sender, EventArgs e)
        {
            combo_packageType.ForeColor = Color.Green;
        }
    }
}

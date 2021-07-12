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
using ShineWay.DataBase;
using ShineWay.Validation;
using ShineWay.Messages;

namespace ShineWay.UI
{
    public partial class Payment : UserControl
    {
        DataBase.DbConnection ObjDb = new DataBase.DbConnection();
        public Payment()
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

        private void pb_btnSubmitPrint_MouseHover(object sender, EventArgs e)
        {
            pb_btnSubmitPrint.Image = ShineWay.Properties.Resources.submit_printHover;
        }

        private void pb_btnSubmitPrint_MouseLeave(object sender, EventArgs e)
        {
            pb_btnSubmitPrint.Image = ShineWay.Properties.Resources.submit_print;
        }

        private void pb_btnReset_Click(object sender, EventArgs e)
        {
            //reset button code goes here
        }

        private void pb_btnSubmitPrint_Click(object sender, EventArgs e)
        {
            //submit & reset button code goes here
            if (txt_bookingId.ForeColor == Color.Green && txt_vehicleRegNumber.ForeColor == Color.Green && txt_customerNic.ForeColor == Color.Green && combo_status.ForeColor == Color.Green && txt_endingOdometer.ForeColor == Color.Green && txt_discount.ForeColor == Color.Green)
            {
                try
                {
                    //DbConnection.Read("INSERT INTO `payment`(`Booking_ID`, `Cust_NIC`, `Vehicle_num`, `Status`, `End_date`, `End_ODO`, `Amount`, `Discount`, `Sub_Amount`) VALUES" + "('" + txt_bookingId.Text + "','" + txt_vehicleRegNumber.Text + "','" + txt_customerNic.Text + "','" + combo_status.Text + "','" + date_endDate.Text + "','" + txt_endingOdometer.Text + "','" + txt_amount.Text + "','" + txt_discount.Text + "','" + txt_subAmount.Text + "')");

                    CustomMessage submitmessege = new CustomMessage("Payment Successfull!", "Inserted", ShineWay.Properties.Resources.tick, DialogResult.OK);
                    submitmessege.convertToOkButton();
                    submitmessege.ShowDialog();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);

                }
            }
            else
            {
                CustomMessage errormessege1 = new CustomMessage("Payment Unsuccessfull!\n\n Enter correct values", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege1.convertToOkButton();
                errormessege1.ShowDialog();
            }
        }

        private void txt_bookingId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
  

        private void pb_btnUpdatePrint_Click(object sender, EventArgs e)
        {

        }

        private void txt_bookingId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txt_vehicleRegNumber.Focus();
                e.SuppressKeyPress = true; 
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                txt_vehicleRegNumber.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                txt_vehicleRegNumber.Focus();
            }
        }

        private void txt_vehicleRegNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txt_customerNic.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                txt_customerNic.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                txt_customerNic.Focus();
            }
        }

        private void txt_customerNic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                combo_status.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                combo_status.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                combo_status.Focus();
            }
        }

        private void combo_status_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                date_endDate.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                date_endDate.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                date_endDate.Focus();
            }
        }

        private void date_endDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txt_endingOdometer.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                txt_endingOdometer.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                txt_endingOdometer.Focus();
            }
        }

        private void txt_endingOdometer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                txt_discount.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                txt_discount.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                txt_discount.Focus();
            }
        }

        private void txt_discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                pb_btnSubmitPrint_Click(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                txt_bookingId.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                txt_bookingId.Focus();
            }
        }

        private void txt_bookingId_Leave(object sender, EventArgs e)
        {
            bool bookingid = Validates.ValidBookingID(txt_bookingId.Text);
            if (bookingid == false)
            {
                txt_bookingId.ForeColor = Color.Red;
            }
            else
            {
                txt_bookingId.ForeColor = Color.Green;
            }
        }

        private void txt_vehicleRegNumber_Leave_1(object sender, EventArgs e)
        {
            bool vehiclenumb1 = Validates.ValidVehiclenumber1(txt_vehicleRegNumber.Text);
            bool vehiclenumb2 = Validates.ValidVehiclenumber2(txt_vehicleRegNumber.Text);
            if (vehiclenumb1 == true || vehiclenumb2 == true)
            {
                txt_vehicleRegNumber.ForeColor = Color.Green;
            }
            else
            {
                txt_vehicleRegNumber.ForeColor = Color.Red;
            }
        }

        private void txt_customerNic_Leave_1(object sender, EventArgs e)
        {
            bool customernic1 = Validates.ValidCustomerNewNIC(txt_customerNic.Text);
            bool customernic2 = Validates.ValidCustomerOldNIC(txt_customerNic.Text);
            if (customernic1 == true || customernic2 == true)
            {
                txt_customerNic.ForeColor = Color.Green;
            }
            else
            {
                txt_customerNic.ForeColor = Color.Red;
            }
        }

        private void combo_status_Leave(object sender, EventArgs e)
        {
            bool status = Validates.ValidateStatus(combo_status.Text);
            if (status == false)
            {
                combo_status.ForeColor = Color.Red;
            }
            else
            {
                combo_status.ForeColor = Color.Green;
            }
        }

        private void txt_endingOdometer_Leave_1(object sender, EventArgs e)
        {
            bool endodo = Validates.ValidEndOdoMeter(txt_endingOdometer.Text);
            if (endodo == false)
            {
                txt_endingOdometer.ForeColor = Color.Red;
            }
            else
            {
                txt_endingOdometer.ForeColor = Color.Green;
            }
        }

        private void txt_discount_Leave(object sender, EventArgs e)
        {
            bool discount = Validates.ValidAmount(txt_discount.Text);
            if (discount == false)
            {
                txt_discount.ForeColor = Color.Red;
            }
            else
            {
                txt_discount.ForeColor = Color.Green;
            }
        }
    }
}

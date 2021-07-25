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
using ShineWay.DataBase;
using ShineWay.Classes;

namespace ShineWay.UI
{
    public partial class Booking : UserControl
    {

        List<Booking1> bookings = new List<Booking1>();

        public Booking()
        {
            InitializeComponent();
           // date_startingDate.MinDate = DateTime.Now;
           // date_endDate.MinDate = DateTime.Now;
            //setDataToGrid();
        }

        /*public void setDataToGrid()
        {

            try
            {
                MySqlDataReader reader1 = DbConnection.Read("SELECT `Booking_ID`,`Vehicle_num`,`Cus_NIC`,`Licen_num`,`Start_date`, `Start_ODO`,`Package_Type`,`Discription` FROM `booking`");
              //  MySqlDataReader reader2 = DbConnection.Read("SELECT `Booking_ID`,`Vehicle_num`,`Cus_NIC`,`Licen_num`,`Start_date`,`Package_Type`,`Discription` FROM `booking`");

                while (reader1.Read())
                {
                    Booking1 Booking = new Booking1();
                    Booking.Booking_ID = reader1[0].ToString();
                    Booking.Vehicle_Number = reader1[1].ToString();
                    Booking.Customer_NIC = reader1[2].ToString();
                    Booking.License_Number = reader1[3].ToString();
                    Booking.Start_Date = reader1[4].ToString();
                    Booking.Start_Odometer = reader1[5].ToString();
                    //
                    Booking.Package_Type = reader1[6].ToString();
                    //
                    //
                    Booking.Description = reader1[7].ToString();
                    
                    
                    bookings.Add(Booking);
                }
            }
            catch (Exception ex)
            {
                CustomMessage submitmessege = new CustomMessage("meken tmi awla enne", "error", ShineWay.Properties.Resources.error, DialogResult.OK);
                submitmessege.convertToOkButton();
                submitmessege.ShowDialog();
            }

            dgv_Booking.DataSource = bookings;
        }*/

        private void dgv_Booking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Booking.Rows[e.RowIndex];

                txt_bookingId.Text = dgv_Booking.CurrentRow.Cells[0].Value.ToString();
                txt_vehicleRegNumber.Text = dgv_Booking.CurrentRow.Cells[1].Value.ToString();
                txt_customerNic.Text = dgv_Booking.CurrentRow.Cells[2].Value.ToString();
                txt_licenseNumber.Text = dgv_Booking.CurrentRow.Cells[3].Value.ToString();
                date_startingDate.Text = dgv_Booking.CurrentRow.Cells[4].Value.ToString();
                txt_startingOdometer.Text = dgv_Booking.CurrentRow.Cells[5].Value.ToString();
                // date_endDate.Text = row.Cells[""].Value.ToString();
               combo_packageType.Text = dgv_Booking.CurrentRow.Cells[6].Value.ToString();
                //deposite amount
                //advanced payment
                txt_description.Text = dgv_Booking.CurrentRow.Cells[7].Value.ToString();
            }
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
            date_startingDate.Value = DateTime.Now;
            date_endDate.Value = DateTime.Now; 
            lbl_bookingIDError.Visible = false;
            lbl_bookingIDCorrect.Visible = false;
            lbl_vehicleNumberCorrect.Visible = false;
            lbl_vehicleNumberError.Visible = false;
            lbl_customerNICCorrect.Visible = false;
            lbl_customerNICError.Visible = false;
            lbl_licenseNumberCorrect.Visible = false;
            lbl_licenseNumberError.Visible = false;
            lbl_odomemterCorrect.Visible = false;
            lbl_odomemterError.Visible = false;
            lbl_packageTypeCorrect.Visible = false;
            lbl_packageTypeError.Visible = false;
            lbl_depositeAmountCorrect.Visible = false;
            lbl_depositeAmountError.Visible = false;
            lbl_advancedPayementCorrect.Visible = false;
            lbl_advancedPayementError.Visible = false;
            lbl_discriptionError.Visible = false;


        }

        private void pb_btnUpdatePrint_Click(object sender, EventArgs e)
        {
            // update actions

            if (lbl_bookingIDError.Visible == false &&
                    lbl_vehicleNumberError.Visible == false &&
                    lbl_customerNICError.Visible == false &&
                    lbl_licenseNumberError.Visible == false &&
                    lbl_odomemterError.Visible == false &&
                    lbl_packageTypeError.Visible == false &&
                    lbl_depositeAmountError.Visible == false &&
                    lbl_advancedPayementError.Visible == false &&
                    lbl_discriptionError.Visible == false &&
                    txt_vehicleRegNumber.Text != "" &&
                    txt_customerNic.Text != "" &&
                    txt_startingOdometer.Text != "" &&
                    combo_packageType.Text != "" &&
                    txt_depositAmount.Text != ""

               )
            {
                try
                {
                    CustomMessage submitmessege = new CustomMessage("Update Successfull!", "Updates", ShineWay.Properties.Resources.tick, DialogResult.OK);
                    submitmessege.convertToOkButton();
                    submitmessege.ShowDialog();

                    MySqlDataReader reader1 = DbConnection.Read("UPDATE `booking` SET `Vehicle_num`='" + txt_vehicleRegNumber.Text.Trim() + "',`Cus_NIC` = '" + txt_customerNic.Text.Trim() + "',`Licen_num`='" + txt_licenseNumber.Text.Trim() + "',`Start_date`='" + date_startingDate.Text + "',`Start_ODO`='" + txt_startingOdometer.Text.Trim() + "',`Package_Type`='" + combo_packageType.Text + "',`Discription`='" + txt_description.Text.Trim() + "' WHERE `booking`.`Booking_ID` = '" + txt_bookingId.Text.Trim() + "';");

                    //setDataToGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                CustomMessage errormessege1 = new CustomMessage("Unsuccessfull Update!\n\n Enter correct details", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege1.convertToOkButton();
                errormessege1.ShowDialog();
            }
        }

        private void pb_btnSubmitPrint_Click(object sender, EventArgs e)
        {
            // check package type selected
            btn_Refresh.Visible = true;
            
            if (combo_packageType.Text == "")
            {
                lbl_packageTypeError.Visible = true;
                lbl_packageTypeCorrect.Visible = false;
            }
            

            if (    lbl_bookingIDError.Visible == false &&
                    lbl_vehicleNumberError.Visible == false &&
                    lbl_customerNICError.Visible == false &&
                    lbl_licenseNumberError.Visible == false &&
                    lbl_odomemterError.Visible == false &&
                    lbl_packageTypeError.Visible == false &&
                    lbl_depositeAmountError.Visible == false &&
                    lbl_advancedPayementError.Visible == false &&
                    lbl_discriptionError.Visible == false &&
                    txt_vehicleRegNumber.Text != "" &&
                    txt_customerNic.Text != "" &&
                    txt_startingOdometer.Text != "" &&
                    combo_packageType.Text != "" &&
                    txt_depositAmount.Text != "" &&
                    date_startingDate.MinDate == DateTime.Now  &&
                    date_endDate.MinDate == DateTime.Now


                )
            {
                try
                {
                    CustomMessage submitmessege = new CustomMessage("Booking Successfull!", "Inserted", ShineWay.Properties.Resources.correct, DialogResult.OK);
                    submitmessege.convertToOkButton();
                    submitmessege.ShowDialog();

                    MySqlDataReader reader3 = DbConnection.Read("INSERT INTO `booking` (`Vehicle_num`, `Booking_ID`, `Licen_num`, `Start_date`, `Start_ODO`, `Package_Type`, `Cus_NIC`, `Discription`) VALUES ('" + txt_vehicleRegNumber.Text.Trim() + "', '" + txt_bookingId.Text.Trim() + "', '" + txt_licenseNumber.Text + "', '" + date_startingDate.Text+ "', '" + txt_startingOdometer.Text + "', '" + combo_packageType.Text + "', '" + txt_customerNic.Text + "', '" + txt_description.Text + "');");
                    MySqlDataReader reader4 = DbConnection.Read("INSERT INTO `payment` ( `Booking_ID`, `Cust_NIC`,`Vehicle_num`,`Status`, `End_date`) VALUES ('" + txt_bookingId.Text.Trim() + "', '" + txt_customerNic.Text.Trim() + "', '" + txt_vehicleRegNumber.Text.Trim() + "', 'Ongoing', '" +date_endDate.Text + "');");

                    //setDataToGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Test for error");
                }
            }
            else
            {
                CustomMessage errormessege1 = new CustomMessage("Booking Unsuccessfull!\n\n Enter correct details", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege1.convertToOkButton();
                errormessege1.ShowDialog();
            }
        }

        // ++++++++++++++++ search ++++++++++++++++

        private void txt_search_TextChanged(object sender, EventArgs e)
        {

        }

        public void searchData(string valueToSearch)
        {
           
        }
        // ++++++++++++++++ validations ++++++++++++++++

        private void txt_bookingId_Leave(object sender, EventArgs e)
        {
            bool validbookingID = Validates.ValidBookingID(txt_bookingId.Text.Trim());
            if (validbookingID == false)
            {
                lbl_bookingIDError.Visible = true;
                lbl_bookingIDCorrect.Visible = false;
            }
            else
            {
                lbl_bookingIDError.Visible = false;
                lbl_bookingIDCorrect.Visible = true;
            }
        }

        private void txt_vehicleRegNumber_Leave(object sender, EventArgs e)
        {
            bool validVehicleNumber1 = Validates.ValidVehiclenumber1(txt_vehicleRegNumber.Text.Trim());
            bool validVehicleNumber2 = Validates.ValidVehiclenumber2(txt_vehicleRegNumber.Text.Trim());

            if (validVehicleNumber1 == true || validVehicleNumber2 == true)
            {
                lbl_vehicleNumberCorrect.Visible = true;
                lbl_vehicleNumberError.Visible = false;
            }
            else
            {
                lbl_vehicleNumberCorrect.Visible = false;
                lbl_vehicleNumberError.Visible = true;
            }
        }

       
        private void txt_customerNic_Leave(object sender, EventArgs e)
        {
            bool validcustomernic1 = Validates.ValidCustomerOldNIC(txt_customerNic.Text.Trim());
            bool validcustomernic2 = Validates.ValidCustomerNewNIC(txt_customerNic.Text.Trim());

            if (validcustomernic1 == true || validcustomernic2 == true)
            {
                lbl_customerNICCorrect.Visible = true;
                lbl_customerNICError.Visible = false;
            }
            else
            {
                lbl_customerNICError.Visible = true;
                lbl_customerNICCorrect.Visible = false;
            }
        }



        private void txt_licenseNumber_Leave(object sender, EventArgs e)
        {
            bool licensenumber = Validates.ValidLicensenumber(txt_licenseNumber.Text);

            if (licensenumber == false)
            {
                lbl_licenseNumberError.Visible = true;
                lbl_licenseNumberCorrect.Visible = false;
            }
            else
            {
                lbl_licenseNumberError.Visible = false;
                lbl_licenseNumberCorrect.Visible = true;
            }
        
        }

    
    
        private void txt_startingOdometer_MouseLeave(object sender, EventArgs e)
        {
            bool startodo = Validates.ValidOdometer(txt_startingOdometer.Text);

            if (startodo == false)
            {
                lbl_odomemterError.Visible = true;
                lbl_odomemterCorrect.Visible = false;

            }
            else
            {
                lbl_odomemterError.Visible = false;
                lbl_odomemterCorrect.Visible = true;
            }
        }

        private void txt_startingOdometer_Leave(object sender, EventArgs e)
        {
            bool startodo = Validates.ValidOdometer(txt_startingOdometer.Text.Trim());

            if (startodo == false)
            {
                lbl_odomemterError.Visible = true;
                lbl_odomemterCorrect.Visible = false;
            }
            else
            {
                lbl_odomemterError.Visible = false;
                lbl_odomemterCorrect.Visible = true;
            }
        }

        private void txt_depositAmount_Enter(object sender, EventArgs e)
        {
            txt_depositAmount.TextAlign = HorizontalAlignment.Left;
        }

        private void txt_depositAmount_Leave(object sender, EventArgs e)
        {
            bool depositeamount = Validates.ValidAmount(txt_depositAmount.Text.Trim());

            if (depositeamount == false)
            {
                lbl_depositeAmountError.Visible = true;
                lbl_depositeAmountCorrect.Visible = false;
            }
            else
            {
                lbl_depositeAmountError.Visible = false;
                lbl_depositeAmountCorrect.Visible = true;
                txt_depositAmount.TextAlign = HorizontalAlignment.Right;
            }
        }

        private void txt_advancedPayment_Enter(object sender, EventArgs e)
        {
            txt_advancedPayment.TextAlign = HorizontalAlignment.Left;
        }

        private void txt_advancedPayment_Leave(object sender, EventArgs e)
        {
            bool advanceamount = Validates.ValidAmount(txt_advancedPayment.Text.Trim());
            if (advanceamount == false)
            {
                lbl_advancedPayementError.Visible = true;
                lbl_advancedPayementCorrect.Visible = false;

            }
            else
            {
                lbl_advancedPayementError.Visible = false;
                lbl_advancedPayementCorrect.Visible = true;
                txt_advancedPayment.TextAlign = HorizontalAlignment.Right;
            }
        }

        private void txt_description_Leave(object sender, EventArgs e)
        {
            bool description = Validates.ValidateDescription(txt_description.Text);

            if (description == false)
            {
                lbl_depositeAmountError.Visible = true;
                lbl_depositeAmountCorrect.Visible = false;

              //  MessageBox.Show("Maxium lenght of description is 150 charcters", "Too long", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              //  CustomMessage errormessege = new CustomMessage("Maxium lenght of description is\n 150 charcters", "Too long", ShineWay.Properties.Resources.error, DialogResult.OK);
              //  errormessege.convertToOkButton();
              //  errormessege.ShowDialog();
            }
            else
            {
                lbl_depositeAmountError.Visible = false;
                lbl_depositeAmountCorrect.Visible = true;
            }
        }


        

        private void combo_packageType_TextChanged(object sender, EventArgs e)
        {
            if(combo_packageType.Text != "")
            {
                lbl_packageTypeError.Visible = false;
                lbl_packageTypeCorrect.Visible = true;
            }
            
        }

        private void txt_bookingId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txt_vehicleRegNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txt_customerNic_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txt_licenseNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txt_startingOdometer_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void date_endDate_Leave(object sender, EventArgs e)
        {
            if (date_startingDate.Value > date_endDate.Value)
            {
                /////////////////////////////
            }
        }

        private void date_startingDate_Leave(object sender, EventArgs e)
        {
            date_endDate.MinDate = date_startingDate.Value;
          
        }

        private void combo_packageType_Leave(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            /////////////////////  
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            dgv_Booking.BorderStyle = BorderStyle.None;
            //this.dataGridView1.GridColor = Color.BlueViolet;
            dgv_Booking.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_Booking.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            // dgv_Booking.DefaultCellStyle.SelectionBackColor = Color.FromArgb(26, 139, 9);
            dgv_Booking.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_Booking.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgv_Booking.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional
            dgv_Booking.EnableHeadersVisualStyles = false;
            dgv_Booking.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_Booking.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic bold", 12);
            dgv_Booking.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dgv_Booking.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_Booking.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            dgv_Booking.RowHeadersVisible = false;
            dgv_Booking.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv_Booking.ColumnHeadersDefaultCellStyle.BackColor;
        }
    }
}

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
        bool IsValidPackagetype = false;

        public Booking()
        {
            InitializeComponent();
            setDataToGrid("SELECT `booking`.`Booking_ID`,`booking`.`Vehicle_num`,`booking`.`Cus_NIC`,`booking`.`Licen_num`,`Start_date`, `Start_ODO`,`End_date`,`Package_Type`,`Deposite_Amount`,`Advance_Payment`,`Discription` FROM `booking`, `payment` WHERE `booking`.`Booking_ID`=`payment`.`Booking_ID`");
            getNextBookingID();
           

        }

        //////++++++methods+++++++

        private void getNextBookingID()                                                                     // autmatically update the next booking ID
        {
            MySqlDataReader getfinalid = DbConnection.Read("SELECT MAX(Booking_ID) FROM booking");
            while (getfinalid.Read())
            {
                string LastBookingID = getfinalid[0].ToString();
                int NewBookingID = Int16.Parse(LastBookingID) + 1;
                txt_bookingId.Text = NewBookingID.ToString();
            }
        }
        
       
        
        public void selectPackageType()                                                                     // prevent entering a incorrect package type
        {
            int dateDifference =Convert.ToInt16((date_endDate.Value - date_startingDate.Value).TotalDays);

            if (dateDifference < 30 && (combo_packageType.Text == "Monthly Basis" || combo_packageType.Text == ""))
            {
                lbl_packageTypeError.Visible = true;
                IsValidPackagetype = false;
            }
            else
            {
                lbl_advancedPayementError.Visible = false;
                IsValidPackagetype = true;
            }
           
            if(dateDifference < 6 && (combo_packageType.Text == "Monthly Basis" || combo_packageType.Text == "Weekly Basis" || combo_packageType.Text == ""))
            {
                lbl_packageTypeError.Visible = true;
                IsValidPackagetype = false;
            }
            else
            {
                lbl_advancedPayementError.Visible = false;
                IsValidPackagetype = true;
            }
            
            if (dateDifference < 0 && (combo_packageType.Text == "Monthly Basis" || combo_packageType.Text == "Weekly Basis" || combo_packageType.Text == "Daily Basis" || combo_packageType.Text == "")) {
                lbl_packageTypeError.Visible = true;
                IsValidPackagetype = false;
            }
            else
            {
                lbl_advancedPayementError.Visible = false;
                IsValidPackagetype = true;
            }
        }
       

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
           // selectPackageType();
        }

        public void setDataToGrid(string query)                                     // det data to datagridview
        {
                dgv_Booking.Rows.Clear();
                dgv_Booking.Refresh();
            try
            {
                //MySqlDataReader reader = DbConnection.Read(query);
            
                MySqlDataReader reader1 = DbConnection.Read(query);
                if(reader1 != null)
                {
                    try
                    {
                        while (reader1.Read())
                        {
                            int x = dgv_Booking.Rows.Add();

                            dgv_Booking.Rows[x].Cells[0].Value = reader1.GetString("Booking_ID");
                            dgv_Booking.Rows[x].Cells[1].Value = reader1.GetString("Vehicle_num");
                            dgv_Booking.Rows[x].Cells[2].Value = reader1.GetString("Cus_NIC");
                            dgv_Booking.Rows[x].Cells[3].Value = reader1.GetString("Licen_num");
                            dgv_Booking.Rows[x].Cells[4].Value = reader1.GetString("Start_date");
                            dgv_Booking.Rows[x].Cells[5].Value = reader1.GetString("Start_ODO");
                            dgv_Booking.Rows[x].Cells[6].Value = reader1.GetString("End_date");
                            dgv_Booking.Rows[x].Cells[7].Value = reader1.GetString("Package_Type");
                            dgv_Booking.Rows[x].Cells[8].Value = reader1.GetString("Deposite_Amount");
                            dgv_Booking.Rows[x].Cells[9].Value = reader1.GetString("Advance_Payment");
                            dgv_Booking.Rows[x].Cells[10].Value = reader1.GetString("Discription");
                        }
                    }
                    catch (Exception e)
                    {

                        MessageBox.Show(e.Message);
                    }
                }
                

            }
            catch(Exception e) { 

                MessageBox.Show(e.Message);
            }
            
        }


        private void dgv_Booking_CellContentClick(object sender, DataGridViewCellEventArgs e)                       //set data to relevant columns in datagrd view
        {
                txt_bookingId.Text = dgv_Booking.SelectedRows[0].Cells[0].Value.ToString();
                txt_vehicleRegNumber.Text = dgv_Booking.SelectedRows[0].Cells[1].Value.ToString();
                txt_customerNic.Text = dgv_Booking.SelectedRows[0].Cells[2].Value.ToString();
                txt_licenseNumber.Text = dgv_Booking.SelectedRows[0].Cells[3].Value.ToString();
                date_startingDate.Text = dgv_Booking.SelectedRows[0].Cells[4].Value.ToString();
                txt_startingOdometer.Text = dgv_Booking.SelectedRows[0].Cells[5].Value.ToString();
                date_endDate.Text = dgv_Booking.SelectedRows[0].Cells[6].Value.ToString();
                combo_packageType.Text = dgv_Booking.SelectedRows[0].Cells[7].Value.ToString();
                txt_depositAmount.Text = dgv_Booking.SelectedRows[0].Cells[8].Value.ToString();
                txt_advancedPayment.Text = dgv_Booking.SelectedRows[0].Cells[9].Value.ToString();
                txt_description.Text = dgv_Booking.SelectedRows[0].Cells[10].Value.ToString();

                isEndDatevalid();
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

        private void pb_btnReset_Click(object sender, EventArgs e)                          ////reset button actions
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

            getNextBookingID();
           
        }

        private void pb_btnUpdatePrint_Click(object sender, EventArgs e)                        // update button actions
        {
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
                    txt_depositAmount.Text != "" &&
                    IsValidPackagetype == true

               )
            {
                try
                {
                    
                    try
                    {
                        MySqlDataReader reader1 = DbConnection.Read("UPDATE `booking` SET `Vehicle_num`='" + txt_vehicleRegNumber.Text.Trim() + "',`Cus_NIC` = '" + txt_customerNic.Text.Trim() + "',`Licen_num`='" + txt_licenseNumber.Text.Trim() + "',`Start_date`='" + date_startingDate.Text + "',`Start_ODO`='" + txt_startingOdometer.Text.Trim() + "',`Package_Type`='" + combo_packageType.Text + "',`Discription`='" + txt_description.Text.Trim() + "' WHERE `booking`.`Booking_ID` = '" + txt_bookingId.Text.Trim() + "';");
                        try
                        {
                            MySqlDataReader reader2 = DbConnection.Read("UPDATE `payment` SET `Cust_NIC`='" + txt_customerNic.Text.Trim() + "',`Vehicle_num`='" + txt_vehicleRegNumber.Text.Trim() + "',`End_date`='" + date_endDate.Text + "',`Deposite_Amount`='" + txt_depositAmount.Text.Trim() + "',`Advance_Payment`='" + txt_advancedPayment.Text.Trim() + "' WHERE `payment`.`Booking_ID` = '" + txt_bookingId.Text.Trim() + "'     ");
                            try
                            {
                                CustomMessage submitmessege = new CustomMessage("Update Successfull!", "Updates", ShineWay.Properties.Resources.tick, DialogResult.OK);
                                submitmessege.convertToOkButton();
                                submitmessege.ShowDialog();
                            }
                            catch (Exception ex0)
                            {
                                MessageBox.Show(ex0.Message);
                            }
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message);
                        }
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                    
                    setDataToGrid("SELECT `booking`.`Booking_ID`,`booking`.`Vehicle_num`,`booking`.`Cus_NIC`,`booking`.`Licen_num`,`Start_date`, `Start_ODO`,`End_date`,`Package_Type`,`Deposite_Amount`,`Advance_Payment`,`Discription` FROM `booking`, `payment` WHERE `booking`.`Booking_ID`=`payment`.`Booking_ID`");
                }
                catch (Exception ex3)
                {
                    MessageBox.Show(ex3.Message);
                }
            }
            else
            {
                CustomMessage errormessege1 = new CustomMessage("Unsuccessfull Update!\n\n Enter correct details", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege1.convertToOkButton();
                errormessege1.ShowDialog();
            }
        }

        private void pb_btnSubmitPrint_Click(object sender, EventArgs e)                           // sumbit button actions
        {           
            if (combo_packageType.Text == "")                   // check package type selected
            {
                lbl_packageTypeError.Visible = true;
                lbl_packageTypeCorrect.Visible = false;
            }
            
                                                                // actions
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
                    date_startingDate.Value >= DateTime.Now  &&
                    date_endDate.Value >= date_startingDate.Value &&
                    IsValidPackagetype == true


                )
            {
                try
                {
                    
                    try
                    {
                        MySqlDataReader reader3 = DbConnection.Read("INSERT INTO `booking` (`Vehicle_num`, `Booking_ID`, `Licen_num`, `Start_date`, `Start_ODO`, `Package_Type`, `Cus_NIC`, `Discription`) VALUES ('" + txt_vehicleRegNumber.Text.Trim() + "', '" + txt_bookingId.Text.Trim() + "', '" + txt_licenseNumber.Text + "', '" + date_startingDate.Text + "', '" + txt_startingOdometer.Text + "', '" + combo_packageType.Text + "', '" + txt_customerNic.Text + "', '" + txt_description.Text + "');");
                        try
                        {
                            MySqlDataReader reader4 = DbConnection.Read("INSERT INTO `payment` ( `Booking_ID`, `Cust_NIC`,`Vehicle_num`,`Status`, `End_date`,`Deposite_Amount`,`Advance_Payment`) VALUES ('" + txt_bookingId.Text.Trim() + "', '" + txt_customerNic.Text.Trim() + "', '" + txt_vehicleRegNumber.Text.Trim() + "', 'Ongoing', '" + date_endDate.Text + "','" + txt_depositAmount.Text.Trim() + "','" + txt_advancedPayment.Text.Trim() + "');");
                            try
                            {
                                CustomMessage submitmessege = new CustomMessage("Booking Successfull!", "Inserted", ShineWay.Properties.Resources.correct, DialogResult.OK);
                                submitmessege.convertToOkButton();
                                submitmessege.ShowDialog();
                            }
                            catch (Exception ex0)
                            {
                                MessageBox.Show(ex0.Message); 
                            }
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message);
                        }
                    }
                    catch(Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }


                    setDataToGrid("SELECT `booking`.`Booking_ID`,`booking`.`Vehicle_num`,`booking`.`Cus_NIC`,`booking`.`Licen_num`,`Start_date`, `Start_ODO`,`End_date`,`Package_Type`,`Deposite_Amount`,`Advance_Payment`,`Discription` FROM `booking`, `payment` WHERE `booking`.`Booking_ID`=`payment`.`Booking_ID`");
                }
                catch (Exception ex3)
                {
                    MessageBox.Show(ex3.Message);
                }
            }
            else
            {
                CustomMessage errormessege1 = new CustomMessage("Booking Unsuccessfull!\n\n Enter correct details", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege1.convertToOkButton();
                errormessege1.ShowDialog();
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ++++++++++++++++ search ++++++++++++++++

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text != "") {
                try
                {
                    setDataToGrid("SELECT `booking`.`Vehicle_num`, `booking`.`Booking_ID`,`booking`.`Licen_num`,`booking`.`Cus_NIC`, `Start_date`, `Start_ODO`,`End_date`,`Package_Type`,`Deposite_Amount`,`Advance_Payment`,`Discription`  FROM `booking`,`payment` WHERE `booking`.`Vehicle_num` LIKE '%" + txt_search.Text + "%' OR `booking`.`Booking_ID` LIKE '%" + txt_search.Text + "%' OR `booking`.`Cus_nic` LIKE '%" + txt_search.Text + "%' OR `booking`.`Licen_num` LIKE '%" + txt_search.Text + "%' OR `Start_date` LIKE '%" + txt_search.Text + "%' OR `Start_ODO` LIKE '%" + txt_search.Text + "%'");
                }
                catch (Exception exsearch)
                {
                    MessageBox.Show(exsearch.Message);
                }
            }
            else
            {
                try
                {
                    setDataToGrid("SELECT `booking`.`Booking_ID`,`booking`.`Vehicle_num`,`booking`.`Cus_NIC`,`booking`.`Licen_num`,`Start_date`, `Start_ODO`,`End_date`,`Package_Type`,`Deposite_Amount`,`Advance_Payment`,`Discription` FROM `booking`, `payment` WHERE `booking`.`Booking_ID`=`payment`.`Booking_ID`");
                }
                catch (Exception exsearchnull)
                {
                    MessageBox.Show(exsearchnull.Message);
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // ++++++++++++++++ validations ++++++++++++++++

        public void isEndDatevalid()                                                             // avoid entering later starting date than ending date
        {
            if (date_startingDate.Value > date_endDate.Value)
            {
                try
                {
                    date_endDate.Value = date_startingDate.Value; 
                }
                catch (Exception invalidenddate)
                {
                    MessageBox.Show("End date should be a later date than start date");
                }
            }
        }

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
                // lbl_packageTypeCorrect.Visible = true;
                selectPackageType();
            }
            
        }

        private void date_endDate_Leave(object sender, EventArgs e)
        {
            selectPackageType();
        }      

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Booking_Load(object sender, EventArgs e)
        {
            
            dgv_Booking.BorderStyle = BorderStyle.None;
            //this.dataGridView1.GridColor = Color.BlueViolet;
            dgv_Booking.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_Booking.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
             dgv_Booking.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
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

        private void date_startingDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            isEndDatevalid(); ;
        }

        private void date_startingDate_MouseLeave(object sender, EventArgs e)
        {
            isEndDatevalid();
        }

        private void date_startingDate_Leave(object sender, EventArgs e)
        {
            isEndDatevalid();
        }

        private void date_startingDate_MouseMove(object sender, MouseEventArgs e)
        {
            isEndDatevalid();
        }

        private void dgv_Booking_MouseEnter(object sender, EventArgs e)
        {
            isEndDatevalid();
        }

        private void txt_bookingId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}

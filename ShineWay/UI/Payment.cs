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
using ShineWay.Classes;

namespace ShineWay.UI
{
    public partial class Payment : UserControl
    {

        List<payment> payments = new List<payment>();
        public Payment()
        {
            InitializeComponent();

            setDataToGrid("SELECT payment.Booking_ID, payment.Cust_NIC, payment.Status, payment.End_date,payment.Advance_Payment, payment.End_ODO,payment.Amount, payment.Discount, payment.Sub_Amount,booking.Start_ODO,booking.Vehicle_num,booking.Package_Type,booking.Start_date,vehicle.Daily_price,vehicle.Weekly_price, vehicle.Monthly_price, vehicle.Extrakm_price, vehicle.Daily_KM, vehicle.Weekly_KM, vehicle.Monthly_KM FROM payment, booking, vehicle WHERE payment.Booking_ID = booking.Booking_ID AND booking.Vehicle_num = vehicle.Vehicle_num");
            
        }

        public void setDataToGrid(string query)                                     // get data to datagridview
        {
            
            dgv_Payment.Rows.Clear();
            dgv_Payment.Refresh();
            
            try
            {
                MySqlDataReader reader1 = DbConnection.Read(query);

                if (reader1 != null)
                {
                    while (reader1.Read())
                    {
                        int x = dgv_Payment.Rows.Add();

                        dgv_Payment.Rows[x].Cells[0].Value = reader1.GetString("Booking_ID");
                        dgv_Payment.Rows[x].Cells[1].Value = reader1.GetString("Vehicle_num");
                        dgv_Payment.Rows[x].Cells[2].Value = reader1.GetString("Cust_NIC");
                        dgv_Payment.Rows[x].Cells[3].Value = reader1.GetString("Status");
                        dgv_Payment.Rows[x].Cells[4].Value = reader1.GetString("End_date");
                        dgv_Payment.Rows[x].Cells[5].Value = reader1.GetString("Advance_Payment");
                        if (reader1[5] == null)
                        {
                            dgv_Payment.Rows[x].Cells[6].Value = "No";
                        }
                        else
                        {
                            dgv_Payment.Rows[x].Cells[6].Value = reader1.GetString("End_ODO");
                        }

                        if (reader1[6] == null)
                        {
                            dgv_Payment.Rows[x].Cells[7].Value = "No";
                        }
                        else
                        {
                            dgv_Payment.Rows[x].Cells[7].Value = reader1.GetString("Amount");
                        }
                        if (reader1[7] == null)
                        {
                            dgv_Payment.Rows[x].Cells[8].Value = "No";
                        }
                        else
                        {
                            dgv_Payment.Rows[x].Cells[8].Value = reader1.GetString("Discount");
                        }
                        if (reader1[8] == null)
                        {
                            dgv_Payment.Rows[x].Cells[9].Value = "No";
                        }
                        else
                        {
                            dgv_Payment.Rows[x].Cells[9].Value = reader1.GetString("Sub_Amount");
                        }

                        dgv_Payment.Rows[x].Cells[10].Value = reader1.GetString("Start_ODO");
                        dgv_Payment.Rows[x].Cells[11].Value = reader1.GetString("Package_Type");
                        dgv_Payment.Rows[x].Cells[12].Value = reader1.GetString("Daily_price");
                        dgv_Payment.Rows[x].Cells[13].Value = reader1.GetString("Weekly_price");
                        dgv_Payment.Rows[x].Cells[14].Value = reader1.GetString("Monthly_price");
                        dgv_Payment.Rows[x].Cells[15].Value = reader1.GetString("Extrakm_price");
                        dgv_Payment.Rows[x].Cells[16].Value = reader1.GetString("Daily_KM");
                        dgv_Payment.Rows[x].Cells[17].Value = reader1.GetString("Weekly_KM");
                        dgv_Payment.Rows[x].Cells[18].Value = reader1.GetString("Monthly_KM");
                        dgv_Payment.Rows[x].Cells[19].Value = reader1.GetString("Start_date");

                    }
                }
   
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
            txt_bookingId.Text = "";
            txt_vehicleRegNumber.Text = "";
            txt_customerNic.Text = "";
            lbl_startingODO.Text = "";
            combo_status.Text = null;
            date_endDate.Value = DateTime.Now;
            txt_endingOdometer.Text = "";
            textBox1.Text = "";
            lbl_amount.Text = "";
            txt_subAmount.Text = "";
            txt_search.Text = "";
        }

        private void pb_btnSubmitPrint_Click(object sender, EventArgs e)
        {
            //submit & reset button code goes here
            /*if (combo_status.Text == "")                   // check package type selected
            {
                lbl_statusError.Visible = true;
                lbl_statusCorrect.Visible = false;
            }

            // actions
            if (    lbl_endODOError.Visible == false &&
                    lbl_discountError.Visible == false &&
                    txt_vehicleRegNumber.Text != "" &&
                    txt_customerNic.Text != "" &&
                    txt_endingOdometer.Text != "" &&
                    combo_status.Text != "" &&
                    textBox1.Text != "" &&
                    date_endDate.Value >= DateTime.Now == true

                )
            {
                try
                {

                    try
                    {
                        
                        //MySqlDataReader reader = DbConnection.Read("INSERT INTO `payment`(`Booking_ID`, `Cust_NIC`, `Vehicle_num`, `Status`, `End_date`, `End_ODO`, `Amount`, `Discount`, `Sub_Amount`) VALUES ('" + txt_bookingId.Text + "','" + txt_vehicleRegNumber.Text + "','" + txt_customerNic.Text + "','" + combo_status.Text + "','" + date_endDate.Text + "','" + txt_endingOdometer.Text + "','" + lbl_amount.Text + "','" + textBox1.Text + "','" + txt_subAmount.Text + "')");
                        MySqlDataReader reader = DbConnection.Read("INSERT INTO `payment`(`Booking_ID`, `Cust_NIC`, `Vehicle_num`, `Status`, `End_date`, `End_ODO`, `Amount`, `Discount`, `Sub_Amount`) VALUES ('" + txt_bookingId.Text + "','" + txt_customerNic.Text + "','" + txt_vehicleRegNumber.Text + "','" + combo_status.Text + "','" + date_endDate.Text + "','" + txt_endingOdometer.Text + "','" + lbl_amount.Text + "','" + textBox1.Text + "','" + txt_subAmount.Text + "')");

                        try
                        {
                            CustomMessage submitmessege = new CustomMessage("Payment Successfull!", "Inserted", ShineWay.Properties.Resources.correct, DialogResult.OK);
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
                    setDataToGrid("SELECT payment.Booking_ID, payment.Cust_NIC, payment.Status, payment.End_date,payment.Advance_Payment, payment.End_ODO,payment.Amount, payment.Discount, payment.Sub_Amount,booking.Start_ODO,booking.Vehicle_num,booking.Package_Type,booking.Start_date,vehicle.Daily_price,vehicle.Weekly_price, vehicle.Monthly_price, vehicle.Extrakm_price, vehicle.Daily_KM, vehicle.Weekly_KM, vehicle.Monthly_KM FROM payment, booking, vehicle WHERE payment.Booking_ID = booking.Booking_ID AND booking.Vehicle_num = vehicle.Vehicle_num");

                    //setDataToGrid("SELECT `Booking_ID`, `Cust_NIC`, `Vehicle_num`, `Status`, `End_date`, `End_ODO`, `Amount`, `Discount`, `Sub_Amount` FROM `payment` WHERE 1");
                    //setDataToGrid("SELECT `Booking_ID`, `Cust_NIC`, `Vehicle_num`, `Status`, `End_date`, `End_ODO`, `Deposite_Amount`, `Amount`, `Advance_Payment`, `Discount`, `Sub_Amount` FROM `payment` WHERE 1");
                    //setDataToGrid("SELECT `booking`.`Booking_ID`,`booking`.`Vehicle_num`,`booking`.`Cus_NIC`,`booking`.`Licen_num`,`Start_date`, `Start_ODO`,`End_date`,`Package_Type`,`Deposite_Amount`,`Advance_Payment`,`Discription` FROM `booking`, `payment` WHERE `booking`.`Booking_ID`=`payment`.`Booking_ID`");
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
            }
            else
            {
                CustomMessage errormessege1 = new CustomMessage("Payment Unsuccessfull!\n\n Enter correct values", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege1.convertToOkButton();
                errormessege1.ShowDialog();
            }*/
        }
  

        private void pb_btnUpdatePrint_Click(object sender, EventArgs e)
        {
            if (    lbl_statusError.Visible == false &&
                    lbl_endDateError.Visible == false &&
                    lbl_endODOError.Visible == false &&
                    lbl_discountError.Visible == false &&
                    txt_vehicleRegNumber.Text != "" &&
                    date_endDate.Text != "" &&
                    txt_endingOdometer.Text != "" &&
                    combo_status.Text != "" == true
                    
               //isEndDatevalid == true

               )
            {
                try
                {

                    try
                    {
                        MySqlDataReader reader1 = DbConnection.Read("UPDATE `payment` SET `Status`='" + combo_status.Text.Trim() + "',`End_date`='" + date_endDate.Text + "' ,`End_ODO`= '" + txt_endingOdometer.Text.Trim() + "' ,`Amount`='" + lbl_amount.Text.Trim() + "',`Discount`='" + textBox1.Text.Trim() + "' ,`Sub_Amount`= '" + txt_subAmount.Text.Trim() + "' WHERE `Booking_ID` = '"+ txt_bookingId.Text.Trim() +"';");

                        try
                        {
                            CustomMessage submitmessege = new CustomMessage("Succussfully Updated!", "Updates", ShineWay.Properties.Resources.tick, DialogResult.OK);
                            submitmessege.convertToOkButton();
                            submitmessege.ShowDialog();
                        }
                        catch (Exception ex0)
                        {
                            MessageBox.Show(ex0.Message);
                        }

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }

                    setDataToGrid("SELECT payment.Booking_ID, payment.Cust_NIC, payment.Status, payment.End_date,payment.Advance_Payment, payment.End_ODO,payment.Amount, payment.Discount, payment.Sub_Amount,booking.Start_ODO,booking.Vehicle_num,booking.Package_Type,booking.Start_date,vehicle.Daily_price,vehicle.Weekly_price, vehicle.Monthly_price, vehicle.Extrakm_price, vehicle.Daily_KM, vehicle.Weekly_KM, vehicle.Monthly_KM FROM payment, booking, vehicle WHERE payment.Booking_ID = booking.Booking_ID AND booking.Vehicle_num = vehicle.Vehicle_num");

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
                textBox1.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                textBox1.Focus();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                textBox1.Focus();
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
            
        }

        private void txt_vehicleRegNumber_Leave_1(object sender, EventArgs e)
        {
            
        }

        private void txt_customerNic_Leave_1(object sender, EventArgs e)
        {
            
        }

        private void combo_status_Leave(object sender, EventArgs e)
        {
            bool status = Validates.ValidateStatus(combo_status.Text);
            if (status == false)
            {
                lbl_statusError.Visible = false;
            }
            else
            {
                lbl_statusCorrect.Visible = true;
            }
        }

        private void txt_endingOdometer_Leave_1(object sender, EventArgs e)
        {
            bool endodo = Validates.ValidOdometer(txt_endingOdometer.Text);
            if (endodo == false)
            {
                lbl_endODOError.Visible = true;
                lbl_endODOCorrect.Visible = false;
            }
            else
            {
                lbl_endODOCorrect.Visible = true;
                lbl_endODOError.Visible = false;
            }
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            bool discount = Validates.ValidDiscount(textBox1.Text);
            if (discount == false)
            {
                lbl_discountError.Visible = true;
                lbl_discountCorrect.Visible = false;
            }
            else
            {
                lbl_discountCorrect.Visible = true;
                lbl_discountError.Visible = false;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            string pt = dgv_Payment.CurrentRow.Cells[11].Value.ToString();
            decimal amt;
            //pt = PakageType , amt = Amount , start = Starting ODO , end = Ending ODO , dp = Daily Price for 1 KM , wp = Wekkly Price for 1 KM , mp = Monthlyy Price for 1 KM ek = Extra KM Price , dk = Daily KMs , mk = Monthly KMs , wk = Weekly KMs , adv = Advance Payment , days = No.of Days
            try
            {
                if (e.KeyCode == Keys.Enter)
                    {

                    if (pt == "Daily Basis")
                    {
  
                        int start = Convert.ToInt32(dgv_Payment.CurrentRow.Cells[10].Value);
                        int end = Convert.ToInt32(txt_endingOdometer.Text);
                        decimal dp = Convert.ToDecimal(dgv_Payment.CurrentRow.Cells[12].Value);
                        decimal ek = Convert.ToDecimal(dgv_Payment.CurrentRow.Cells[15].Value);
                        int dk = Convert.ToInt32(dgv_Payment.CurrentRow.Cells[16].Value);
                        decimal adv = Convert.ToDecimal(dgv_Payment.CurrentRow.Cells[5].Value);
                        int days = Convert.ToInt32(dgv_Payment.CurrentRow.Cells[20].Value);

                        if ((end - start) <= (dk*days))
                             {
                               amt = (dp*days) - adv;
                               lbl_amount.Text = amt.ToString();
                             }
                        else
                             {
                               amt = ((dp*days) + (((end - start) - dk) * ek)) - adv;
                               lbl_amount.Text = amt.ToString();
                              }  
                    }

                     else if (pt == "Weekly Basis")
                     {
                           int start = Convert.ToInt32(dgv_Payment.CurrentRow.Cells[10].Value);
                           int end = Convert.ToInt32(txt_endingOdometer.Text);
                           decimal wp = Convert.ToDecimal(dgv_Payment.CurrentRow.Cells[13].Value);
                           decimal ek = Convert.ToDecimal(dgv_Payment.CurrentRow.Cells[15].Value);
                           int wk = Convert.ToInt32(dgv_Payment.CurrentRow.Cells[17].Value);
                           decimal adv = Convert.ToDecimal(dgv_Payment.CurrentRow.Cells[5].Value);
                            int days = Convert.ToInt32(dgv_Payment.CurrentRow.Cells[20].Value);

                        if ((end - start) <= (wk * days))
                        {
                            amt = (wp * days) - adv;
                            lbl_amount.Text = amt.ToString();
                        }
                        else
                        {
                            amt = ((wp * days) + (((end - start) - wk )* ek)) - adv;
                            lbl_amount.Text = amt.ToString();
                        }
                     }
                     else if (pt == "Monthly Basis")
                     {
                            int start = Convert.ToInt32(dgv_Payment.CurrentRow.Cells[10].Value);
                            int end = Convert.ToInt32(txt_endingOdometer.Text);
                            decimal mp = Convert.ToDecimal(dgv_Payment.CurrentRow.Cells[14].Value);
                            decimal ek = Convert.ToDecimal(dgv_Payment.CurrentRow.Cells[15].Value);
                            int mk = Convert.ToInt32(dgv_Payment.CurrentRow.Cells[18].Value);
                            decimal adv = Convert.ToDecimal(dgv_Payment.CurrentRow.Cells[5].Value);
                            int days = Convert.ToInt32(dgv_Payment.CurrentRow.Cells[20].Value);

                        if ((end - start) <= (mk * days))
                        {
                            amt = (mp * days) - adv;
                            lbl_amount.Text = amt.ToString();
                        }
                        else
                        {
                            amt = ((mp * days) + (((end - start) - mk )* ek)) - adv;
                            lbl_amount.Text = amt.ToString();
                        }
                    }
                }
          
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //amt = Amount , dis = Discount Price , sub = Sub Amount
                if (e.KeyCode == Keys.Enter)
                {
                    decimal amt = Convert.ToDecimal(lbl_amount.Text);
                    decimal dis = Convert.ToDecimal(textBox1.Text);
                    decimal sub;
                    sub = amt - dis;
                    txt_subAmount.Text = sub.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            DateTime d1;
            DateTime d2;

            d1 = Convert.ToDateTime(date_endDate.Text);
            d2 = Convert.ToDateTime(dgv_Payment.CurrentRow.Cells[19].Value);
            if (d1 > d2)
            {
                TimeSpan ts = d1 - d2;
                int days = ts.Days;
                dgv_Payment.CurrentRow.Cells[20].Value = ts.Days;
            }
            else
            {
                CustomMessage errormessege1 = new CustomMessage("Enter Valid Date!\n\n Enter correct values", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                errormessege1.convertToOkButton();
                errormessege1.ShowDialog();
            }


        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            string query = $"SELECT `payment`.`Booking_ID`, `payment`.`Cust_NIC`, `payment`.`Status`,`payment`.`Advance_Payment`, `payment`.`End_date`, `payment`.`End_ODO`, `payment`.`Amount`, `payment`.`Discount`, `payment`.`Sub_Amount` , `booking`.`Start_ODO` , `booking`.`Package_Type`,`booking`.`Vehicle_num`,`booking`.`Start_date`, `vehicle`.`Daily_price`, `vehicle`.`Weekly_price`, `vehicle`.`Monthly_price`, `vehicle`.`Extrakm_price`, `vehicle`.`Daily_KM`, `vehicle`.`Weekly_KM`, `vehicle`.`Monthly_KM` FROM `payment`,`booking`,`vehicle` WHERE `payment`.`Booking_ID`=`booking`.`Booking_ID` AND `booking`.`Vehicle_num`=`vehicle`.`Vehicle_num` AND (`payment`.`Booking_ID` LIKE \"%{txt_search.Text}%\" OR `payment`.`Vehicle_num` LIKE \"%{txt_search.Text}%\" OR `payment`.`Cust_NIC` LIKE \"%{txt_search.Text}%\"  OR `payment`.`Status` LIKE \"%{txt_search.Text}%\")";

            setDataToGrid(query);

        }

        private void dgv_Payment_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_bookingId.Text = dgv_Payment.SelectedRows[0].Cells[0].Value.ToString();
                txt_vehicleRegNumber.Text = dgv_Payment.SelectedRows[0].Cells[1].Value.ToString();
                txt_customerNic.Text = dgv_Payment.SelectedRows[0].Cells[2].Value.ToString();
                combo_status.Text = dgv_Payment.SelectedRows[0].Cells[3].Value.ToString();
                date_endDate.Text = dgv_Payment.SelectedRows[0].Cells[4].Value.ToString();
                if(dgv_Payment.SelectedRows[0].Cells[5].Value == null)
                {

                }
                else
                {
                    lbl_startingODO.Text = dgv_Payment.SelectedRows[0].Cells[10].Value.ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Payment_Load_1(object sender, EventArgs e)
        {
            dgv_Payment.BorderStyle = BorderStyle.None;
            //this.dataGridView1.GridColor = Color.BlueViolet;
            dgv_Payment.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv_Payment.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_Payment.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dgv_Payment.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv_Payment.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgv_Payment.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;//optional
            dgv_Payment.EnableHeadersVisualStyles = false;
            dgv_Payment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv_Payment.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic bold", 12);
            dgv_Payment.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dgv_Payment.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_Payment.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            dgv_Payment.RowHeadersVisible = false;
            dgv_Payment.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv_Payment.ColumnHeadersDefaultCellStyle.BackColor;
 

        }

    }
    
}

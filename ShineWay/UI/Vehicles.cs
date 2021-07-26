﻿using MySql.Data.MySqlClient;
using ShineWay.Classes;
using ShineWay.DataBase;
using ShineWay.Messages;
using ShineWay.Validation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ShineWay.UI
{
    public partial class Vehicles : UserControl

    {
        bool isVehRegNoValid = false;
        bool isNICValid = false;
        bool isBrandValid = false;
        bool isModelValid = false;
        bool isVehicleTypeValid = false;
        bool isOwnerConditionValid = false;
        bool isEngineNoValid = false;
        bool isChassisNoValid = false;
        bool isValidDailyPrice = false;
        bool isValidWeeklyPrice = false;
        bool isValidMonthlyPrice = false;
        bool isValidExtrakmPrice = false;
        bool isValidDailykm = false;
        bool isValidWeeklykm = false;
        bool isValidMonthlykm = false;
        bool isValidOwnerPayment = false;
        bool isValidStartingOdo = false;
        



        bool isVehRegNoValidForUpdate = true;
        bool isNICValidForUpdate = true;
        bool isBrandValidForUpdate = true;
        bool isModelValidForUpdate = true;
        bool isVehTypeValidForUpdate = true;


        List<Vehicle> vehicles = new List<Vehicle>();


        public Vehicles()
        {
            InitializeComponent();
            combo_type.SelectedIndex = 0;
            setDataToGrid("SELECT `Vehicle_num`, `Brand`, `Model`, `Type`, `Owner_NIC`, `Engine_Num`, `Chassis_Num`, `Reg_Date`, `Owner_Condi`, `Daily_price`, `Daliy_KM`, `Weekly_price`, `Weekly_KM`, `Monthly_price`, `Monthy_KM`, `Extrakm_price`, `Owner_payment`, `Starting_odo`, `OverallView`, `InsideView` FROM `vehicle`");
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


        //Insert Button
        private async void pb_btnAdd_Click(object sender, EventArgs e)
        {
                 
                // add button code goes here
                Cursor = Cursors.WaitCursor;

                MemoryStream ms = new MemoryStream();
                pb_overallViewimg.Image.Save(ms, pb_overallViewimg.Image.RawFormat);
                pb_InsideViewimg.Image.Save(ms, pb_InsideViewimg.Image.RawFormat);
                Byte[] img = ms.ToArray();

                MySqlDataReader reader;

                if (msktxt_vehicleRegNumber.Text == "" || txt_brand.Text.Trim() == "" || txt_model.Text.Trim() == "" || combo_type.Text.Trim() == "" || txt_engineNumber.Text.Trim() == "" || txt_chasisNumber.Text.Trim() == "" || txt_ownerNIC.Text.Trim() == "" || date_registeredDate.Text.Trim() == "" || txt_ownerCondition.Text.Trim() == "" || txt_DailyPrice.Text.Trim() == "" || txt_WeeklyPrice.Text.Trim() == ""|| txt_MonthlyPrice.Text.Trim() == "" || txt_ExtrakmPrice.Text.Trim() == "" || txt_Dailykm.Text.Trim() == "" || txt_Weeklykm.Text.Trim() == "" || txt_Monthlykm.Text.Trim() == "" || txt_OwnerPayment.Text.Trim() == "" || msktxt_startingOdo.Text == "" || pb_overallViewimg.Image == null || pb_InsideViewimg.Image == null)
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
                            reader = DbConnection.Read("SELECT COUNT(`Vehicle_num`) FROM `vehicle`");
                            while (reader.Read())
                            {

                            }


                            try
                            {

                                String addQuery = $"INSERT INTO `vehicle`(`Vehicle_num`, `Brand`, `Model`, `Type`, `Engine_Num`, `Chassis_Num`, `Owner_NIC`, `Reg_Date`, `Owner_Condi`, `Daily_price`, `Daliy_KM`, `Weekly_price`, `Weekly_KM`, `Monthly_price`, `Monthy_KM`, `Extrakm_price`, `Owner_payment`, `Starting_odo`, `OverallView`, `InsideView`) VALUES (  \"{msktxt_vehicleRegNumber}\",  \"{txt_brand}\",  \"{txt_model.Text}\",   \"{combo_type.Text}\",   \"{txt_engineNumber.Text}\",   \"{txt_chasisNumber.Text}\",  \"{date_registeredDate.Text}\",  \"{txt_ownerCondition.Text}\",  \"{txt_DailyPrice.Text}\",   \"{txt_Dailykm.Text}\",   \"{txt_WeeklyPrice.Text}\",   \"{txt_Weeklykm.Text}\",  \"{txt_MonthlyPrice.Text}\",  \"{txt_Monthlykm.Text}\",  \"{txt_ExtrakmPrice.Text}\",   \"{txt_OwnerPayment.Text}\",   \"{msktxt_startingOdo.Text}\",   \"{pb_overallViewimg.Image}\",  \"{pb_InsideViewimg.Image}\")";


                                DbConnection.Write(addQuery);
                                CustomMessage message = new CustomMessage("User Added Successfully!", "Added", ShineWay.Properties.Resources.correct, DialogResult.OK);
                                message.convertToOkButton();
                                message.ShowDialog();
                                pb_btnReset_Click(sender, e);

                            }
                            catch (Exception exe)
                            {
                                new CustomMessage("Connot insert!", "Error", ShineWay.Properties.Resources.error, DialogResult.OK).ShowDialog();
                            }
                        }
                      catch (Exception exe)
                        {
                            new CustomMessage("Unable to connect!", "Error", ShineWay.Properties.Resources.error, DialogResult.OK).ShowDialog();
                        }


                    }
                    else
                    {
                        CustomMessage submitmessege = new CustomMessage("All fields must be corrected\n before submit!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                        submitmessege.convertToOkButton();
                        submitmessege.ShowDialog();
                    }

                }

                setDataToGrid("SELECT `Vehicle_num`, `Brand`, `Model`, `Type`, `Owner_NIC`, `Engine_Num`, `Chassis_Num`, `Reg_Date`, `Owner_Condi`, `Daily_price`, `Daliy_KM`, `Weekly_price`, `Weekly_KM`, `Monthly_price`, `Monthy_KM`, `Extrakm_price`, `Owner_payment`, `Starting_odo`, `OverallView`, `InsideView` FROM `vehicle`");
                Cursor = Cursors.Arrow;

            
            }

        void setDataToGrid(string query)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            try { 
            MySqlDataReader reader = DbConnection.Read(query);

                while (reader.Read())
                {
                    int x = dataGridView1.Rows.Add();
                    dataGridView1.Rows[x].Cells[0].Value = reader.GetString("Vehicle_num");
                    dataGridView1.Rows[x].Cells[1].Value = reader.GetString("Brand");
                    dataGridView1.Rows[x].Cells[2].Value = reader.GetString("Model");
                    dataGridView1.Rows[x].Cells[3].Value = reader.GetString("Type");
                    dataGridView1.Rows[x].Cells[4].Value = reader.GetString("Owner_NIC");
                    dataGridView1.Rows[x].Cells[5].Value = reader.GetString("Engine_Num");
                    dataGridView1.Rows[x].Cells[6].Value = reader.GetString("Chassis_Num");
                    dataGridView1.Rows[x].Cells[7].Value = reader.GetString("Reg_Date");
                    dataGridView1.Rows[x].Cells[8].Value = reader.GetString("Owner_Condi");
                    dataGridView1.Rows[x].Cells[9].Value = reader.GetString("Daily_price");
                    dataGridView1.Rows[x].Cells[10].Value = reader.GetString("Daliy_KM");
                    dataGridView1.Rows[x].Cells[11].Value = reader.GetString("Weekly_price");
                    dataGridView1.Rows[x].Cells[12].Value = reader.GetString("Weekly_KM");
                    dataGridView1.Rows[x].Cells[13].Value = reader.GetString("Monthly_price");
                    dataGridView1.Rows[x].Cells[14].Value = reader.GetString("Monthy_KM");
                    dataGridView1.Rows[x].Cells[15].Value = reader.GetString("Extrakm_price");
                    dataGridView1.Rows[x].Cells[16].Value = reader.GetString("Owner_payment");
                    dataGridView1.Rows[x].Cells[17].Value = reader.GetString("Starting_odo");
                    dataGridView1.Rows[x].Cells[18].Value = reader.GetString("OverallView");
                    dataGridView1.Rows[x].Cells[19].Value = reader.GetString("InsideView");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       }

        private void txt_DailyPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pb_BtnBrowseOverallView_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pb_overallViewimg.Image = Image.FromFile(opf.FileName);
            }
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pb_InsideViewimg.Image = Image.FromFile(opf.FileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pb_BtnBrowseOverallView_MouseHover(object sender, EventArgs e)
        {
           // pb_BtnBrowseOverallView.Image = ShineWay.Properties.Resources.Leftbrowse;
        }


        private bool isAllValid()
        {
            return (isVehRegNoValid && isNICValid && isBrandValid && isModelValid  && isEngineNoValid && isChassisNoValid && isOwnerConditionValid && isValidDailyPrice && isValidWeeklyPrice && isValidMonthlyPrice && isValidExtrakmPrice && isValidDailykm && isValidWeeklykm && isValidMonthlykm && isValidOwnerPayment && isValidStartingOdo);
        }

      
        private bool isAllValidForUpdate()
        {
            return (isVehRegNoValidForUpdate && isNICValidForUpdate && isBrandValidForUpdate && isModelValidForUpdate && isVehTypeValidForUpdate);
        }

        private void txt_OwnerPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            e.Handled = true;
        }

        private void txt_DailyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

             if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                 e.Handled = true;
          
        }

        private void txt_WeeklyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
         if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void txt_MonthlyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void txt_ExtrakmPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
               e.Handled = true;
        }

        private void txt_Dailykm_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
               label_validKmError.Visible = true;
            }
            else
            {
                label_validKmError.Visible = false;
                label_tickKm.Visible = true;
            }
               
        }

        private void txt_Weeklykm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                label_validKmError.Visible = true;
            }
            else
            {
                label_validKmError.Visible = false;
                label_tickKm.Visible = true;
            }
                
        }

        private void txt_Monthlykm_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                label_validKmError.Visible = true;
            }
            else
            {
                label_validKmError.Visible = false;
                label_tickKm.Visible = true;
            }
              
        }

        private void msktxt_startingOdo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                label_StartingOdoError.Visible = true;
            }
            else
            {
                label_StartingOdoError.Visible = false;
                label_tickStartOdo.Visible = true;
            }


        }

        private void pb_BtnBrowseOverallView_MouseHover_1(object sender, EventArgs e)
        {
           // pb_btnReset.Image = ShineWay.Properties.Resources.
        }




        //Restet Button
        private void pb_btnReset_Click(object sender, EventArgs e)
        {
            msktxt_vehicleRegNumber.Text = txt_brand.Text = txt_model.Text = txt_engineNumber.Text = txt_chasisNumber.Text = txt_ownerNIC.Text = txt_ownerCondition.Text= txt_DailyPrice.Text = txt_WeeklyPrice.Text = txt_MonthlyPrice.Text = txt_ExtrakmPrice.Text = txt_Dailykm.Text = txt_Weeklykm.Text = txt_Monthlykm.Text = txt_OwnerPayment.Text = msktxt_startingOdo.Text  = string.Empty;
            pb_overallViewimg.Image = pb_InsideViewimg.Image = null;
            label_VehicleRegNoError.Visible = false;
            label_tickVehicleRegNo.Visible = false;
            label_brandError.Visible = false;
            label_tickBrand.Visible = false;
            label_modelError.Visible = false;
            label_tickModel.Visible = false;
         //   label_VehicleTypeError.Visible = false;
            label_tickVehType.Visible = false;
            label_engineNoError.Visible = false;
            label_tickEngineNO.Visible = false;
            label_chassisNoError.Visible = false;
            label_tickChassisNo.Visible = false;
            label_nicError.Visible = false;
            label_tickNIC.Visible = false;
            label_ownerConditionError.Visible = false;
            label_tickOwnerCondition.Visible = false;
            label_ownerPaymentError.Visible = false;
            label_tickOwnerPayment.Visible = false;
            label_StartingOdoError.Visible = false;
            label_tickStartOdo.Visible = false;
            pictureBox2.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox14.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox13.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox19.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox23.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox28.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox30.Image = ShineWay.Properties.Resources.correctInput;
            label_rentPriceError.Visible = false;
            label_tickrentPrice.Visible = false;
            label_validKmError.Visible = false;
            label_tickKm.Visible = false;

        }



        //Update Button
        private void pb_btnUpdate_Click(object sender, EventArgs e)
        {
            CustomMessage addmsg = new CustomMessage("Vehicle Updated Successfully!", "Updated", ShineWay.Properties.Resources.tick, DialogResult.OK);
            addmsg.convertToOkButton();
            addmsg.ShowDialog();
        }



        //Delete Button
        private void pb_btnDelete_Click(object sender, EventArgs e)
        {
            CustomMessage addmsg = new CustomMessage("Vehicle Deleted Successfully!", "Deleted", ShineWay.Properties.Resources.tick, DialogResult.OK);
            addmsg.convertToOkButton();
            addmsg.ShowDialog();
        }

        //Validations
        private void txt_ownerNIC_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidCustomerNewNIC(txt_ownerNIC.Text) || Validates.ValidCustomerOldNIC(txt_ownerNIC.Text))
            {
                pictureBox19.Image = ShineWay.Properties.Resources.correctInput;
                label_nicError.Visible = false;
                label_tickNIC.Visible = true;
                isNICValid = true;

            }
            else
            {
                pictureBox19.Image = ShineWay.Properties.Resources.errorinput;
                label_nicError.Visible = true;
                label_tickNIC.Visible = false;
                isNICValid = false;
            }
        }

        private void txt_ownerCondition_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_ownerCondition.Text.Length > 200 || (txt_ownerCondition.Text.Length == 0))
            {
                pictureBox23.Image = ShineWay.Properties.Resources.errorinput;
                if ((txt_ownerCondition.Text.Length == 0))
                {
                    label_ownerConditionError.Text = "Owner condition cannot be empty!";
                }
                else
                {
                    label_ownerConditionError.Text = "Cannot exceeds more than 200 charactors!";
                }
                label_ownerConditionError.Visible = true;
                label_tickOwnerCondition.Visible = false;
                isOwnerConditionValid = false;
            }
            else
            {
                pictureBox23.Image = ShineWay.Properties.Resources.correctInput;
                label_ownerConditionError.Visible = false;
                label_tickOwnerCondition.Visible = true;
                isOwnerConditionValid = true;
            }
        }

        private void msktxt_vehicleRegNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidVehiclenumber1(msktxt_vehicleRegNumber.Text) || Validates.ValidVehiclenumber2(msktxt_vehicleRegNumber.Text))
            {
                pictureBox2.Image = ShineWay.Properties.Resources.correctInput;
                if ((msktxt_vehicleRegNumber.Text.Length == 0))
                {
                    label_VehicleRegNoError.Text = "Vehicle Register Number cannot be empty!";
                }
                else
                {
                    label_VehicleRegNoError.Text = "Enter the correct format!";
                }
                label_VehicleRegNoError.Visible = false;
                label_tickVehicleRegNo.Visible = true;
                isVehRegNoValid = true;

            }
            else
            {
                pictureBox2.Image = ShineWay.Properties.Resources.errorinput;
                label_VehicleRegNoError.Visible = true;
                label_tickVehicleRegNo.Visible = false;
                isVehRegNoValid = false;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_brand_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_brand.Text.Length > 40 || (txt_brand.Text.Length == 0))
            {
                pictureBox14.Image = ShineWay.Properties.Resources.errorinput;
                if ((txt_brand.Text.Length == 0))
                {
                    label_brandError.Text = "Brand cannot be empty!";
                }
                else
                {
                    label_brandError.Text = "Cannot exceeds more than 40 charactors!";
                }
                label_brandError.Visible = true;
                label_tickBrand.Visible = false;
                isBrandValid = false;
            }
            else
            {
                pictureBox14.Image = ShineWay.Properties.Resources.correctInput;
                label_brandError.Visible = false;
                label_tickBrand.Visible = true;
                isBrandValid = true;
            }
        }

        private void txt_model_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_model.Text.Length > 40 || (txt_model.Text.Length == 0))
            {
                pictureBox7.Image = ShineWay.Properties.Resources.errorinput;
                if ((txt_model.Text.Length == 0))
                {
                    label_modelError.Text = "Model cannot be empty!";
                }
                else
                {
                    label_modelError.Text = "Cannot exceeds more than 40 charactors!";
                }
                label_modelError.Visible = true;
                label_tickModel.Visible = false;
                isModelValid = false;
            }
            else
            {
                pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
                label_modelError.Visible = false;
                label_tickModel.Visible = true;
                isModelValid = true;
            }
        }

        private void txt_engineNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_engineNumber.Text.Length > 40 || (txt_engineNumber.Text.Length == 0))
            {
                pictureBox11.Image = ShineWay.Properties.Resources.errorinput;
                if ((txt_engineNumber.Text.Length == 0))
                {
                    label_engineNoError.Text = "Engine Number cannot be empty!";
                }
                else
                {
                    label_engineNoError.Text = "Cannot exceeds more than 40 charactors!";
                }
                label_engineNoError.Visible = true;
                label_tickEngineNO.Visible = false;
                isEngineNoValid = false;
            }
            else
            {
                pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
                label_engineNoError.Visible = false;
                label_tickEngineNO.Visible = true;
                isEngineNoValid = true;
            }
        }

        private void txt_chasisNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_chasisNumber.Text.Length > 40 || (txt_chasisNumber.Text.Length == 0))
            {
                pictureBox13.Image = ShineWay.Properties.Resources.errorinput;
                if ((txt_chasisNumber.Text.Length == 0))
                {
                    label_chassisNoError.Text = "Chassis Number cannot be empty!";
                }
                else
                {
                    label_chassisNoError.Text = "Cannot exceeds more than 40 charactors!";
                }
                label_chassisNoError.Visible = true;
                label_tickChassisNo.Visible = false;
                isChassisNoValid = false;
            }
            else
            {
                pictureBox13.Image = ShineWay.Properties.Resources.correctInput;
                label_chassisNoError.Visible = false;
                label_tickChassisNo.Visible = true;
                isChassisNoValid = true;
            }
        }



        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void combo_type_TextChanged(object sender, EventArgs e)
        {
            if (combo_type.Text != "")
            {
              //  label_VehicleTypeError.Visible = false;
                label_tickVehType.Visible = true;
            }
        }

        private void txt_DailyPrice_KeyUp(object sender, KeyEventArgs e)
        {
            bool isValidDailyPrice = Validates.ValidAmount(txt_DailyPrice.Text);
            if (isValidDailyPrice == false)
            {
                label_rentPriceError.Visible = true;

            }
            else
            {
                label_rentPriceError.Visible = false;
                label_tickrentPrice.Visible = true;
            }
        }

        private void txt_WeeklyPrice_KeyUp(object sender, KeyEventArgs e)
        {
            bool isValidWeeklyPrice = Validates.ValidAmount(txt_WeeklyPrice.Text);
            if (isValidWeeklyPrice == false)
            {
                label_rentPriceError.Visible = true;

            }
            else
            {
                label_rentPriceError.Visible = false;
                label_tickrentPrice.Visible = true;
            }
        }

        private void txt_MonthlyPrice_KeyUp(object sender, KeyEventArgs e)
        {
            bool isValidMonthlyPrice = Validates.ValidAmount(txt_MonthlyPrice.Text);
            if (isValidMonthlyPrice == false)
            {
                label_rentPriceError.Visible = true;

            }
            else
            {
                label_rentPriceError.Visible = false;
                label_tickrentPrice.Visible = true;
            }
        }

        private void txt_ExtrakmPrice_KeyUp(object sender, KeyEventArgs e)
        {
            
            bool isValidExtrakmPrice = Validates.ValidAmount(txt_ExtrakmPrice.Text);
            if (isValidExtrakmPrice == false)
            {
                label_rentPriceError.Visible = true;

            }
            else
            {
                label_rentPriceError.Visible = false;
                label_tickrentPrice.Visible = true;
            }
        }

        private void txt_OwnerPayment_KeyUp(object sender, KeyEventArgs e)
        {
            bool isValidOwnerPayment = Validates.ValidAmount(txt_OwnerPayment.Text);
            if (isValidOwnerPayment == false)
            {
                label_ownerPaymentError.Visible = true;
            }
            else
            {
                label_ownerPaymentError.Visible = false;
                label_tickOwnerPayment.Visible = true;
            }
        }

        private void txt_DailyPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Vehicles_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            //this.dataGridView1.GridColor = Color.BlueViolet;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(26, 139, 9);
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

      

        private void pb_btnDelete_Click_1(object sender, EventArgs e)
        {
            CustomMessage submitmessege = new CustomMessage("Are you sure to Delete ?", "Warning", ShineWay.Properties.Resources.question, DialogResult.Yes);
            DialogResult result = submitmessege.ShowDialog();

            if (result == DialogResult.Yes)
            {
                string query = $"DELETE FROM `vehicle` WHERE `Vehicle_num`= \"{dataGridView1.SelectedRows[0].Cells[0].Value}\"";
                try
                {
                    DbConnection.Delete(query);
                    CustomMessage m = new CustomMessage("successfully Deleted!", "Deleted", ShineWay.Properties.Resources.correct, DialogResult.OK);
                    m.convertToOkButton();
                    m.ShowDialog();
                    setDataToGrid("SELECT `Vehicle_num`, `Brand`, `Model`, `Type`, `Owner_NIC` FROM `vehicle`");

                }
                catch (Exception exc)
                {
                    CustomMessage messege = new CustomMessage("Unable to Delete!", "Error", ShineWay.Properties.Resources.error, DialogResult.OK);
                    messege.convertToOkButton();
                    messege.ShowDialog();
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string query = $"SELECT `Vehicle_num`, `Brand`, `Model`, `Type`, `Owner_NIC` FROM `vehicle` WHERE `Vehicle_num` LIKE \"%{textBox1.Text}%\" OR `Brand` LIKE \"%{textBox1.Text}%\" OR `Model` LIKE \"%{textBox1.Text}%\"  OR `Type` LIKE \"%{textBox1.Text}%\" OR `Owner_NIC` LIKE \"%{textBox1.Text}%\"";

            setDataToGrid(query);
        }

        private void pb_btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0] == null)
            {
                CustomMessage submitmessege = new CustomMessage("Select a row before update!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                submitmessege.convertToOkButton();
                submitmessege.ShowDialog();
            }
            else
            {
                if (msktxt_vehicleRegNumber.Text == "" || txt_brand.Text.Trim() == "" || txt_model.Text.Trim() == "" || combo_type.Text.Trim() == "" || txt_engineNumber.Text.Trim() == "" || txt_chasisNumber.Text.Trim() == "" || txt_ownerNIC.Text.Trim() == "" || date_registeredDate.Text.Trim() == "" || txt_ownerCondition.Text.Trim() == "" || txt_DailyPrice.Text.Trim() == "" || txt_WeeklyPrice.Text.Trim() == "" || txt_ExtrakmPrice.Text.Trim() == "" || txt_Dailykm.Text.Trim() == "" || txt_Weeklykm.Text.Trim() == "" || txt_Monthlykm.Text.Trim() == "" || txt_OwnerPayment.Text.Trim() == "" || msktxt_startingOdo.Text == "")
                {
                    CustomMessage submitmessege = new CustomMessage("Please fill all the fields!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                    submitmessege.convertToOkButton();
                    submitmessege.ShowDialog();
                }
                else
                {

                    if (isAllValidForUpdate())
                    {

                        string query = $"UPDATE `users` SET `Vehicle_num`= \"{msktxt_vehicleRegNumber.Text}\", `Brand`= \"{txt_brand.Text}\", `Model`= \"{txt_model.Text}\", `Type`= \"{combo_type.Text}\", `Engine_Num`= \"{txt_engineNumber.Text}\", `Chassis_Num`= \"{txt_chasisNumber.Text}\", `Owner_NIC`= \"{txt_ownerNIC.Text}\", `Reg_Date`= \"{date_registeredDate.Text}\", `Owner_Condi`= \"{txt_ownerCondition.Text}\", `Daily_price`= \"{txt_DailyPrice.Text}\", `Daliy_KM`= \"{txt_Dailykm.Text}\", `Weekly_price`= \"{txt_WeeklyPrice.Text}\", `Weekly_KM`= \"{txt_Weeklykm.Text}\", `Monthly_price`= \"{txt_MonthlyPrice.Text}\", `Monthy_KM`= \"{txt_Monthlykm.Text}\", `Extrakm_price`= \"{txt_ExtrakmPrice.Text}\", `Owner_payment`= \"{txt_OwnerPayment.Text}\", `Starting_odo`= \"{msktxt_startingOdo.Text}\", `OverallView`= \"{pb_overallViewimg.Text}\", `InsideView`= \"{pb_InsideViewimg.Text}\" =  WHERE `Vehicle_num`= \"{dataGridView1.SelectedRows[0].Cells[0].Value}\"";
                        
                        try
                        {
                            DbConnection.Update(query);
                            setDataToGrid("SELECT `Vehicle_num`, `Brand`, `Model`, `Type`, `Owner_NIC` FROM `vehicle`");
                            CustomMessage submitmessege = new CustomMessage("successfully Updated!", "Update", ShineWay.Properties.Resources.correct, DialogResult.OK);
                            submitmessege.convertToOkButton();
                            submitmessege.ShowDialog();

                        }
                        catch (Exception exc)
                        {
                            CustomMessage submitmessege = new CustomMessage("Unable to Update!", "Error", ShineWay.Properties.Resources.error, DialogResult.OK);
                            submitmessege.convertToOkButton();
                            submitmessege.ShowDialog();
                        }


                    }
                    else
                    {
                        CustomMessage submitmessege = new CustomMessage("All fields must be corrected\nbefore Update!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                        submitmessege.convertToOkButton();
                        submitmessege.ShowDialog();
                    }

                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
           /* isVehRegNoValid = true;
            isNICValid = true;
            isBrandValid = true;
            isModelValid = true;
            isVehicleTypeValid = true;*/

            msktxt_vehicleRegNumber.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_brand.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_model.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            combo_type.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_ownerNIC.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txt_engineNumber.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txt_chasisNumber.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            date_registeredDate.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txt_ownerCondition.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            txt_DailyPrice.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            txt_Dailykm.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            txt_WeeklyPrice.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            txt_Weeklykm.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            txt_MonthlyPrice.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
            txt_Monthlykm.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
            txt_ExtrakmPrice.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
            txt_OwnerPayment.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
            msktxt_startingOdo.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();
        //    pb_overallViewimg.Image= dataGridView1.SelectedRows[0].Cells[18].Value.ToString();
        //    pb_InsideViewimg.Image = dataGridView1.SelectedRows[0].Cells[19].Value.ToString();
           
        }

        private void msktxt_startingOdo_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }
    }
}

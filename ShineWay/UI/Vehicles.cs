using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShineWay.DataBase;
using MySql.Data.MySqlClient;
using System.IO;
using ShineWay.Validation;
using ShineWay.Messages;
using ShineWay.Classes;

namespace ShineWay.UI
{
    public partial class Vehicles : UserControl

    {
        bool isValidVehicleRegNo = false;
        bool isNICValid = false;
        bool isOwnerConditionValid = false;
        bool isBrandValid = false;
        bool isVehRegNoValid = false;
        bool isModelValid = false;
        bool isEngineNoValid = false;
        bool isChassisNoValid = false;
        List<Vehicle> vehicles = new List<Vehicle>();

        public Vehicles()
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


        //Insert Button
        private void pb_btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pb_overallViewimg.Image.Save(ms, pb_overallViewimg.Image.RawFormat);
                pb_InsideViewimg.Image.Save(ms, pb_InsideViewimg.Image.RawFormat);
                Byte[] img = ms.ToArray();

                MySqlDataReader rd1 = DbConnection.Read("INSERT INTO `vehicle`(`Vehicle_num`, `Brand`, `Model`, `Type`, `Engine_Num`," +
                    " `Chassis_Num`, `Owner_NIC`, `Reg_Date`, `Owner_Condi`, `Daily_price`, `Daliy_KM`, `Weekly_price`, `Weekly_KM`, `Monthly_price`," +
                    " `Monthy_KM`, `Owner_payment`, `Starting_odo`, `OverallView`, `InsideView`) VALUES ('" + msktxt_vehicleRegNumber.Text + "','" + txt_brand.Text + "','" + txt_model.Text + "'," +
                    "'" + combo_type.Text + "','" + txt_engineNumber.Text + "','" + txt_chasisNumber.Text + "','" + txt_ownerNIC.Text + "','" + date_registeredDate.Text + "','" + txt_ownerCondition.Text + "'" +
                    ",'" + txt_DailyPrice.Text + "','" + txt_Dailykm.Text + "','" + txt_WeeklyPrice.Text + "','" + txt_Weeklykm.Text + "','" + txt_MonthlyPrice.Text + "'," +
                    "'" + txt_Monthlykm.Text + "','" + txt_OwnerPayment.Text + "','" + msktxt_startingOdo.Text + "','" + pb_InsideViewimg.Image + "','" + pb_overallViewimg.Image + "')");

           

                //  MessageBox.Show("Added Successfullly!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CustomMessage addmsg = new CustomMessage("Vehicle Added Successfully!", "Added", ShineWay.Properties.Resources.correct, DialogResult.OK);
                addmsg.convertToOkButton();
                addmsg.ShowDialog();
            }

            catch (Exception ex)
            {
                // MessageBox.Show("Vehicle not added!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CustomMessage addmsgerr = new CustomMessage("Vehicle not added!", "Error", ShineWay.Properties.Resources.wrong, DialogResult.OK);
                addmsgerr.convertToOkButton();
                addmsgerr.ShowDialog();
            }
          
        }
         
       /* public void FillDataGridView()
        {
            MySqlDataReader rd = DbConnection.Read("SELECT * FROM `vehicle`");
            DataTable tbl = new DataTable();
         //   MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
          //  adp.Fill(tbl);
            dataGridView1.RowTemplate.Height = 60;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.DataSource = tbl;

            DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
            imgcol = (DataGridViewImageColumn)dataGridView1.Columns[17];
            imgcol = (DataGridViewImageColumn)dataGridView1.Columns[18];
            imgcol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }*/
        public void setDataToGrid(string valueToSearch)
        {

            try
            {
                MySqlDataReader reader = DbConnection.Read("SELECT * FROM `vehicle` WHERE CONCAT (`Vehicle_num`, `Brand`, `Model`, `Type`, `Engine_Num`, `Chassis_Num`, `Owner_NIC`, `Reg_Date`, `Owner_Condi`, `Daily_price`, `Daliy_KM`, `Weekly_price`, `Weekly_KM`, `Monthly_price`, `Monthy_KM`, `Owner_payment`, `Starting_odo`, `OverallView`, `InsideView`) LIKE '%" + valueToSearch + "%'");
                while (reader.Read())
                {
                  Vehicle vehicle = new Vehicle();
                    vehicle.vehNumber = reader[0].ToString();
                    vehicle.Brand = reader[1].ToString();
                    vehicle.model = reader[2].ToString();
                    vehicle.type = reader[3].ToString();
                    vehicle.engineNumber = reader[4].ToString();
                    vehicle.chassisNumber = reader[5].ToString();
                    vehicle.ownerNic = reader[6].ToString();
                    vehicle.registerDate = reader[7].ToString();
                    vehicle.ownerCondition = reader[8].ToString();
                    vehicle.dailyPrice = reader[9].ToString();
                    vehicle.dailyKm = reader[10].ToString();
                    vehicle.weeklyPrice = reader[11].ToString();
                    vehicle.weeklyKm = reader[12].ToString();
                    vehicle.monthlyPrice = reader[13].ToString();
                    vehicle.monthlyKm = reader[14].ToString();
                    vehicle.ownerPayment = reader[15].ToString();
                    vehicle.startingOdometer = reader[16].ToString();
                  //  vehicle.overallView = reader[17].ToString();
                  //  vehicle.insideView = reader[18].ToString();
                    vehicles.Add(vehicle);

                    DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
                    imgcol = (DataGridViewImageColumn)dataGridView1.Columns[17];
                    imgcol = (DataGridViewImageColumn)dataGridView1.Columns[18];
                    imgcol.ImageLayout = DataGridViewImageCellLayout.Stretch;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

            }
            catch (Exception ex)
            {
                CustomMessage submitmessege = new CustomMessage(ex.Message, "", ShineWay.Properties.Resources.tick, DialogResult.OK);
                submitmessege.convertToOkButton();
                submitmessege.ShowDialog();


            }

            dataGridView1.DataSource = vehicles;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          // Byte[] img = (Byte[])dataGridView1.CurrentRow.Cells[17].Value;
        //   Byte[] img1 = (Byte[])dataGridView1.CurrentRow.Cells[18].Value;

          //  MemoryStream ms = new MemoryStream(img);
          //  MemoryStream ms1 = new MemoryStream(img1);

        //    pb_overallViewimg.Image = Image.FromStream(ms);
         //   pb_InsideViewimg.Image = Image.FromStream(ms1);

            msktxt_vehicleRegNumber.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_brand.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_model.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            combo_type.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_engineNumber.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_chasisNumber.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_ownerNIC.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            date_registeredDate.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_ownerCondition.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txt_DailyPrice.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txt_Dailykm.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txt_WeeklyPrice.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txt_Weeklykm.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txt_MonthlyPrice.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txt_Monthlykm.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            txt_OwnerPayment.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            msktxt_startingOdo.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();

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
            label_VehicleTypeError.Visible = false;
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void combo_type_TextChanged(object sender, EventArgs e)
        {
            if (combo_type.Text != "")
            {
                label_VehicleTypeError.Visible = false;
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
            setDataToGrid("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            setDataToGrid(textBox1.Text);
        }
    }
}

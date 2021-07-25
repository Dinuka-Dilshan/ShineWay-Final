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
using ShineWay.DataBase;
using MySql.Data.MySqlClient;

namespace ShineWay.UI
{
    public partial class OwnerPayment : UserControl
    {
        bool isNICValid = false;
        bool isVehhicleNumValid = false;
        bool isAmountValid = false;
        bool isPaymentIDValid = false;

        private void DisplayData()
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost; username=root; password=; database=shineway");
            MySqlCommand cmd;
            MySqlDataAdapter adapt;
            con.Open();
            DataTable dt = new DataTable();
            adapt = new MySqlDataAdapter("select * from owner_payment", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public OwnerPayment()
        {
            InitializeComponent();
            date_OwnerPayment.MinDate = DateTime.Now;

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

        private void txt_paymentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_paymentID_Leave(object sender, EventArgs e)
        {

            bool validpaymentID = Validates.ValidBookingID(txt_paymentID.Text);
            if (validpaymentID == false)
            {
                txt_paymentID.ForeColor = Color.Red;
            }
            else
            {
                txt_paymentID.ForeColor = Color.Green;
            }
        }

        private void txt_ownerNIC_Leave(object sender, EventArgs e)
        {
            bool validownernic1 = Validates.ValidCustomerOldNIC(txt_ownerNIC.Text);
            bool validownernic2 = Validates.ValidCustomerNewNIC(txt_ownerNIC.Text);

            if (validownernic1 == true || validownernic2 == true)
            {
                txt_ownerNIC.ForeColor = Color.Green;
            }
            else
            {
                txt_ownerNIC.ForeColor = Color.Red;
            }
        }

        private void txt_VehicleNumber_Leave(object sender, EventArgs e)
        {
            bool validVehicleNumber1 = Validates.ValidVehiclenumber1(txt_VehicleNumber.Text);
            bool validVehicleNumber2 = Validates.ValidVehiclenumber2(txt_VehicleNumber.Text);

            if (validVehicleNumber1 == true || validVehicleNumber2 == true)
            {
                txt_VehicleNumber.ForeColor = Color.Green;
            }
            else
            {
                txt_VehicleNumber.ForeColor = Color.Red;
            }
        }

        private void txt_OwnerPayment_Leave(object sender, EventArgs e)
        {
            bool depositeamount = Validates.ValidAmount(txt_OwnerPayment.Text);

            if (depositeamount == false)
            {
                txt_OwnerPayment.ForeColor = Color.Red;
            }
            else
            {
                txt_OwnerPayment.ForeColor = Color.Green;
                txt_OwnerPayment.TextAlign = HorizontalAlignment.Right;
            }
        }

        private void pb_btnReset_Click(object sender, EventArgs e)
        {

        }

        private void pb_btnReset_Click_1(object sender, EventArgs e)
        {
            txt_paymentID.Text = "";
            txt_ownerNIC.Text = "";
            txt_VehicleNumber.Text = "";
            txt_OwnerPayment.Text = "";
            date_OwnerPayment.Value = DateTime.Now;
            label_nicError.Visible = false;
            label_tickNIC.Visible = false;
            label_nicVehicleNum.Visible = false;
            label_AmountError.Visible = false;
            label_tickAmount.Visible = false;
            label_tickVehicleNum.Visible = false;
            label_tickPaymentID.Visible = false;
            date_OwnerPayment.Value = DateTime.Now;
        }

        private void pb_btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataBase.DbConnection.Read("insert into owner_payment (Owner_NIC , payment_date, Payment_ID, payment_ODO, Owner_pay_Amount) Values" +
                "('" + txt_ownerNIC.Text + "','" + date_OwnerPayment.Text + "','" + txt_paymentID.Text + "','" + txt_VehicleNumber.Text + "','"
                + txt_OwnerPayment.Text + "')");

                CustomMessage message = new CustomMessage("Payment Added Successfully!", "Added", ShineWay.Properties.Resources.correct, DialogResult.OK);
                message.convertToOkButton();
                message.ShowDialog();
                DisplayData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void pb_btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DbConnection.Read("UPDATE owner_payment set Payment_ID='" + txt_paymentID.Text + "', payment_date='" + date_OwnerPayment.Text + "', payment_ODO='"
                + txt_VehicleNumber.Text + "' , Owner_pay_Amount='" + txt_OwnerPayment.Text + "' where Owner_NIC='" + txt_ownerNIC.Text + "'");

                CustomMessage message = new CustomMessage("Update Successfully!", "Updated", ShineWay.Properties.Resources.correct, DialogResult.OK);
                message.convertToOkButton();
                message.ShowDialog();
                DisplayData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void pb_btnDelete_Click(object sender, EventArgs e)
        {
            if (txt_ownerNIC.Text != "")
            {

                try
                {
                    DbConnection.Read("delete from owner_payment where Owner_NIC='" + txt_ownerNIC.Text + "'");

                    CustomMessage message = new CustomMessage("Deleted Successfully!", "Saved", ShineWay.Properties.Resources.correct, DialogResult.OK);
                    message.convertToOkButton();
                    message.ShowDialog();

                    DisplayData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
            

                //delete code
        }

        private void txt_OwnerPayment_Enter(object sender, EventArgs e)
        {
            txt_OwnerPayment.TextAlign = HorizontalAlignment.Left;
        }

        private void txt_paymentID_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidBookingID(txt_paymentID.Text))
            {
                pictureBox5.Image = ShineWay.Properties.Resources.correctInput;
                label_PaymentIDError.Visible = false;
                label_tickPaymentID.Visible = true;
                isPaymentIDValid = true;

            }
            else
            {
                pictureBox5.Image = ShineWay.Properties.Resources.errorinput;
                label_PaymentIDError.Visible = true;
                label_tickPaymentID.Visible = false;
                isPaymentIDValid = false;
            }
        }

        private void txt_ownerNIC_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidCustomerNewNIC(txt_ownerNIC.Text) || Validates.ValidCustomerOldNIC(txt_ownerNIC.Text))
            {
                pictureBox5.Image = ShineWay.Properties.Resources.correctInput;
                label_nicError.Visible = false;
                label_tickNIC.Visible = true;
                isNICValid = true;

            }
            else
            {
                pictureBox5.Image = ShineWay.Properties.Resources.errorinput;
                label_nicError.Visible = true;
                label_tickNIC.Visible = false;
                isNICValid = false;
            }
        }

        private void txt_VehicleNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidVehiclenumber1(txt_VehicleNumber.Text) || Validates.ValidVehiclenumber2(txt_VehicleNumber.Text))
            {
                pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
                label_nicVehicleNum.Visible = false;
                label_tickVehicleNum.Visible = true;
                isVehhicleNumValid = true;

            }
            else
            {
                pictureBox7.Image = ShineWay.Properties.Resources.errorinput;
                label_nicVehicleNum.Visible = true;
                label_tickVehicleNum.Visible = false;
                isVehhicleNumValid = false;
            }
        }

        private void txt_OwnerPayment_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidAmount(txt_OwnerPayment.Text))
            {
                pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
                label_AmountError.Visible = false;
                label_tickAmount.Visible = true;
                isAmountValid = true;

            }
            else
            {
                pictureBox11.Image = ShineWay.Properties.Resources.errorinput;
                label_AmountError.Visible = true;
                label_tickAmount.Visible = false;
                isAmountValid = false;
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_paymentID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_ownerNIC.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_VehicleNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_OwnerPayment.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            date_OwnerPayment.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void OwnerPayment_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
    }

}

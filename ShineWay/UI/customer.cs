using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ShineWay.Messages;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShineWay.Validation;
using ShineWay.DataBase;
using ShineWay.Classes;

namespace ShineWay.UI
{
    public partial class customer : UserControl
    {
        //Validation.Validates obj1 = new Validation.Validates();
        
        bool isNICValid = false;
        bool isLicensenumberValid = false;
        bool isCusNameValid = false;
        bool isTelNumValid = false;
        bool isEmailValid = false;
        bool isAddressValid = false;

        private void DisplayData()
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost; username=root; password=; database=shineway");
            MySqlCommand cmd;
            MySqlDataAdapter adapt;
            con.Open();
            DataTable dt = new DataTable();
            adapt = new MySqlDataAdapter("select * from customer", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public customer()
        {
            InitializeComponent();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

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

        private void pb_btnReset_Click(object sender, EventArgs e)
        {
            // reset button code goes here
            txt_nicNumber.Text = "";
            txt_licenseNumber.Text = "";
            txt_customerName.Text = "";
            txt_telephoneNumber.Text = "";
            txt_email.Text = "";
            txt_address.Text = "";
            label_tickNIC.Visible = false;
            label_tickLicenseNum.Visible = false;
            label_tickName.Visible = false;
            label_tickTelNum.Visible = false;
            label_tickEmail.Visible = false;
            label_tickAddress.Visible = false;
            label_nicError.Visible = false;
            label_nameError.Visible = false;
            label_addressError.Visible = false;
            label_emailError.Visible = false;
            label_telnumberError.Visible = false;
            label_licenseError.Visible = false;
        }

        private void pb_btnAdd_Click(object sender, EventArgs e)
        {
            // add button code goes here
            if (isAllValid())
            {
                try
                {
                    DataBase.DbConnection.Read("insert into customer (Cus_NIC , Licen_num, Cus_name, Tel_num, Email , Cus_Address) Values" +
                    "('" + txt_nicNumber.Text + "','" + txt_licenseNumber.Text + "','" + txt_customerName.Text + "','" + txt_telephoneNumber.Text + "','" + txt_email.Text + "','"
                    + txt_address.Text + "')");

                    CustomMessage message = new CustomMessage("User Added Successfully!", "Added", ShineWay.Properties.Resources.correct, DialogResult.OK);
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
                CustomMessage submitmessege = new CustomMessage("All fields must be corrected\n before Added!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                submitmessege.convertToOkButton();
                submitmessege.ShowDialog();
            }
                
            
        }

        private void pb_btnUpdate_Click(object sender, EventArgs e)
        {
            // update button code goes here
            if (isAllValid())
            {
                try
                {
                    DbConnection.Read("UPDATE customer set Licen_num='" + txt_licenseNumber.Text + "', Cus_name='" + txt_customerName.Text + "' , Tel_num='" + txt_telephoneNumber.Text + "', Email='"
                    + txt_email.Text + "' , Cus_Address='" + txt_address.Text + "' where Cus_NIC='" + txt_nicNumber.Text + "'");

                    CustomMessage message = new CustomMessage("User Updated Successfully!", "Updated", ShineWay.Properties.Resources.correct, DialogResult.OK);
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
                CustomMessage submitmessege = new CustomMessage("All fields must be corrected\n before Updated!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                submitmessege.convertToOkButton();
                submitmessege.ShowDialog();
            }
            
        }

        private void pb_btnDelete_Click(object sender, EventArgs e)
        {
            //delete button code goes here
            CustomMessage submitmessege = new CustomMessage("Are you sure to Delete ?", "Warning", ShineWay.Properties.Resources.question, DialogResult.Yes);
            DialogResult result = submitmessege.ShowDialog();

            if (result == DialogResult.Yes)
            {
                if (txt_nicNumber.Text != "")
                {

                    try
                    {
                        DbConnection.Read("delete from customer where Cus_NIC='" + txt_nicNumber.Text + "'");

                        CustomMessage message = new CustomMessage("User Deleted Successfully!", "Saved", ShineWay.Properties.Resources.correct, DialogResult.OK);
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
                    CustomMessage message = new CustomMessage("Please Select Record to Delete", "Error", ShineWay.Properties.Resources.error, DialogResult.OK);
                    message.convertToOkButton();
                    message.ShowDialog();

                }
            }
        }

        

        private void txt_nicNumber_Validated(object sender, EventArgs e)
        {
            
           
        }

        private void ValidCustomerOldNIC(object sender, EventArgs e)
        {

        }

        
        
        private void pictureBox3_Click_2(object sender, EventArgs e)
        {

        }

        private void txt_nicNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidCustomerNewNIC(txt_nicNumber.Text) || Validates.ValidCustomerOldNIC(txt_nicNumber.Text))
            {
                pictureBox2.Image = ShineWay.Properties.Resources.correctInput;
                label_nicError.Visible = false;
                label_tickNIC.Visible = true;
                isNICValid = true;

            }
            else
            {
                pictureBox2.Image = ShineWay.Properties.Resources.errorinput;
                label_nicError.Visible = true;
                label_tickNIC.Visible = false;
                isNICValid = false;
            }
        }

        private void txt_licenseNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidLicensenumber(txt_licenseNumber.Text))
            {
                pictureBox5.Image = ShineWay.Properties.Resources.correctInput;
                label_licenseError.Visible = false;
                label_tickLicenseNum.Visible = true;
                isLicensenumberValid = true;

            }
            else
            {
                pictureBox5.Image = ShineWay.Properties.Resources.errorinput;
                label_licenseError.Visible = true;
                label_tickLicenseNum.Visible = false;
                isLicensenumberValid = false;
            }
        }

        private void txt_customerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidName(txt_customerName.Text))
            {
                pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
                label_nameError.Visible = false;
                label_tickName.Visible = true;
                isCusNameValid = true;

            }
            else
            {
                pictureBox7.Image = ShineWay.Properties.Resources.errorinput;
                label_nameError.Visible = true;
                label_tickName.Visible = false;
                isCusNameValid = false;
            }
        }

        private void txt_telephoneNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidMobile(txt_telephoneNumber.Text))
            {
                pictureBox9.Image = ShineWay.Properties.Resources.correctInput;
                label_telnumberError.Visible = false;
                label_tickTelNum.Visible = true;
                isTelNumValid = true;

            }
            else
            {
                pictureBox9.Image = ShineWay.Properties.Resources.errorinput;
                label_telnumberError.Visible = true;
                label_tickTelNum.Visible = false;
                isTelNumValid = false;
            }
        }

        private void txt_email_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidEmail(txt_email.Text))
            {
                pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
                label_emailError.Visible = false;
                label_tickEmail.Visible = true;
                isEmailValid = true;

            }
            else
            {
                pictureBox11.Image = ShineWay.Properties.Resources.errorinput;
                label_emailError.Visible = true;
                label_tickEmail.Visible = false;
                isEmailValid = false;
            }
        }

        private void txt_address_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidateDescription(txt_address.Text))
            {
                pictureBox13.Image = ShineWay.Properties.Resources.correctInput;
                label_addressError.Visible = false;
                label_tickAddress.Visible = true;
                isAddressValid = true;

            }
            else
            {
                pictureBox13.Image = ShineWay.Properties.Resources.errorinput;
                label_addressError.Visible = true;
                label_tickAddress.Visible = false;
                isAddressValid = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_nicNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_licenseNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_customerName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_telephoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_email.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_address.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }

        private void customer_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private bool isAllValid()
        {
            return (isNICValid && isEmailValid && isTelNumValid && isCusNameValid && isLicensenumberValid && isAddressValid);
        }


        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost; username=root; password=; database=shineway");
            con.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter("SELECT  `Cus_NIC`, `Licen_num`, `Cus_name`, `Tel_num`,`Email`, `Cus_Address`  FROM `customer` WHERE `Cus_NIC` LIKE \"%{txt_search.Text}%\" OR `Licen_num` LIKE \"%{txt_search.Text}%\" OR `Cus_name` LIKE \"%{txt_search.Text}%\"  OR `Tel_num` LIKE \"%{txt_search.Text}%\" OR `Email` LIKE \"%{txt_search.Text}%\" OR `Cus_Address` LIKE \"%{txt_search.Text}%\"", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }





        /*
        void setDataToTable(string query)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            MySqlDataReader reader = DbConnection.Read(query);

            while (reader.Read())
            {
                int x = dataGridView1.Rows.Add();
                dataGridView1.Rows[x].Cells[0].Value = reader.GetString("Cus_NIC");
                dataGridView1.Rows[x].Cells[1].Value = reader.GetString("Licen_num");
                dataGridView1.Rows[x].Cells[2].Value = reader.GetString("Cus_name");
                dataGridView1.Rows[x].Cells[3].Value = reader.GetString("Tel_num");
                dataGridView1.Rows[x].Cells[4].Value = reader.GetString("Email");
                dataGridView1.Rows[x].Cells[5].Value = reader.GetString("Cus_Address");


            }
        }*/
    }
}

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
using MySql.Data.MySqlClient;
using ShineWay.DataBase;


namespace ShineWay.UI
{
    public partial class VehicleOwner : UserControl
    {


        bool isOwnerNICValid = false;
        bool isOwnerEmailValid = false;
        bool isTelephoneNumberValid = false;
        bool isOwnerNameValid = false;
        bool isOwnerNameValidForUpdate = false;
        bool isAddressValid = false;


        bool isTelephoneNumberValidForUpdate = true;
        bool isNICValidForUpdate = true;
        bool isEmailValidForUpdate = true;
        bool isAddressValidForUpdate = true;


        public VehicleOwner()
        {
            InitializeComponent();
            setDataToDGV("SELECT `Owner_NIC`, `Owner_name`, `Tel_num`, `Owner_Email`, `Owner_Address`, `Salute`, `ID` FROM `owner`");
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





        void setDataToDGV(string query)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            try
            {

                MySqlDataReader reader = DbConnection.Read(query);

                while (reader.Read())
                {
                    int x = dataGridView1.Rows.Add();
                    dataGridView1.Rows[x].Cells[0].Value = reader.GetString("Owner_NIC");
                    dataGridView1.Rows[x].Cells[1].Value = reader.GetString("Owner_name");
                    dataGridView1.Rows[x].Cells[2].Value = reader.GetString("Tel_num");
                    dataGridView1.Rows[x].Cells[3].Value = reader.GetString("Owner_Email");
                    dataGridView1.Rows[x].Cells[4].Value = reader.GetString("Owner_Address");
                    dataGridView1.Rows[x].Cells[5].Value = reader.GetString("Salute");
                    dataGridView1.Rows[x].Cells[6].Value = reader.GetString("ID");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

      

  



        //Reset Button
        private void pb_btnReset_Click(object sender, EventArgs e)
        {
            txt_nicNumber.Text = "";
            lbl_salutation.Text = "--";
            txt_ownerName.Text = "";
            txt_telephone.Text = "";
            txt_email.Text = "";
            txt_address.Text = "";
            lbl_salutation.Text = "";

           
            pictureBox2.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox5.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox7.Image = ShineWay.Properties.Resources.correctInput; 
            pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox13.Image = ShineWay.Properties.Resources.correctInput;

            label_nicError.Visible = false;
            label_OwnerNameError.Visible = false;
            label_TelephoneError.Visible = false;
            label_EmailError.Visible = false;
            label_AddressError.Visible = false;

            label_tickNICnumber.Visible = false;
            label_tickOwnerName.Visible = false;
            label_tickTelephoneNumber.Visible = false;
            label_tickEmail.Visible = false;
            label_tickAddress.Visible = false;

        }

        private bool isAllValid()
        {
            return (isOwnerNICValid && isOwnerNameValid && isTelephoneNumberValid && isOwnerEmailValid && isAddressValid);
        }

        //Add Button
        private void pb_btnAdd_Click(object sender, EventArgs e)
        {

            // add button code goes here
            Cursor = Cursors.WaitCursor;
            MySqlDataReader reader;

            if (txt_nicNumber.Text.Trim() == "" || txt_ownerName.Text.Trim() == "" || txt_telephone.Text.Trim() == "" || txt_email.Text.Trim() == "" || txt_address.Text.Trim() == "")
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
                        reader = DbConnection.Read("SELECT COUNT(`ID`) FROM `owner`");
                        while (reader.Read())
                        {

                        }


                        try
                        {
                            
                            String addQuery = $"INSERT INTO `owner`(`Owner_NIC`, `Salute`, `Owner_name`, `Tel_num`, `Owner_Email`, `Owner_Address`) VALUES   (  \"{txt_nicNumber}\",\"{lbl_salutation}\"  \"{txt_ownerName}\",  \"{txt_telephone.Text}\",   \"{txt_email.Text}\",   \"{txt_address.Text}\")";

                            DbConnection.Write(addQuery);
                            CustomMessage message = new CustomMessage("User Added Successfully!", "Added", ShineWay.Properties.Resources.correct, DialogResult.OK);
                            message.convertToOkButton();
                            message.ShowDialog();
                            pb_btnReset_Click(sender, e);

                        }
                        catch (Exception exe)
                        {
                            MessageBox.Show(exe.Message);
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

            setDataToDGV("SELECT `Owner_NIC`, `Owner_name`, `Tel_num`, `Owner_Email`, `Owner_Address`, `Salute`, `ID` FROM `owner`");
            Cursor = Cursors.Arrow;

        }


        //Update Button
        private void pb_btnUpdate_Click(object sender, EventArgs e)
        {

        }

       // Delete  Button
        private void pb_btnDelete_Click(object sender, EventArgs e)
        {

            CustomMessage submitmessege = new CustomMessage("Are you sure to Delete ?", "Warning", ShineWay.Properties.Resources.question, DialogResult.Yes);
            DialogResult result = submitmessege.ShowDialog();

            if (result == DialogResult.Yes)
            {
                string query = $"DELETE FROM `owner` WHERE `Owner_NIC`= \"{dataGridView1.SelectedRows[0].Cells[0].Value}\"";
                try
                {
                    DbConnection.Delete(query);
                    CustomMessage m = new CustomMessage("successfully Deleted!", "Deleted", ShineWay.Properties.Resources.correct, DialogResult.OK);
                    m.convertToOkButton();
                    m.ShowDialog();
                    setDataToDGV("SELECT `Owner_NIC`, `Owner_name`, `Tel_num`, `Owner_Email`, `Owner_Address`, `Salute`, `ID` FROM `owner`");

                }
                catch (Exception exc)
                {
                    CustomMessage messege = new CustomMessage("Unable to Delete!", "Error", ShineWay.Properties.Resources.error, DialogResult.OK);
                    messege.convertToOkButton();
                    messege.ShowDialog();
                }
            }

        }


        //---------------Validations------------
        private void txt_email_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidEmail(txt_email.Text.Trim()))
            {
                pictureBox1.Image = ShineWay.Properties.Resources.correctInput;
                label_EmailError.Visible = false;
                label_tickEmail.Visible = true;
                isOwnerEmailValid = true;
                isEmailValidForUpdate = true;

            }
            else
            {
                pictureBox1.Image = ShineWay.Properties.Resources.errorinput;
                label_EmailError.Visible = true;
                label_tickEmail.Visible = false;

                isOwnerEmailValid = false;
                isEmailValidForUpdate = false;
            }
        }

        private void txt_telephone_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidMobile(txt_telephone.Text.Trim()))
            {
                pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
                label_TelephoneError.Visible = false;
                label_tickTelephoneNumber.Visible = true;
                isTelephoneNumberValid = true;
                isTelephoneNumberValidForUpdate = true;

            }
            else
            {
                pictureBox7.Image = ShineWay.Properties.Resources.errorinput;
                label_TelephoneError.Visible = true;
                label_tickTelephoneNumber.Visible = false;
                isTelephoneNumberValid = false;
                isTelephoneNumberValidForUpdate = false;
            }
        }

        private void txt_nicNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidCustomerNewNIC(txt_nicNumber.Text) || Validates.ValidCustomerOldNIC(txt_nicNumber.Text))
            {
                pictureBox2.Image = ShineWay.Properties.Resources.correctInput;
                label_nicError.Visible = false;
                label_tickNICnumber.Visible = true;
                isOwnerNICValid = true;
                isNICValidForUpdate = true;

            }
            else
            {
                pictureBox2.Image = ShineWay.Properties.Resources.errorinput;
                label_nicError.Visible = true;
                label_tickNICnumber.Visible = false;
                isOwnerNICValid = false;
                isNICValidForUpdate = false;
            }
        }

        private void txt_ownerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (Validates.ValidName(txt_ownerName.Text))
            {
                pictureBox5.Image = ShineWay.Properties.Resources.correctInput;
                label_OwnerNameError.Visible = false;
                label_tickOwnerName.Visible = true;
                isOwnerNameValid = true;
                isOwnerNameValidForUpdate = true;
            }
            else
            {
                pictureBox5.Image = ShineWay.Properties.Resources.errorinput;
                label_OwnerNameError.Visible = true;
                label_tickOwnerName.Visible = false;
                isOwnerNameValid = false;
                isOwnerNameValidForUpdate = false;
            }
        }

        private void txt_address_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_address.Text.Length > 200 || (txt_address.Text.Length == 0))
            {
                pictureBox13.Image = ShineWay.Properties.Resources.errorinput;
                if ((txt_address.Text.Length == 0))
                {
                    label_AddressError.Text = "Address cannot be empty!";
                }
                else
                {
                    label_AddressError.Text = "Cannot exceeds more than 200 charactors!";
                }
                label_AddressError.Visible = true;
                label_tickAddress.Visible = false;
                isAddressValid = false;
                isAddressValidForUpdate = false;
            }
            else
            {
                pictureBox13.Image = ShineWay.Properties.Resources.correctInput;
                label_AddressError.Visible = false;
                label_tickAddress.Visible = true;
                isAddressValid = true;
                isAddressValidForUpdate = true;
            }
        }

        private void VehicleOwner_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isOwnerNICValid = true;
            isOwnerNameValid = true;
            isTelephoneNumberValid = true;
            isOwnerEmailValid = true;
            isAddressValid = true;


            txt_nicNumber.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_ownerName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_telephone.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_email.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_address.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            lbl_salutation.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();


            //to reset warnings
            pictureBox2.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox5.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox7.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox11.Image = ShineWay.Properties.Resources.correctInput;
            pictureBox13.Image = ShineWay.Properties.Resources.correctInput;

            label_nicError.Visible = false;
            label_OwnerNameError.Visible = false;
            label_TelephoneError.Visible = false;
            label_EmailError.Visible = false;
            label_AddressError.Visible = false;

            label_tickNICnumber.Visible = false;
            label_tickOwnerName.Visible = false;
            label_tickTelephoneNumber.Visible = false;
            label_tickEmail.Visible = false;
            label_tickAddress.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = $"SELECT `Owner_NIC`, `Owner_name`, `Tel_num`, `Owner_Email`, `Owner_Address`, `Salute`, `ID` FROM `owner` WHERE `Owner_NIC` LIKE \"%{txt_nicNumber.Text}%\" OR `Owner_name` LIKE \"%{txt_ownerName.Text}%\" OR `Tel_num` LIKE \"%{txt_telephone.Text}%\"  OR `Owner_Email` LIKE \"%{txt_email.Text}%\" OR `Owner_Address` LIKE \"%{txt_address.Text}%\"";

            setDataToDGV(query);
        }
    }
}

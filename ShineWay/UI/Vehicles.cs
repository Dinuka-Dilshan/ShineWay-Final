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

namespace ShineWay.UI
{
    public partial class Vehicles : UserControl
    {
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
                    " `Monthy_KM`, `Owner_payment`, `Starting_odo`, `OverallView`, `InsideView`) VALUES ('"+msktxt_vehicleRegNumber.Text+"','"+txt_brand.Text+"','"+txt_model.Text+"'," +
                    "'"+combo_type.Text+"','"+txt_engineNumber.Text+"','"+txt_chasisNumber.Text+"','"+txt_ownerNIC.Text+"','"+date_registeredDate.Text+"','"+txt_ownerCondition.Text+"'" +
                    ",'"+txt_DailyPrice.Text+"','"+txt_Dailykm.Text+"','"+txt_WeeklyPrice.Text+"','"+txt_Weeklykm.Text+"','"+txt_MonthlyPrice.Text+"'," +
                    "'"+txt_Monthlykm.Text+"','"+txt_OwnerPayment.Text+"','"+txt_StartingOdo.Text+"','"+pb_InsideViewimg.Image+"','"+pb_overallViewimg.Image+"')");

                MessageBox.Show("Added Successfullly!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vehicle not added!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillDataGridView()
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
            Byte[] img = (Byte[])dataGridView1.CurrentRow.Cells[17].Value;
            Byte[] img1 = (Byte[])dataGridView1.CurrentRow.Cells[18].Value;

            MemoryStream ms = new MemoryStream(img);
            MemoryStream ms1 = new MemoryStream(img1);

            pb_overallViewimg.Image = Image.FromStream(ms);
            pb_InsideViewimg.Image = Image.FromStream(ms1);

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
            txt_StartingOdo.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();

        }

        private void combo_Packagetype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_Packagetype_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

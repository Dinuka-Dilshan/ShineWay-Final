using System;
using ShineWay.DataBase;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ShineWay.UI
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        private void pb_btnNext_MouseHover(object sender, EventArgs e)
        {
            pb_btnNext.Image = ShineWay.Properties.Resources.nextHover;
        }

        private void pb_btnNext_MouseLeave(object sender, EventArgs e)
        {
            pb_btnNext.Image = ShineWay.Properties.Resources.next;
        }

        private void pb_btnPrevious_MouseHover(object sender, EventArgs e)
        {
            pb_btnPrevious.Image = ShineWay.Properties.Resources.previousHover;
        }

        private void pb_btnPrevious_MouseLeave(object sender, EventArgs e)
        {
            pb_btnPrevious.Image = ShineWay.Properties.Resources.previous;
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            
        
        
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            String searchKeyValue = txt_search.Text;
            String query = "SELECT `Vehicle_num`, `Brand`, `Model`,`Owner_Condi`, `Rent_price`,`Daily_price`, `Daliy_KM`, `Weekly_price`, `Weekly_KM`, `Monthly_price`, `Monthy_KM`, `Wedding_price`  FROM `vehicle` WHERE `Brand` LIKE '%" + searchKeyValue + "%' OR `Model` LIKE '%" + searchKeyValue + "%' OR `Daily_price` LIKE '%" + searchKeyValue + "%' ";


            MySqlDataReader reader = DbConnection.Read(query);
            while (reader.Read())
            {
                while (reader.HasRows)
                {
                    label1.Text = reader[1].ToString();
                }
                
            }
        }

   
    }
}

using System;
using ShineWay.DataBase;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShineWay.Classes;
using System.Collections.Generic;

namespace ShineWay.UI
{
    public partial class HomeControl : UserControl
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        int vehicleIndex = 0;

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
            String query = "SELECT `Vehicle_num`, `Brand`,`Daily_price`, `Weekly_price`, `Monthly_price`, `Wedding_price`  FROM `vehicle` WHERE `Brand` LIKE '%" + searchKeyValue + "%' OR `Model` LIKE '%" + searchKeyValue + "%' OR `Daily_price` LIKE '%" + searchKeyValue + "%' OR `Type` LIKE '%" + searchKeyValue + "%'";
            vehicles.Clear();
            

            MySqlDataReader reader = DbConnection.Read(query);
            while (reader.Read())
            {
               vehicles.Add(new Vehicle(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                
            }

            label_VehicleNumber.Text = vehicles[0].getVehicleNumber();
            label_brand.Text = vehicles[0].getBrand();
            label_dailyRental.Text = vehicles[0].getDailyRental();
            label_monthlyRental.Text = vehicles[0].getMonthlyRental();
            label_weeklyRental.Text = vehicles[0].getWeeklyRental();

        }

        private void pb_btnNext_Click(object sender, EventArgs e)
        {
            vehicleIndex++;

            try
            {
                label_VehicleNumber.Text = vehicles[vehicleIndex].getVehicleNumber();
                label_brand.Text = vehicles[vehicleIndex].getBrand();
                label_dailyRental.Text = vehicles[vehicleIndex].getDailyRental();
                label_monthlyRental.Text = vehicles[vehicleIndex].getMonthlyRental();
                label_weeklyRental.Text = vehicles[vehicleIndex].getWeeklyRental();
            }catch(Exception ex)
            {
                vehicleIndex--;
            }
            
        }

        private void pb_btnPrevious_Click(object sender, EventArgs e)
        {
            vehicleIndex--;
            
            try
            {
                
                label_VehicleNumber.Text = vehicles[vehicleIndex].getVehicleNumber();
                label_brand.Text = vehicles[vehicleIndex].getBrand();
                label_dailyRental.Text = vehicles[vehicleIndex].getDailyRental();
                label_monthlyRental.Text = vehicles[vehicleIndex].getMonthlyRental();
                label_weeklyRental.Text = vehicles[vehicleIndex].getWeeklyRental();
            }catch(Exception ex)
            {
                vehicleIndex++;
            }
            
        }
    }
}

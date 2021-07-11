using System;
using ShineWay.DataBase;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShineWay.Classes;
using System.Collections.Generic;
using ShineWay.Messages;

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


        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            String searchKeyValue = txt_search.Text;
            String query = "SELECT `Vehicle_num`, `Brand`,`Daily_price`, `Weekly_price`, `Monthly_price`, `Wedding_price`  FROM `vehicle` WHERE `Brand` LIKE '%" + searchKeyValue + "%' OR `Model` LIKE '%" + searchKeyValue + "%' OR `Daily_price` LIKE '%" + searchKeyValue + "%' OR `Type` LIKE '%" + searchKeyValue + "%' OR `Weekly_price` LIKE '%" + searchKeyValue + "%' OR `Monthly_price` LIKE '%" + searchKeyValue + "%' ";
            vehicles.Clear();

            try
            {
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
            catch (Exception ex)
            {
                
            }
            

        }


        private void btn_next_MouseHover(object sender, EventArgs e)
        {
            btn_next.Image = ShineWay.Properties.Resources.nextHover;
        }

        private void btn_next_MouseLeave(object sender, EventArgs e)
        {
            btn_next.Image = ShineWay.Properties.Resources.next;
        }


        private void btn_next_Click(object sender, EventArgs e)
        {
            vehicleIndex++;

            try
            {
                label_VehicleNumber.Text = vehicles[vehicleIndex].getVehicleNumber();
                label_brand.Text = vehicles[vehicleIndex].getBrand();
                label_dailyRental.Text = vehicles[vehicleIndex].getDailyRental();
                label_monthlyRental.Text = vehicles[vehicleIndex].getMonthlyRental();
                label_weeklyRental.Text = vehicles[vehicleIndex].getWeeklyRental();
            }
            catch (Exception ex)
            {
                vehicleIndex--;
                CustomMessage message = new CustomMessage("No more results. Go Back!", "Error", ShineWay.Properties.Resources.EmptyResults, DialogResult.OK);
                message.convertToOkButton();
                message.ShowDialog();
            }
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            vehicleIndex--;

            try
            {

                label_VehicleNumber.Text = vehicles[vehicleIndex].getVehicleNumber();
                label_brand.Text = vehicles[vehicleIndex].getBrand();
                label_dailyRental.Text = vehicles[vehicleIndex].getDailyRental();
                label_monthlyRental.Text = vehicles[vehicleIndex].getMonthlyRental();
                label_weeklyRental.Text = vehicles[vehicleIndex].getWeeklyRental();
            }
            catch (Exception ex)
            {
                vehicleIndex++;
                CustomMessage message = new CustomMessage("No more results Go Next!", "Error", ShineWay.Properties.Resources.EmptyResults, DialogResult.OK);
                message.convertToOkButton();
                message.ShowDialog();
            }
        }

        private void btn_previous_MouseHover(object sender, EventArgs e)
        {
            btn_previous.Image = ShineWay.Properties.Resources.previousHover;
        }

        private void btn_previous_MouseLeave(object sender, EventArgs e)
        {
            btn_previous.Image = ShineWay.Properties.Resources.previous;
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                if (txt_search.Text.Equals(""))
                {
                    CustomMessage message = new CustomMessage("Enter a keyword to search!", "Error", ShineWay.Properties.Resources.information, DialogResult.OK);
                    message.convertToOkButton();
                    message.ShowDialog();
                }
                else
                {
                    String searchKeyValue = txt_search.Text;
                    String query = "SELECT `Vehicle_num`, `Brand`,`Daily_price`, `Weekly_price`, `Monthly_price`, `Wedding_price`  FROM `vehicle` WHERE `Brand` LIKE '%" + searchKeyValue + "%' OR `Model` LIKE '%" + searchKeyValue + "%' OR `Daily_price` LIKE '%" + searchKeyValue + "%' OR `Type` LIKE '%" + searchKeyValue + "%' OR `Weekly_price` LIKE '%" + searchKeyValue + "%' OR `Monthly_price` LIKE '%" + searchKeyValue + "%' ";
                    vehicles.Clear();

                    try
                    {
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
                        e.SuppressKeyPress = true; //to remove the 'ding' sound
                    }
                    catch (Exception ex)
                    {
                        CustomMessage message = new CustomMessage("No search results found!", "Error", ShineWay.Properties.Resources.EmptyResults, DialogResult.OK);
                        message.convertToOkButton();
                        message.ShowDialog();
                    }
                }
            }
        }
    }
}

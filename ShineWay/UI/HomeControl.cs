using System;
using ShineWay.DataBase;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ShineWay.Classes;
using System.Collections.Generic;
using ShineWay.Messages;
using System.Drawing;

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
            String query = "";
            if (checkBox_ignoreOngoing.Checked)
            {
                query = "SELECT vehicle.Vehicle_num, vehicle.Brand, vehicle.Daily_price, vehicle.Weekly_price, vehicle.Monthly_price, payment.End_date FROM vehicle INNER JOIN payment ON NOT payment.Status = \"Ongoing\" AND payment.Vehicle_num = vehicle.Vehicle_num AND (vehicle.Brand LIKE '%" + searchKeyValue + "%' OR vehicle.Model LIKE '%" + searchKeyValue + "%' OR vehicle.Daily_price LIKE '%" + searchKeyValue + "%' OR vehicle.Type LIKE '%" + searchKeyValue + "%' OR vehicle.Weekly_price LIKE '%" + searchKeyValue + "%' OR vehicle.Monthly_price LIKE '%" + searchKeyValue + "%' ); ";
            }
            else
            {
                query = "SELECT `Vehicle_num`, `Brand`,`Daily_price`, `Weekly_price`, `Monthly_price`  FROM `vehicle` WHERE `Brand` LIKE '%" + searchKeyValue + "%' OR `Model` LIKE '%" + searchKeyValue + "%' OR `Daily_price` LIKE '%" + searchKeyValue + "%' OR `Type` LIKE '%" + searchKeyValue + "%' OR `Weekly_price` LIKE '%" + searchKeyValue + "%' OR `Monthly_price` LIKE '%" + searchKeyValue + "%' ";

            }
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

                try
                {
                    pb_vehicle.Image = Image.FromFile(@"C:\ShineWay\img\" + vehicles[vehicleIndex].getVehicleNumber() + "-overall.jpg");
                }
                catch (Exception ex)
                {
                    pb_vehicle.Image = ShineWay.Properties.Resources.noImage;
                }

                if (txt_search.Text.Equals(""))
                {
                    clearText();
                    vehicles.Clear();
                }
            }
            catch (Exception ex)
            {
                clearText();
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
                try
                {
                    pb_vehicle.Image = Image.FromFile(@"C:\ShineWay\img\" + vehicles[vehicleIndex].getVehicleNumber() + "-overall.jpg");
                }
                catch (Exception ex)
                {
                    pb_vehicle.Image = ShineWay.Properties.Resources.noImage;
                    //image not found
                }
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
                try
                {
                    pb_vehicle.Image = Image.FromFile(@"C:\ShineWay\img\"+ vehicles[vehicleIndex].getVehicleNumber() + "-overall.jpg");
                }
                catch (Exception ex)
                {
                    pb_vehicle.Image = ShineWay.Properties.Resources.noImage;
                    //image not found
                }

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
                    clearText();
                }
                else
                {
                    String searchKeyValue = txt_search.Text;
                    String query = "";
                    if (checkBox_ignoreOngoing.Checked)
                    {
                        query = "SELECT vehicle.Vehicle_num, vehicle.Brand, vehicle.Daily_price, vehicle.Weekly_price, vehicle.Monthly_price, payment.End_date FROM vehicle INNER JOIN payment ON NOT payment.Status = \"Ongoing\" AND payment.Vehicle_num = vehicle.Vehicle_num AND (vehicle.Brand LIKE '%" + searchKeyValue + "%' OR vehicle.Model LIKE '%" + searchKeyValue + "%' OR vehicle.Daily_price LIKE '%" + searchKeyValue + "%' OR vehicle.Type LIKE '%" + searchKeyValue + "%' OR vehicle.Weekly_price LIKE '%" + searchKeyValue + "%' OR vehicle.Monthly_price LIKE '%" + searchKeyValue + "%' ); ";
                    }
                    else
                    {
                        query = "SELECT `Vehicle_num`, `Brand`,`Daily_price`, `Weekly_price`, `Monthly_price`  FROM `vehicle` WHERE `Brand` LIKE '%" + searchKeyValue + "%' OR `Model` LIKE '%" + searchKeyValue + "%' OR `Daily_price` LIKE '%" + searchKeyValue + "%' OR `Type` LIKE '%" + searchKeyValue + "%' OR `Weekly_price` LIKE '%" + searchKeyValue + "%' OR `Monthly_price` LIKE '%" + searchKeyValue + "%' ";

                    }
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
                        vehicles.Clear();
                        clearText();
                    }
                }
            }
        }



        private void clearText()
        {
            label_VehicleNumber.Text = "";
            label_brand.Text = "";
            label_dailyRental.Text = "";
            label_monthlyRental.Text = "";
            label_weeklyRental.Text = "";
            pb_vehicle.Image =null;
        }

        private void btn_clipBoard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(label_VehicleNumber.Text);
                Welcome message = new Welcome("Copied to clipboard!");
                message.setWidth(370);
                message.setIcon(ShineWay.Properties.Resources.tick);
                message.setInterval(1000);
                message.setImageBounds(120, 120, 12, 12);
                message.hideCloseButton();
                message.Show();
            
            }catch(Exception exe)
            {
                
                Welcome message = new Welcome("Nothing to Copy!");
                message.setWidth(320);
                message.setIcon(ShineWay.Properties.Resources.information);
                message.setInterval(1000);
                message.setImageBounds(120, 120, 12, 12);
                message.hideCloseButton();
                message.Show();
            }
           
        }

        private void HomeControl_Load(object sender, EventArgs e)
        {
            try
            {
                String queryForCarCount = "SELECT COUNT(vehicle.Vehicle_num) FROM vehicle WHERE Vehicle.Vehicle_num NOT IN(SELECT payment.Vehicle_num FROM payment WHERE payment.Status = \"Ongoing\") AND vehicle.Type = \"Car\"; ";
                MySqlDataReader reader = DbConnection.Read(queryForCarCount);
                reader.Read();
                label_carCount.Text = "AVAILABLE : " + reader[0].ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }


            try
            {
                String queryForVanCount = "SELECT COUNT(vehicle.Vehicle_num) FROM vehicle WHERE Vehicle.Vehicle_num NOT IN(SELECT payment.Vehicle_num FROM payment WHERE payment.Status = \"Ongoing\") AND vehicle.Type = \"Van\"; ";
                MySqlDataReader reader = DbConnection.Read(queryForVanCount);
                reader.Read();
                label_vanCount.Text = "AVAILABLE : " + reader[0].ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }


            try
            {
                String queryForBikeCount = "SELECT COUNT(vehicle.Vehicle_num) FROM vehicle WHERE Vehicle.Vehicle_num NOT IN(SELECT payment.Vehicle_num FROM payment WHERE payment.Status = \"Ongoing\") AND vehicle.Type = \"Bike\"; ";
                MySqlDataReader reader = DbConnection.Read(queryForBikeCount);
                reader.Read();
                label_bikeCount.Text = "AVAILABLE : " + reader[0].ToString();
                
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}

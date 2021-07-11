using System;

namespace ShineWay.Classes
{
    class Vehicle
    {
        private String vehicleNumber;
        private String brand;
        private String dailyRental;
        private String weeklyRental;
        private String monthlyRental;


        Vehicle(String vehicleNumber, String brand, String dailyRental, String weeklyRental, String monthlyRental)
        {
            this.vehicleNumber = vehicleNumber;
            this.brand = brand;
            this.dailyRental = dailyRental;
            this.weeklyRental = weeklyRental;
            this.monthlyRental = monthlyRental;
        }

        public String getVehicleNumber()
        {
            return vehicleNumber;
        }

        public String getBrand()
        {
            return brand;
        }

        public String getDailyRental()
        {
            return dailyRental;
        }

        public String getWeeklyRental()
        {
            return weeklyRental;
        }

        public String getMonthlyRental()
        {
            return monthlyRental;
        }
    }
}

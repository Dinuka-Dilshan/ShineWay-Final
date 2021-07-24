using System;

namespace ShineWay.Classes
{
    class Vehicle
    {

       public String vehNumber { get; set; }
        public string Brand { get; set; }
        public String model { get; set; }
        public string type { get; set; }
        public String engineNumber { get; set; }
        public String chassisNumber { get; set; }
        public string ownerNic { get; set; }
        public String registerDate { get; set; }
        public string ownerCondition { get; set; }
        public String dailyPrice { get; set; }
        public String weeklyPrice { get; set; }
        public String monthlyPrice { get; set; }
        public String extraKMPrice { get; set; }
        public String dailyKm { get; set; }
        public String weeklyKm { get; set; }
        public String monthlyKm { get; set; }
        public String ownerPayment { get; set; }
        public String startingOdometer { get; set; }
        public String overallView { get; set; }
        public String insideView { get; set; }

         private String vehicleNumber;
          private String brand;
          private String dailyRental;
          private String weeklyRental;
          private String monthlyRental;


          public  Vehicle(String vehicleNumber, String brand, String dailyRental, String weeklyRental, String monthlyRental)
          {
              this.vehicleNumber = vehicleNumber;
              this.brand = brand;
              this.dailyRental = dailyRental;
              this.weeklyRental = weeklyRental;
              this.monthlyRental = monthlyRental;

            
          }
        public Vehicle()
        {

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

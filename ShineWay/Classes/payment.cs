using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineWay.Classes
{
    class payment
    {
        public String Booking_ID { get; set; }
        public String Vehicle_Number { get; set; }
        public string Customer_NIC { get; set; }
        public string Status { get; set; }
        public string End_Date { get; set; }
        public string Ending_Odometer { get; set; }
        public string Amount { get; set; }
        public string Discount { get; set; }
        public string Sub_Amount { get; set; }
    }
}

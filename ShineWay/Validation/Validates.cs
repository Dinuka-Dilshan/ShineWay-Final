using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ShineWay.Validation
{
    class Validates
    {
        public static string validateName = "^[A-Za-z]{3,}$";
        public static string validateNEWCustomerNIC = "^[0-9]{4}[01235678]{1}[0-9]{7}$";
        public static string validateOLDCustomerNIC = "^[0-9]{3}[01235678]{1}[0-9]{5}[VX]{0,1}$";
        public static string validateMobileNumber = "^[0]{1}[1-9]{9}$";
        public static string validateEmail = "^[a-zA-Z1-9_-+]{1,}[@][a-zA-Z][.][a-zA-Z]{2,3}([a-zA-Z]{2,3}){0,1}$";

        public static string validateBookingID = "^[0-9]{1,}$";
        public static string validateVehiclenumber1 = "^[A-Z]{2,3}[-][0-9]{4}$";
        public static string validateVehiclenumber2 = "^[1-9]{2,3}[-][0-9]{4}$";
        public static string validateLicensenumber = "^[A-Z]{1}[1-9]{7,9}$";
        public static string validateOdometer = "^[0-9]{5,6}$";
        public static string validatePackagetype = "^(Daily Basis|Monthly Basis|Weekly Basis)$";


        public static bool ValidBookingID(string bookingID)
        {
            return Regex.IsMatch(bookingID, validateBookingID);
        }

        public static bool ValidVehiclenumber1(string vehiclenumber)
        {
            return Regex.IsMatch(vehiclenumber, validateVehiclenumber1);
        }

        public static bool ValidVehiclenumber2(string vehiclenumber)
        {
            return Regex.IsMatch(vehiclenumber, validateVehiclenumber2);
        }

        public static bool ValidPackagetype(string packagetype)
        {
            return Regex.IsMatch(packagetype, validatePackagetype);
        }

        public static bool ValidCustomerNewNIC(string customernic)
        {
            return Regex.IsMatch(customernic, validateNEWCustomerNIC);
        }

        public static bool ValidCustomerOldNIC(string customernic)
        {
            return Regex.IsMatch(customernic, validateOLDCustomerNIC);
        }

    }
}

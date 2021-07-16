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
        public static string validateName = "^[A-Za-z ]{3,}$";
        public static string validateNEWCustomerNIC = "^[0-9]{4}[01235678]{1}[0-9]{7}$";

        public static string validateMobileNumber = "^[0]{1}[0-9]{9}$";
        public static string validateOLDCustomerNIC = "^[0-9]{2}[01235678]{1}[0-9]{6}[VX]{1}$";

        // gender vise validate NIC
        public static string validatemaleNEWCustomerNIC = "^[0-9]{4}[0123]{1}[0-9]{7}$";
        public static string validatemaleOLDCustomerNIC = "^[0-9]{2}[0123]{1}[0-9]{6}[VX]{1}$";
       // public static string validatefemaleNEWCustomerNIC = "^[0-9]{4}[5678]{1}[0-9]{7}$";
       // public static string validatefemaleOLDCustomerNIC = "^[0-9]{2}[5678]{1}[0-9]{6}[VX]{1}$";

        public static string validateEmail = "^[a-zA-Z0-9.-_]{1,30}[@]{1}[a-z.]{1,10}[.]{1}[a-z]{2,3}$";


        public static string validateBookingID = "^[0-9]{1,}$";
        public static string validateVehiclenumber1 = "^[A-Z]{2,3}[-][0-9]{4}$";
        public static string validateVehiclenumber2 = "^[0-9]{2,3}[-][0-9]{4}$";
        public static string validateLicensenumber = "^[A-Z]{1}[1-9]{7,8}[A-Z]{0,1}$";
        public static string validateOdometer = "^[0-9]{5,6}$";
        public static string validatePackagetype = "^(Daily Basis|Monthly Basis|Weekly Basis)$";



        public static string validateEndOdometer = "^[0-9]{5,6}$";
        public static string validateStatus = "^(Ongoing|Canceled|Completed)$";
        public static string validateDiscount1 = "^[0-9]{0,6}[.][0-9]{2}$";
        public static string validateDiscount2 = "^[0-9]{2}[%]$";


        public static string validateAmount = "^[0-9]{0,10}[.]{1}[0-9]{2}$";
        public static string validateDescription = "^[A-Za-z0-9&-_= +]{0,160}$";


        public static bool ValidEmail(string email)
        {
            return Regex.IsMatch(email, validateEmail);
        }

        public static bool ValidName(string cusname)
        {
            return Regex.IsMatch(cusname, validateName);
        }

        public static bool ValidMobile(string mobilenumber)
        {
            return Regex.IsMatch(mobilenumber, validateMobileNumber);
        }

        public static bool ValidTelephone(string number)
        {
            return Regex.IsMatch(number, validateMobileNumber);
        }

        public static bool ValidownerEmail(string email)
        {
            return Regex.IsMatch(email, validateEmail);
        }

        public static bool ValidBookingID(string bookingID)
        {
            return Regex.IsMatch(bookingID, validateBookingID);
        }

        public static bool ValidVehiclenumber1(string vehiclenumber1)
        {
            return Regex.IsMatch(vehiclenumber1, validateVehiclenumber1);
        }

        public static bool ValidVehiclenumber2(string vehiclenumber2)
        {
            return Regex.IsMatch(vehiclenumber2, validateVehiclenumber2);
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

        /////////////////////////////////////////////////////////////////////

        public static bool ValidCustomermaleNewNIC(string customernicm1)
        {
            return Regex.IsMatch(customernicm1, validatemaleNEWCustomerNIC);
        }

        public static bool ValidCustomermaleOldNIC(string customernicm2)
        {
            return Regex.IsMatch(customernicm2, validatemaleOLDCustomerNIC);
        }
        /*
        public static bool ValidCustomerfemaleNewNIC(string customernicf1)
        {
            return Regex.IsMatch(customernicf1, validatefemaleNEWCustomerNIC);
        }

        public static bool ValidCustomerfemaleOldNIC(string customernicf2)
        {
            return Regex.IsMatch(customernicf2, validatefemaleOLDCustomerNIC);
        }
        */

        /////////////////////////////////////////////////////////////////////

        public static bool ValidEndOdoMeter(string endODO)
        {
            return Regex.IsMatch(endODO, validateEndOdometer);
        }

        public static bool ValidLicensenumber(string licensenumber)
        {
            return Regex.IsMatch(licensenumber, validateLicensenumber);
        }

        public static bool ValidOdometer(string odometer)
        {
            return Regex.IsMatch(odometer, validateOdometer);
        }

        public static bool ValidAmount(string amount)
        {
            return Regex.IsMatch(amount, validateAmount);
        }
        
        public static bool ValidateDescription(string discription)
        {
            return Regex.IsMatch(discription, validateDescription);
        }

        public static bool ValidateStatus(string status)
        {
            return Regex.IsMatch(status, validateStatus);

        }
        public static bool validMobileNumber(string mobileNo)
        {
            return Regex.IsMatch(mobileNo, validateMobileNumber);
        }

        public static bool ValidDiscount1(string discount1)
        {
            return Regex.IsMatch(discount1, validateDiscount1);
        }

        public static bool ValidDiscount2(string discount2)
        {
            return Regex.IsMatch(discount2, validateDiscount2);
        }



    }
}

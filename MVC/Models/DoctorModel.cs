using System.Globalization;

namespace MVC.Models
{
    public class DoctorModel
    {
        public static string CheckTemp(string temp)
        {
            float decimalTemp = float.Parse(temp, CultureInfo.InvariantCulture);

            if (decimalTemp >= 38)
                return "You have a fever";
            else if (decimalTemp <= 35)
                return "You have hypothermia";
            else
                return "You are healthy!";
        }
    }
}

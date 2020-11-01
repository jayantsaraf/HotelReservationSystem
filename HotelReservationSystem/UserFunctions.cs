using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class UserFunctions
    {
        public string[] EnterDate()
        {
            string[] dates = new string[] { };
            try
            {
                Console.WriteLine("Enter dates of booking (enter dates in format DD/MM/YYYY and separated by ,");
                dates = Console.ReadLine().Split(',');
            }
            catch
            {
                if (dates == null)
                {
                    throw new System.ArgumentNullException("Invalid Date entered");
                }
            }
            return dates;
        }
    }
}

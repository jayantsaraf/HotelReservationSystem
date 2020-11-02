using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace HotelReservationSystem
{
    public class HotelFunctions
    {
        /// <summary>
        /// Adding 3 hotels of Miami
        /// </summary>
        List<Hotel> hotels = new List<Hotel>();
        public List<Hotel> AddHotel()
        {
            hotels.Add(new Hotel("Lakewood",3, 110, 90));
            hotels.Add(new Hotel("Bridgewood",4, 150, 50));
            hotels.Add(new Hotel("Ridgewood",5, 220, 150));
            return hotels;
        }
        /// <summary>
        /// UC2 - Fucntion to find cheapest hotel 
        /// </summary>
        /// <returns></returns>
        public Hotel FindCheapestHotelWithoutWeekend()
        {
            hotels.OrderBy(x => x.mRegularWeekdayRate);
            return hotels[0];
        }
        /// <summary>
        /// Fucntion to find cheapest hotel including weekend and weekday rate
        /// </summary>
        /// <returns></returns>
        public List<Hotel> FindCheapestHotel(DateTime[] dates)
        {
            double noOfWeekend = 0;
            double cheapestPrice = 0;
            double noOfWeekday = 0;
            List<Hotel> cheapestHotels = new List<Hotel>();
            foreach (var date in dates)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    noOfWeekend++;
            }
            TimeSpan timeSpan = dates[1].Subtract(dates[0]); //// Total days between start and end date
            noOfWeekday = timeSpan.TotalDays - noOfWeekend; //// TotalDays - inbuilt function
            foreach(var hotel in hotels)
            {
                double priceDuringStay = hotel.mRegularWeekdayRate * noOfWeekday + hotel.mRegularWeekendRate * noOfWeekend;
                if (priceDuringStay >= cheapestPrice)
                {
                    cheapestPrice = priceDuringStay;
                    cheapestHotels.Add(hotel);
                }
                    
            }
            foreach(var cheapestHotel in cheapestHotels)
                Console.WriteLine("Cheapest Hotel : Name : {0}, Price = {1}", cheapestHotel.mNameOfHotel, cheapestPrice);

            return cheapestHotels;
        }
    }
}

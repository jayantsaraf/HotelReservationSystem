using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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
            hotels.Add(new Hotel("Lakewood", 110, 90));
            hotels.Add(new Hotel("Bridgewood", 160, 50));
            hotels.Add(new Hotel("Ridgewood", 220, 150));
            return hotels;
        }    
        /// <summary>
        /// Fucntion to find cheapest hotel
        /// </summary>
        /// <returns></returns>
        public Hotel FindCheapestHotel()
        {
            hotels.OrderBy(x => x.mRegularWeekdayRate);
            return hotels[0];
        }
    }
}

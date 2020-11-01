using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System");
            List<Hotel> hotels = new List<Hotel>();
            hotels.Add(new Hotel("Lakewood", 110));
            hotels.Add(new Hotel("Bridgewood", 160));
            hotels.Add(new Hotel("Ridgewood", 220));
        }
    }
}

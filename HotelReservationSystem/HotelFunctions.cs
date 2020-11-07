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
        public List<Hotel> hotels = new List<Hotel>();
        public List<Hotel> AddHotel()
        {
            hotels.Add(new Hotel("Lakewood"));
            hotels.Add(new Hotel("Bridgewood"));
            hotels.Add(new Hotel("Ridgewood"));
            return hotels;
        }
        public List<Hotel> AddHotel(CustomerType customerType)
        {
            if (customerType.Equals(CustomerType.reward))
            {
                hotels.Add(new Hotel("Lakewood", CustomerType.reward));
                hotels.Add(new Hotel("Bridgewood", CustomerType.reward));
                hotels.Add(new Hotel("Ridgewood", CustomerType.reward));
            }
            else
                AddHotel();
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
        /// Calculates price of all hotels during given date range
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        public Dictionary<Hotel, double> CalculatePriceOfStay(DateTime[] dates)
        {
            Dictionary<Hotel, double> listOfHotelAndPrice = new Dictionary<Hotel, double>();

            double noOfWeekend = 0;
            double noOfWeekday = 0;
            for (DateTime i = dates[0]; i < dates[1]; i = i.AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                    noOfWeekend++;
            }
            TimeSpan timeSpan = dates[1].Subtract(dates[0]); //// Total days between start and end date
            noOfWeekday = timeSpan.TotalDays - noOfWeekend + 1; //// TotalDays - inbuilt function
            foreach (var hotel in hotels)
            {
                double priceDuringStay = hotel.mRegularWeekdayRate * noOfWeekday + hotel.mRegularWeekendRate * noOfWeekend;
                listOfHotelAndPrice.Add(hotel, priceDuringStay);
            }

            return listOfHotelAndPrice;
        }
        /// <summary>
        /// Fucntion to find cheapest hotel including weekend and weekday rate
        /// </summary>
        /// <returns></returns>
        public Hotel FindCheapestHotel(DateTime[] dates)
        {
            Dictionary<Hotel, double> sortedListOfHotelAndPriceDuringGivenDate = new Dictionary<Hotel, double>();
            if (dates == null)
                throw new HotelManagementCustomException(HotelManagementCustomException.ExceptionType.NULL_MESSAGE, "Dates entered cannot be null");
            else if (dates.Length == 0)
                throw new HotelManagementCustomException(HotelManagementCustomException.ExceptionType.EMPTY_MESSAGE, "Date range cannot be empty");
            else
            {
                Dictionary<Hotel, double> listOfHotelAndPriceDuringGivenDate = CalculatePriceOfStay(dates);
                sortedListOfHotelAndPriceDuringGivenDate = (Dictionary<Hotel, double>)listOfHotelAndPriceDuringGivenDate.OrderBy(x => x.Value).ThenByDescending(x => x.Key.mrating);//// Sorts the cheapest hotels as per the rating in descending order
                foreach (var hotel in sortedListOfHotelAndPriceDuringGivenDate)
                    Console.WriteLine("Cheapest Hotel : Name : {0}, Price = {1}", hotel.Key, hotel.Value);
            }
            return sortedListOfHotelAndPriceDuringGivenDate.ElementAt(0).Key;
        }
        /// <summary>
        /// Finds the hotel with best rating
        /// </summary>
        /// <param name="dates"></param>
        public Hotel FindBestHotel(DateTime[] dates)
        {
            Dictionary<Hotel, double> listOfHotelAndPriceDuringGivenDate = CalculatePriceOfStay(dates);
            ////sorts the hotels as per rating with first hotel being with best rating
            var sortedListOfHotelAndPriceDuringGivenDate = listOfHotelAndPriceDuringGivenDate.OrderByDescending(x => x.Key.mrating);
            return sortedListOfHotelAndPriceDuringGivenDate.ElementAt(0).Key;
        }



    }
}

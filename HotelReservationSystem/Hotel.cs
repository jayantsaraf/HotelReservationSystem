using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Hotel
    {
        public string mNameOfHotel;
        public int mRegularWeekdayRate;
        public int mRegularWeekendRate;
        public int mrating;

        /// <summary>
        /// Constructor to assign default values
        /// </summary>
        public Hotel()
        {
            this.mNameOfHotel = null;
            this.mRegularWeekdayRate = 0;
            this.mRegularWeekendRate = 0;
            this.mrating = 0;
        }
        /// <summary>
        /// Assign Default Values to RegularWeekdayRate,RegularWeekendRate,Rating
        /// </summary>
        /// <param name="hotelName"></param>
        public Hotel(string hotelName)
        {
            this.mNameOfHotel = hotelName;
        }
        /// <summary>
        /// Assign Default Values to rating
        /// </summary>
        /// <param name="hotelName"></param>
        public Hotel(string hotelName, int weekdayRate, int weekendRate)
        {
            this.mNameOfHotel = hotelName;
            this.mRegularWeekdayRate = weekdayRate;
            this.mRegularWeekendRate = weekendRate;
        }

        /// <summary>
        /// Constructor to assign values given by user
        /// </summary>
        public Hotel(string hotelName, int rating, int regularWeekdayRate,int regularWeekendRate)
        {
            this.mNameOfHotel = hotelName;
            this.mrating = rating;
            this.mRegularWeekdayRate = regularWeekdayRate;
            this.mRegularWeekendRate = regularWeekendRate;
        }
    }
}

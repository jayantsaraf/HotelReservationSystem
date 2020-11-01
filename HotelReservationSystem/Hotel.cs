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
        /// <summary>
        /// Constructor to assign default values
        /// </summary>
        public Hotel()
        {
            this.mNameOfHotel = null;
            this.mRegularWeekdayRate = 0;
            this.mRegularWeekendRate = 0;
        }
        /// <summary>
        /// Constructor to assign values given by user
        /// </summary>
        public Hotel(string name, int regularWeekdayRate,int regularWeekendRate)
        {
            this.mNameOfHotel = name;
            this.mRegularWeekdayRate = regularWeekdayRate;
            this.mRegularWeekendRate = regularWeekendRate;
        }
    }
}

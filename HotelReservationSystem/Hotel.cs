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
        /// Assign Default Values to RegularWeekdayRate,RegularWeekendRate,Rating assuming customer is of type regular
        /// </summary>
        /// <param name="hotelName"></param>
        public Hotel(string hotelName)
        {
            this.mNameOfHotel = hotelName;
            if (this.mNameOfHotel == "Lakewood")
            {
                this.mRegularWeekdayRate = 110;
                this.mRegularWeekendRate = 90;
                this.mrating = 3;
            }
            if (this.mNameOfHotel == "Bridgewood")
            {
                this.mRegularWeekdayRate = 160;
                this.mRegularWeekendRate = 60;
                this.mrating = 4;
            }
            if (this.mNameOfHotel == "Ridgewood")
            {
                this.mRegularWeekdayRate = 220;
                this.mRegularWeekendRate = 150;
                this.mrating = 5;
            }
        }
        /// <summary>
        /// Assigns values to weekend and weekday rates to hotels as per cutomer type: regular or reward
        /// </summary>
        /// <param name="hotelName"></param>
        /// <param name="customerType"></param>
        public Hotel(string hotelName, CustomerType customerType)
        {
            this.mNameOfHotel = hotelName;
            if (customerType.Equals(CustomerType.regular))
            {
                if (this.mNameOfHotel == "Lakewood")
                {
                    this.mRegularWeekdayRate = 110;
                    this.mRegularWeekendRate = 90;
                    this.mrating = 3;
                }
                if (this.mNameOfHotel == "Bridgewood")
                {
                    this.mRegularWeekdayRate = 160;
                    this.mRegularWeekendRate = 60;
                    this.mrating = 4;
                }
                if (this.mNameOfHotel == "Ridgewood")
                {
                    this.mRegularWeekdayRate = 220;
                    this.mRegularWeekendRate = 150;
                    this.mrating = 5;
                }
            }
            else
            {
                if (this.mNameOfHotel == "Lakewood")
                {
                    this.mRegularWeekdayRate = 80;
                    this.mRegularWeekendRate = 80;
                    this.mrating = 3;
                }
                if (this.mNameOfHotel == "Bridgewood")
                {
                    this.mRegularWeekdayRate = 110;
                    this.mRegularWeekendRate = 50;
                    this.mrating = 4;
                }
                if (this.mNameOfHotel == "Ridgewood")
                {
                    this.mRegularWeekdayRate = 100;
                    this.mRegularWeekendRate = 40;
                    this.mrating = 5;
                }

            }

        }
    }
}

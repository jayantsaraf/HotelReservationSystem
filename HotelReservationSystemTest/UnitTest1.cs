using NUnit.Framework;
using HotelReservationSystem;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HotelReservationSystemTest
{
    public class Tests
    {
        /// <summary>
        /// Finding cheapest hotel
        /// </summary>
        [Test]
        public void ShouldReturnCheapestHotel()
        {
            //// Creating object of place
            HotelFunctions miami = new HotelFunctions();
            //// Adding hotel and finding cheapest hotel
            miami.AddHotel();
            DateTime[] dates = new DateTime[] { Convert.ToDateTime("1/1/2010"), Convert.ToDateTime("20/1/2010") };
            Hotel actual = miami.FindCheapestHotelWithoutWeekend();
            ////Comparing the returned values
            Hotel expected = new Hotel("Lakewood", 110, 90);
            Assert.AreEqual(actual.mRegularWeekdayRate, expected.mRegularWeekdayRate);
        }
        /// <summary>
        /// Finding cheapest hotel including weekend and weekday
        /// </summary>
        [Test]
        public void ShouldReturnCheapestHotelIncludingWeekend()
        {
            //// Creating object of place
            HotelFunctions miami = new HotelFunctions();
            //// Adding hotel and finding cheapest hotel
            miami.AddHotel();
            DateTime[] dates = new DateTime[] {Convert.ToDateTime( "1/1/2010"), Convert.ToDateTime("20/1/2010") };
            List<Hotel> actual = miami.FindCheapestHotel(dates);
            ////Comparing the returned values
            List<Hotel> expected = new List<Hotel>() { new Hotel("Lakewood"), new Hotel("Bridgewood") };
            Assert.AreEqual(actual[0].mNameOfHotel, expected[0].mNameOfHotel);
        }
        /// <summary>
        /// Return the rating of Lakewood - 3
        /// </summary>
        [Test]
        public void ShouldReturnHotelRatingWhenPassed()
        {
            //// Creating object of place
            HotelFunctions miami = new HotelFunctions();
            //// Adding hotel and finding cheapest hotel
            List<Hotel> hotels =  miami.AddHotel();
            ////Checking the rating
            int actual = hotels[0].mrating;
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }
        
    }
}
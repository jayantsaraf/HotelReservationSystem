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
            Hotel expected = new Hotel("Lakewood");
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
            DateTime[] dates = new DateTime[] {Convert.ToDateTime( "11/09/2020"), Convert.ToDateTime("12/09/2020") };
            Hotel actual = miami.FindCheapestHotel(dates);
            ////Comparing the returned values
            List<Hotel> expected = new List<Hotel>() { new Hotel("Lakewood"), new Hotel("Bridgewood") };
            Assert.AreEqual(actual.mNameOfHotel, expected[0].mNameOfHotel);
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
        /// <summary>
        /// Finding cheapest hotel with best rating
        /// </summary>
        [Test]
        public void ShouldReturnCheapestHotelWithBestRating()
        {
            //// Creating object of place
            HotelFunctions miami = new HotelFunctions();
            //// Adding hotel and finding cheapest hotel
            miami.AddHotel();
            DateTime[] dates = new DateTime[] { Convert.ToDateTime("11/09/2020"), Convert.ToDateTime("12/09/2020") };
            var actual = miami.FindCheapestHotel(dates);
            ////Comparing the returned values
            Hotel expected = new Hotel("Bridgewood");
            Assert.AreEqual(actual.mNameOfHotel, expected.mNameOfHotel);
        }
        /// <summary>
        /// Finding hotel with best rating
        /// </summary>
        [Test]
        public void ShouldReturnHotelWithBestRating()
        {
            //// Creating object of place
            HotelFunctions miami = new HotelFunctions();
            //// Adding hotel and finding cheapest hotel
            miami.AddHotel();
            DateTime[] dates = new DateTime[] { Convert.ToDateTime("11/09/2020"), Convert.ToDateTime("12/09/2020") };
            var actual = miami.FindBestHotel(dates);
            ////Comparing the returned values
            Hotel expected = new Hotel("Ridgewood");
            Assert.AreEqual(actual.mNameOfHotel, expected.mNameOfHotel);
        }
        /// <summary>
        /// Test will return weekday rate of reward customer for hotel Lakewood
        /// </summary>
        [Test]
        public void ShouldReturnRewardCustomerRates()
        {
            ////Create hotel instance
            Hotel actual = new Hotel("Lakewood",CustomerType.reward);
            ////Creating expected hotel instance
            int expected = 80;
            ////Check
            Assert.AreEqual(expected, actual.mRegularWeekdayRate);
        }
    }
}
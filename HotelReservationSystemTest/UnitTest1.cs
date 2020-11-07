using NUnit.Framework;
using HotelReservationSystem;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;

namespace HotelReservationSystemTest
{
    public class Tests
    {

        CultureInfo cultureinfo = CultureInfo.InvariantCulture;
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
            DateTime[] dates = new DateTime[] { Convert.ToDateTime("11/09/2020"), Convert.ToDateTime("12/09/2020") };
            Hotel actual = miami.FindCheapestHotelWithoutWeekend();
            ////Comparing the returned values
            Hotel expected = new Hotel("Lakewood");
            Assert.AreEqual(actual.mRegularWeekdayRate, expected.mRegularWeekdayRate);
        }
        /// <summary>
        /// Return null exception
        /// </summary>
        [Test]
        public void ShouldReturnNullExceptuonWhenCallingCheapestHotelFunction()
        {
            try
            {
                //// Creating object of place
                HotelFunctions miami = new HotelFunctions();
                //// Adding hotel and finding cheapest hotel
                miami.AddHotel();
                DateTime[] dates = null;
                Hotel actual = miami.FindCheapestHotel(dates);
            }
            catch (HotelManagementCustomException e)
            {
                Assert.AreEqual("Dates entered cannot be null", e.Message);
            }
        }
        /// <summary>
        /// Return empty string error
        /// </summary>
        [Test]
        public void ShouldReturnExptyExceptuonWhenCallingCheapestHotelFunction()
        {
            try
            {
                //// Creating object of place
                HotelFunctions miami = new HotelFunctions();
                //// Adding hotel and finding cheapest hotel
                miami.AddHotel();
                DateTime[] dates = new DateTime[] { };
                Hotel actual = miami.FindCheapestHotel(dates);
            }
            catch (HotelManagementCustomException e)
            {
                Assert.AreEqual("Date range cannot be empty", e.Message);
            }
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
            DateTime[] dates = new DateTime[] {Convert.ToDateTime( "11/09/2020",cultureinfo), Convert.ToDateTime("12/09/2020",cultureinfo) };
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
            DateTime[] dates = new DateTime[] { Convert.ToDateTime("09/11/2020",cultureinfo), Convert.ToDateTime("09/12/2020",cultureinfo) };
            var actual = miami.FindCheapestHotel(dates);
            ////Comparing the returned values
            string expected = "Bridgewood";
            Assert.AreEqual(expected,actual.mNameOfHotel);
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
        /// <summary>
        /// Finding cheapest hotel with best rating for reward customer
        /// </summary>
        [Test]
        public void ShouldReturnCheapestHotelWithBestRatingForRewardCustomer()
        {
            //// Creating object of place
            HotelFunctions miami = new HotelFunctions();
            //// Adding hotel and finding cheapest hotel
            miami.AddHotel(CustomerType.reward);
            DateTime[] dates = new DateTime[] { Convert.ToDateTime("09/11/2020", cultureinfo), Convert.ToDateTime("09/12/2020", cultureinfo) };
            var actual = miami.FindCheapestHotel(dates);
            ////Comparing the returned values
            string expected = "Ridgewood";
            Assert.AreEqual(expected, actual.mNameOfHotel);
        }

    }
}
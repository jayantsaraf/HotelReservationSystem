using NUnit.Framework;
using HotelReservationSystem;

namespace HotelReservationSystemTest
{
    public class Tests
    {

        [Test]
        public void ShouldReturnCheapestHotel()
        {
            //// Creating object of place
            HotelFunctions miami = new HotelFunctions();
            //// Adding hotel and finding cheapest hotel
            miami.AddHotel();
            string[] dates = new string[]{ "10/01/2001", "20/01/2001"};
            Hotel actual = miami.FindCheapestHotel();
            ////Comparing the returned values
            Hotel expected = new Hotel("Lakewood", 110);
            Assert.AreEqual(actual.mRegularRate, expected.mRegularRate);
        }
    }
}
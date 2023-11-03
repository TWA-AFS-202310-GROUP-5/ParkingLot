using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLot;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_car_when_fetch_given_ticket()
        {
            var car = "car";

            var parkingLot = new Parking();
            var ticket = parkingLot.Park(car);
            var result = parkingLot.Fetch(ticket);

            Assert.Equal(car, result);
        }
    }
}

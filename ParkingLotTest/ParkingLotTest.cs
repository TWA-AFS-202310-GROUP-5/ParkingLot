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

        [Fact]
        public void should_return_right_when_park_given_car()
        {
            var parkingLot = new Parking();
            var ticket1 = parkingLot.Park("car1");
            var ticket2 = parkingLot.Park("car2");

            var car1 = parkingLot.Fetch(ticket1);
            var car2 = parkingLot.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_return_empty_when_fetch_given_wrong_ticket()
        {
            var parkingLot = new Parking();
            var ticket1 = parkingLot.Park("car1");
            var ticket2 = parkingLot.Park("car2");

            var car = parkingLot.Fetch("ticket do not exit.");

            Assert.Equal("",car);
        }

        [Fact]
        public void Should_return_empty_when_fetch_given_used_ticket()
        {
            var parkingLot = new Parking();
            var ticket = parkingLot.Park("car1");

            var car = parkingLot.Fetch(ticket);

            var result = parkingLot.Fetch(ticket);

            Assert.Equal("", result);
        }
    }
}

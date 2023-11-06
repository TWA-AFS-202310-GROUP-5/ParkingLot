using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLot;

namespace ParkingLotTest
{
    public class ParkingTest
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
        public void should_return_parked_car_when_fetch_given_ticket()
        {
            var parkingLot = new Parking();
            var ticket1 = parkingLot.Park("car1");

            var car1 = parkingLot.Fetch(ticket1);

            Assert.Equal("car1", car1);
        }

        [Fact]
        public void should_return_two_parked_car_when_fetch_given_two_ticket()
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
        public void Should_throw_exception_when_fetch_given_wrong_ticket()
        {
            var parkingLot = new Parking();
            var ticket1 = parkingLot.Park("car1");
            var ticket2 = parkingLot.Park("car2");

            var result = Assert.Throws<UnrecognizedTicketException>(() =>parkingLot.Fetch("ticket do not exit."));
            Assert.Equal("Unrecognized parking ticket", result.Message);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_used_ticket()
        {
            var parkingLot = new Parking();
            var ticket = parkingLot.Park("car1");

            var car = parkingLot.Fetch(ticket);

            var result = Assert.Throws<UnrecognizedTicketException>(() => parkingLot.Fetch(ticket));
            Assert.Equal("Unrecognized parking ticket", result.Message);
        }

        [Fact]
        public void Should_throw_exception_when_park_given_parking_is_full()
        {
            var parkingLot = new Parking();
            for (int i = 0; i < 10; i++)
            {
                parkingLot.Park($"car{i}");
            }

            var result = Assert.Throws<NoAvailablePositionException>(() => parkingLot.Park("car No available position"));
            Assert.Equal("No available position", result.Message);
        }
    }
}

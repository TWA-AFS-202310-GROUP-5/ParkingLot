using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_car_when_fetch_given_ticket()
        {
            var car = "car";

            var parkingBoy = new ParkingBoy();
            var ticket = parkingBoy.Park(car);
            var result = parkingBoy.Fetch(ticket);

            Assert.Equal(car, result);
        }

        [Fact]
        public void should_return_parked_car_when_fetch_given_ticket()
        {
            var parkingBoy = new ParkingBoy();
            var ticket1 = parkingBoy.Park("car1");

            var car1 = parkingBoy.Fetch(ticket1);

            Assert.Equal("car1", car1);
        }

        [Fact]
        public void should_return_two_parked_car_when_fetch_given_two_ticket()
        {
            var parkingBoy = new ParkingBoy();
            var ticket1 = parkingBoy.Park("car1");
            var ticket2 = parkingBoy.Park("car2");

            var car1 = parkingBoy.Fetch(ticket1);
            var car2 = parkingBoy.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_wrong_ticket()
        {
            var parkingBoy = new ParkingBoy();
            var ticket1 = parkingBoy.Park("car1");
            var ticket2 = parkingBoy.Park("car2");

            var result = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch("ticket do not exit."));
            Assert.Equal("Unrecognized parking ticket", result.Message);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_used_ticket()
        {
            var parkingBoy = new ParkingBoy();
            var ticket = parkingBoy.Park("car1");

            var car = parkingBoy.Fetch(ticket);

            var result = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch(ticket));
            Assert.Equal("Unrecognized parking ticket", result.Message);
        }

        [Fact]
        public void Should_throw_exception_when_park_given_parking_is_full()
        {
            var parkingBoy = new ParkingBoy();
            var ticket1 = parkingBoy.Park("car1");
            var ticket2 = parkingBoy.Park("car2");
            var ticket3 = parkingBoy.Park("car3");
            var ticket4 = parkingBoy.Park("car4");
            var ticket5 = parkingBoy.Park("car5");
            var ticket6 = parkingBoy.Park("car6");
            var ticket7 = parkingBoy.Park("car7");
            var ticket8 = parkingBoy.Park("car8");
            var ticket9 = parkingBoy.Park("car9");
            var ticket10 = parkingBoy.Park("car10");

            var result = Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park("car11"));
            Assert.Equal("No available position", result.Message);
        }
    }
}

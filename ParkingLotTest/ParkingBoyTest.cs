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

            var parkingBoy = new StandardParkingBoy();
            var ticket = parkingBoy.Park(car);
            var result = parkingBoy.Fetch(ticket);

            Assert.Equal(car, result);
        }

        [Fact]
        public void should_return_parked_car_when_fetch_given_ticket()
        {
            var parkingBoy = new StandardParkingBoy();
            var ticket1 = parkingBoy.Park("car1");

            var car1 = parkingBoy.Fetch(ticket1);

            Assert.Equal("car1", car1);
        }

        [Fact]
        public void should_return_two_parked_car_when_fetch_given_two_ticket()
        {
            var parkingBoy = new StandardParkingBoy();
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
            var parkingBoy = new StandardParkingBoy();
            var ticket1 = parkingBoy.Park("car1");
            var ticket2 = parkingBoy.Park("car2");

            var result = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch("ticket do not exit."));
            Assert.Equal("Unrecognized parking ticket", result.Message);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_used_ticket()
        {
            var parkingBoy = new StandardParkingBoy();
            var ticket = parkingBoy.Park("car1");

            var car = parkingBoy.Fetch(ticket);

            var result = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch(ticket));
            Assert.Equal("Unrecognized parking ticket", result.Message);
        }

        [Fact]
        public void Should_throw_exception_when_park_given_parking_is_full()
        {
            var parkingBoy = new StandardParkingBoy();
            for (int i = 0; i < 20; i++)
            {
                parkingBoy.Park($"car{i}");
            }


            var result = Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park("car No available position"));
            Assert.Equal("No available position", result.Message);
        }
    }
}

using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyWithTwoParkingLotsTest
    {
        [Fact]
        public void Should_return_right_position_when_park_given_car()
        {
            var car = "car";

            var parkingBoy = new ParkingBoy();
            var ticket = parkingBoy.Park(car);

            Assert.Equal("ParkingLot1-" + car, ticket);
        }

        [Fact]
        public void should_return_right_position_when_park_given_first_parking_is_full()
        {
            var parkingBoy = new ParkingBoy();

            for (int i = 0; i < 10; i++)
            {
                parkingBoy.Park($"car{i}");
            }
            var ticket = parkingBoy.Park("car");


            Assert.Equal("ParkingLot2-car", ticket);
        }

        [Fact]
        public void should_return_two_parked_car_when_fetch_given_two_ticket_in_different_parking_lot()
        {
            var parkingBoy = new ParkingBoy();
            var ticket1 = parkingBoy.Park("car1");
            for (int i = 0; i < 10; i++)
            {
                parkingBoy.Park($"*car{i}");
            }
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
            for (int i = 0; i < 20; i++)
            {
                parkingBoy.Park($"car{i}");
            }


            var result = Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park("car No available position"));
            Assert.Equal("No available position", result.Message);
        }
    }
}

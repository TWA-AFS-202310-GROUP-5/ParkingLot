using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyWithTwoParkingLotsTest
    {
        [Fact]
        public void Should_return_right_position_when_park_given_car()
        {
            var car1 = "car1";
            var car2 = "car2";

            var parkingBoy = new SmartParkingBoy();
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);

            Assert.Equal("ParkingLot1-" + car1, ticket1);
            Assert.Equal("ParkingLot2-" + car2, ticket2);
        }



        [Fact]
        public void Should_throw_exception_when_fetch_given_wrong_ticket()
        {
            var parkingBoy = new SmartParkingBoy();
            var ticket1 = parkingBoy.Park("car1");
            var ticket2 = parkingBoy.Park("car2");

            var result = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch("ticket do not exit."));
            Assert.Equal("Unrecognized parking ticket", result.Message);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_used_ticket()
        {
            var parkingBoy = new SmartParkingBoy();
            var ticket = parkingBoy.Park("car1");

            var car = parkingBoy.Fetch(ticket);

            var result = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch(ticket));
            Assert.Equal("Unrecognized parking ticket", result.Message);
        }

        [Fact]
        public void Should_throw_exception_when_park_given_parking_is_full()
        {
            var parkingBoy = new SmartParkingBoy();
            for (int i = 0; i < 20; i++)
            {
                parkingBoy.Park($"car{i}");
            }


            var result = Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park("car No available position"));
            Assert.Equal("No available position", result.Message);
        }
    }
}

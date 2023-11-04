using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLotManage;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_a_parking_ticket_when_park_the_car_given_a_parking_lot_and_a_car()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            //when
            string ticket = parkingLot.Park("car");
            //then
            Assert.Equal("T-car", ticket);
        }

        [Fact]
        public void Should_return_parked_car_when_fetch_the_car_given_a_parking_lot_with_a_parked_car_and_a_parking_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            //when
            string car = parkingLot.Fetch(ticket);
            //then
            Assert.Equal("car", car);
        }
    }
}

using ParkingLotManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingLotBoyTest
    {
        [Fact]
        public void Should_return_a_parking_ticket_when_park_the_car_given_a_parking_lot_a_standard_parking_boy_and_a_car()
        {
            // given
            ParkingLot parkingLot = new ParkingLot();
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot);
            //when
            string ticket = standardParkinglotBoy.Park("car");
            //then
            Assert.Equal("T-car", ticket);
        }

    }
}

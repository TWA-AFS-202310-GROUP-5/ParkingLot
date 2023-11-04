using ParkingLotManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_car_be_parked_to_parking_lot_contains_more_positions_when_park_the_car_given_a_smart_parking_boy_manage_two_parking_lots_both_with_available_position_and_a_car()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(2);
            ParkingLot parkingLot2 = new ParkingLot(2);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(new ParkingLot[] {parkingLot1, parkingLot2});
            Car car1 = new Car();
            Car car2 = new Car();
            smartParkingBoy.Park(car1);
            //when
            Ticket ticket = smartParkingBoy.Park(car2);
            //then
            Assert.Equal(parkingLot2.ParkingLotId, ticket.ParkingLotId);
        }

        
    }
}

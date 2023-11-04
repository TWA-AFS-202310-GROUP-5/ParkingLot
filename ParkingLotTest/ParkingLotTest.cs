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

        [Fact]
        public void Should_return_the_right_car_with_each_ticket_when_fetch_the_car_twice_given_a_parking_lot_with_two_parked_cars_and_two_parking_tickets()
        {
            // given
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");
            //when
            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);
            //then
            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_return_nothing_when_fetch_the_car_given_a_parking_lot_and_a_wrong_parking_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = "T-car3";
            //when
            string car = parkingLot.Fetch(ticket);
            //then
            Assert.Equal("car3", car);
        }
    }
}

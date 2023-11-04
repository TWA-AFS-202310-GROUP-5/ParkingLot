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
        public void Should_return_nothing_with_error_message_unrecognized_parking_ticket_when_fetch_the_car_given_a_parking_lot_and_an_unrecognized_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = "T-car3";
            string errMsg = "Unrecognized parking ticket.";
            //when
            var wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket));
            //then
            Assert.Equal(errMsg, wrongTicketException.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_unrecognized_parking_ticket_when_fetch_the_car_given_a_parking_lot_and_a_used_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            parkingLot.Fetch(ticket);
            string errMsg = "Unrecognized parking ticket.";
            //when
            var wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket));
            //then
            Assert.Equal(errMsg, wrongTicketException.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_no_available_position_when_park_the_car_given_a_parking_lot_without_any_position_and_a_car()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            parkingLot.Park("car1");
            parkingLot.Park("car2");
            parkingLot.Park("car3");
            parkingLot.Park("car4");
            parkingLot.Park("car5");
            parkingLot.Park("car6");
            parkingLot.Park("car7");
            parkingLot.Park("car8");
            parkingLot.Park("car9");
            parkingLot.Park("car10");
            string errMsg = "No available position.";
            //when
            var exception = Assert.Throws<NoPositionException>(() => parkingLot.Park("car11"));
            //then
            Assert.Equal(errMsg, exception.Message);
        }
    }
}

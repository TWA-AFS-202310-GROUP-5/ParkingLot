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
            string car = "car";
            //when
            string ticket = standardParkinglotBoy.Park(car);
            //then
            Assert.Equal("T-car", ticket);
        }

        [Fact]
        public void Should_return_the_parked_car_when_fetch_the_car_given_a_parking_lot_with_a_parked_car_a_standard_parking_boy_and_a_parking_ticket()
        {
            // given
            ParkingLot parkingLot = new ParkingLot();
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot);
            string car = "car";
            string ticket = standardParkinglotBoy.Park(car);
            // when
            string fetchedCar = standardParkinglotBoy.Fetch(ticket);
            // then
            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void Should_return_the_right_car_with_each_ticket_when_fetch_the_car_twice_given_a_parking_lot_with_two_parked_cars_a_standard_parking_boy_and_two_parking_tickets()
        {
            // given
            ParkingLot parkingLot = new ParkingLot();
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot);
            string car1 = "car1";
            string car2 = "car2";
            string ticket1 = standardParkinglotBoy.Park(car1);
            string ticket2 = standardParkinglotBoy.Park(car2);
            //when
            string fetchedCar1 = standardParkinglotBoy.Fetch(ticket1);
            string fetchedCar2 = standardParkinglotBoy.Fetch(ticket2);
            //then
            Assert.Equal(car1, fetchedCar1);
            Assert.Equal(car2, fetchedCar2);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_unrecognized_parking_ticket_when_fetch_the_car_given_a_parking_lot_a_standard_parking_boy_and_a_wrong_parking_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot);
            string ticket = "T-car3";
            string errMsg = "Unrecognized parking ticket.";
            //when
            var exception = Assert.Throws<WrongTicketException>(() => standardParkinglotBoy.Fetch(ticket));
            //then
            Assert.Equal(errMsg, exception.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_unrecognized_parking_ticket_when_fetch_the_car_given_a_parking_lot_a_standard_parking_boy_and_a_used_parking_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot);
            string car = "car";
            string ticket = standardParkinglotBoy.Park(car);
            standardParkinglotBoy.Fetch(ticket);
            string errMsg = "Unrecognized parking ticket.";
            //when
            var exception = Assert.Throws<WrongTicketException>(() => standardParkinglotBoy.Fetch(ticket));
            //then
            Assert.Equal(errMsg, exception.Message);
        }
    }
}

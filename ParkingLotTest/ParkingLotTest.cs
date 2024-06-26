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
            Car car = new Car();
            //when
            Ticket ticket = parkingLot.Park(car);
            //then
            Assert.Equal(car.ID, ticket.CarId);
        }

        [Fact]
        public void Should_return_parked_car_when_fetch_the_car_given_a_parking_lot_with_a_parked_car_and_a_parking_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            Car car = new Car();
            Ticket ticket = parkingLot.Park(car);
            //when
            Car fetchedCar = parkingLot.Fetch(ticket);
            //then
            Assert.Equal(car.ID, fetchedCar.ID);
        }

        [Fact]
        public void Should_return_the_right_car_with_each_ticket_when_fetch_the_car_twice_given_a_parking_lot_with_two_parked_cars_and_two_parking_tickets()
        {
            // given
            ParkingLot parkingLot = new ParkingLot();
            Car car1 = new Car();
            Car car2 = new Car();
            Ticket ticket1 = parkingLot.Park(car1);
            Ticket ticket2 = parkingLot.Park(car2);
            //when
            Car fetchedCar1 = parkingLot.Fetch(ticket1);
            Car fetchedCar2 = parkingLot.Fetch(ticket2);
            //then
            Assert.Equal(car1.ID, fetchedCar1.ID);
            Assert.Equal(car2.ID, fetchedCar2.ID);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_unrecognized_parking_ticket_when_fetch_the_car_given_a_parking_lot_and_an_unrecognized_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticket = new Ticket();
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
            Car car = new Car();
            Ticket ticket = parkingLot.Park(car);
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
            ParkingLot parkingLot = new ParkingLot(1);
            Car car = new Car();
            parkingLot.Park(car);
            string errMsg = "No available position.";
            //when
            var exception = Assert.Throws<NoPositionException>(() => parkingLot.Park(new Car()));
            //then
            Assert.Equal(errMsg, exception.Message);
        }
    }
}

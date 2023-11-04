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
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot, new StandardSearchStrategy());
            Car car = new Car();
            //when
            Ticket ticket = standardParkinglotBoy.Park(car);
            //then
            Assert.Equal(car.ID, ticket.CarId);
        }

        [Fact]
        public void Should_return_the_parked_car_when_fetch_the_car_given_a_parking_lot_with_a_parked_car_a_standard_parking_boy_and_a_parking_ticket()
        {
            // given
            ParkingLot parkingLot = new ParkingLot();
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot, new StandardSearchStrategy());
            Car car = new Car();
            Ticket ticket = standardParkinglotBoy.Park(car);
            // when
            Car fetchedCar = standardParkinglotBoy.Fetch(ticket);
            // then
            Assert.Equal(car.ID, fetchedCar.ID);
        }

        [Fact]
        public void Should_return_the_right_car_with_each_ticket_when_fetch_the_car_twice_given_a_parking_lot_with_two_parked_cars_a_standard_parking_boy_and_two_parking_tickets()
        {
            // given
            ParkingLot parkingLot = new ParkingLot();
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot, new StandardSearchStrategy());
            Car car1 = new Car();
            Car car2 = new Car();
            Ticket ticket1 = standardParkinglotBoy.Park(car1);
            Ticket ticket2 = standardParkinglotBoy.Park(car2);
            //when
            Car fetchedCar1 = standardParkinglotBoy.Fetch(ticket1);
            Car fetchedCar2 = standardParkinglotBoy.Fetch(ticket2);
            //then
            Assert.Equal(car1.ID, fetchedCar1.ID);
            Assert.Equal(car2.ID, fetchedCar2.ID);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_unrecognized_parking_ticket_when_fetch_the_car_given_a_parking_lot_a_standard_parking_boy_and_a_wrong_parking_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot, new StandardSearchStrategy());
            Ticket ticket = new Ticket();
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
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot, new StandardSearchStrategy());
            Car car = new Car();
            Ticket ticket = standardParkinglotBoy.Park(car);
            standardParkinglotBoy.Fetch(ticket);
            string errMsg = "Unrecognized parking ticket.";
            //when
            var exception = Assert.Throws<WrongTicketException>(() => standardParkinglotBoy.Fetch(ticket));
            //then
            Assert.Equal(errMsg, exception.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_no_available_position_when_park_the_car_given_a_parking_lot_without_any_position_a_standard_parking_boy_and_a_car()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(2);
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(parkingLot, new StandardSearchStrategy());
            standardParkinglotBoy.Park(new Car());
            standardParkinglotBoy.Park(new Car());
            string errMsg = "No available position.";
            //when
            var exception = Assert.Throws<NoPositionException>(() => standardParkinglotBoy.Park(new Car()));
            //then
            Assert.Equal(errMsg, exception.Message);
        }

        /*
         * standard parking lot boy manage multi parking lots
         */
        [Fact]
        public void Should_car_be_parked_to_first_parking_lot_when_park_the_car_given_a_standard_parking_boy_manage_two_parking_lots_both_with_available_position_and_a_car()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(1);
            ParkingLot parkingLot2 = new ParkingLot(1);
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(new ParkingLot[] { parkingLot1, parkingLot2 }, new StandardSearchStrategy());
            Car car = new Car();
            //when
            Ticket ticket = standardParkinglotBoy.Park(car);
            //then
            Assert.Equal(parkingLot1.ParkingLotId, ticket.ParkingLotId);
        }

        [Fact]
        public void Should_return_right_car_with_each_ticket_when_fetch_the_car_twice_given_a_standard_parking_boy_manage_two_parking_lots_both_with_a_parked_car_and_two_parking_ticket()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(1);
            ParkingLot parkingLot2 = new ParkingLot(1);
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(new ParkingLot[] { parkingLot1, parkingLot2 }, new StandardSearchStrategy());
            Car car1 = new Car();
            Car car2 = new Car();
            Ticket ticket1 = standardParkinglotBoy.Park(car1);
            Ticket ticket2 = standardParkinglotBoy.Park(car2);
            //when
            Car fetchedCar1 = standardParkinglotBoy.Fetch(ticket1);
            Car fetchedCar2 = standardParkinglotBoy.Fetch(ticket2);
            //then
            Assert.Equal(car1.ID, fetchedCar1.ID);
            Assert.Equal(car2.ID, fetchedCar2.ID);
        }

        [Fact]
        public void Should_the_car_be_parked_to_second_parking_lot_when_park_the_car_given_a_standard_parking_boy_who_manage_two_parking_lots_first_is_full_and_second_with_available_position_and_a_car()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(1);
            ParkingLot parkingLot2 = new ParkingLot(1);
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(new ParkingLot[] { parkingLot1, parkingLot2 }, new StandardSearchStrategy());
            Car car1 = new Car();
            Car car2 = new Car();
            standardParkinglotBoy.Park(car1);
            //when
            Ticket ticket2 = standardParkinglotBoy.Park(car2);
            //then
            Assert.Equal(parkingLot2.ParkingLotId, ticket2.ParkingLotId);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_unrecognized_parking_ticket_when_fetch_the_car_given_a_standard_parking_boy_who_manage_two_parking_lots_and_an_unrecognized_ticket()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(1);
            ParkingLot parkingLot2 = new ParkingLot(1);
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(new ParkingLot[] { parkingLot1, parkingLot2 }, new StandardSearchStrategy());
            Car car1 = new Car();
            standardParkinglotBoy.Park(car1);
            Ticket unrecognizedTicket = new Ticket();
            string errMsg = "Unrecognized parking ticket.";
            //when
            var exception = Assert.Throws<WrongTicketException>(() => standardParkinglotBoy.Fetch(unrecognizedTicket));
            //then
            Assert.Equal(errMsg, exception.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_unrecognized_parking_ticket_when_fetch_the_car_given_a_standard_parking_boy_who_manage_two_parking_lots_and_a_used_ticket()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(1);
            ParkingLot parkingLot2 = new ParkingLot(1);
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(new ParkingLot[] { parkingLot1, parkingLot2 }, new StandardSearchStrategy());
            Car car1 = new Car();
            Ticket ticket = standardParkinglotBoy.Park(car1);
            standardParkinglotBoy.Fetch(ticket);
            string errMsg = "Unrecognized parking ticket.";
            //when
            var exception = Assert.Throws<WrongTicketException>(() => standardParkinglotBoy.Fetch(ticket));
            //then
            Assert.Equal(errMsg, exception.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_no_available_position_when_park_the_car_given_a_standard_parking_boy_who_manage_two_parking_lots_both_without_any_position_and_a_car()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot(1);
            ParkingLot parkingLot2 = new ParkingLot(2);
            StandardParklotBoy standardParkinglotBoy = new StandardParklotBoy(new ParkingLot[] { parkingLot1, parkingLot2 }, new StandardSearchStrategy());
            standardParkinglotBoy.Park(new Car());
            standardParkinglotBoy.Park(new Car());
            standardParkinglotBoy.Park(new Car());
            string errMsg = "No available position.";
            //when
            var exception = Assert.Throws<NoPositionException>(() => standardParkinglotBoy.Park(new Car()));
            //then
            Assert.Equal(errMsg, exception.Message);
        }
    }
}

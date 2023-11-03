using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLotManagement;
using static System.Collections.Specialized.BitVector32;
using System.Net.Sockets;

namespace ParkingLotManagementTest
{
    public class ParkingLotManagementTest
    {
        [Theory]
        [InlineData("Car")]
        [InlineData("Car2")]
        public void Should_return_ticket_when_costumer_parking_given_car(string carName)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticket = parkingLot.Park(carName);

            string carReceived = parkingLot.Fetch(ticket);

            Assert.Equal(carName, carReceived);
        }

        [Theory]
        [InlineData("Car1", "Car2")]
        public void Should_return_correct_ticket_when_many_costumers_parking_given_car(string carName1, string carName2)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticket1 = parkingLot.Park(carName1);
            Ticket ticket2 = parkingLot.Park(carName2);

            string carReceived1 = parkingLot.Fetch(ticket1);
            string carReceived2 = parkingLot.Fetch(ticket2);

            Assert.Equal(carName1, ticket1.CarName);
            Assert.Equal(carName2, ticket2.CarName);
            Assert.Equal(carName1, carReceived1);
            Assert.Equal(carName2, carReceived2);
        }

        [Theory]
        [InlineData("Car1", "Car2")]
        public void Should_return_empty_when_costumer_using_incorrect_ticket(string carNameCorrect, string carNameFalse)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticketCorrect = parkingLot.Park(carNameCorrect);
            Ticket ticketFalse = new Ticket(carNameFalse, parkingLot.Name);

            Action action = () => parkingLot.Fetch(ticketFalse);

            var exception = Assert.Throws<WrongTicketExceptoion>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("Car1")]
        public void Should_return_empty_when_costumer_using_null_ticket(string carNameCorrect)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticketCorrect = parkingLot.Park(carNameCorrect);
            Ticket ticketNull = null;

            Action action = () => parkingLot.Fetch(ticketNull);

            var exception = Assert.Throws<WrongTicketExceptoion>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("Car")]
        [InlineData("Car2")]
        public void Should_throw_exception_when_costumer_fetching_car_with_used_ticket(string carName)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticket = parkingLot.Park(carName);
            string carReceived = parkingLot.Fetch(ticket);

            Action action = () => parkingLot.Fetch(ticket);

            var exception = Assert.Throws<WrongTicketExceptoion>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("Car", 10)]
        public void Should_return_no_ticket_when_parking_lot_has_no_position_left(string carName, int capacity)
        {
            ParkingLot parkingLot = new ParkingLot();
            for (var i = 0; i < capacity; i++)
            {
                Ticket teampTicket = parkingLot.Park(carName + i);
            }

            Action action = () => parkingLot.Park(carName + capacity);

            var exception = Assert.Throws<WrongTicketExceptoion>(action);
            Assert.Equal("No available position.", exception.Message);
        }

        [Theory]
        [InlineData("Car")]
        [InlineData("Car2")]
        public void Should_parking_boy_park_car_to_first_lot_given_two_available_lots(string carName)
        {
            ParkingLot parkingLot1 = new ParkingLot("1");
            ParkingLot parkingLot2 = new ParkingLot("2");
            StandardParkingBoy parkingBoy = new StandardParkingBoy();
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);

            Ticket ticket = parkingBoy.Park(carName);

            Assert.Equal("1", ticket.ParkingLot);
        }

        [Theory]
        [InlineData("Car")]
        public void Should_parking_boy_park_car_to_second_given_first_full(string carName)
        {
            ParkingLot parkingLot1 = new ParkingLot("1");
            ParkingLot parkingLot2 = new ParkingLot("2");
            StandardParkingBoy parkingBoy = new StandardParkingBoy();
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);
            for (var i = 0; i < parkingLot1.Capacity; i++)
            {
                Ticket teampTicket = parkingBoy.Park(carName + i);
            }

            Ticket ticket = parkingBoy.Park(carName);

            Assert.Equal("2", ticket.ParkingLot);
        }

        [Theory]
        [InlineData("Car1", "Car2")]
        public void Should_parking_boy_return_correct_car_given_two_car_in_two_parkinglots(string carName1, string carName2)
        {
            ParkingLot parkingLot1 = new ParkingLot("1");
            ParkingLot parkingLot2 = new ParkingLot("2");
            StandardParkingBoy parkingBoy = new StandardParkingBoy();
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);

            Ticket ticket1 = parkingBoy.Park(carName1);
            for (var i = 0; i < parkingLot1.Capacity; i++)
            {
                Ticket teampTicket = parkingBoy.Park(carName1 + i);
            }

            Ticket ticket2 = parkingBoy.Park(carName2);
            string receivedCar1 = parkingBoy.Fetch(ticket1);
            string receivedCar2 = parkingBoy.Fetch(ticket2);

            Assert.Equal(carName1, receivedCar1);
            Assert.Equal(carName2, receivedCar2);
        }

        [Theory]
        [InlineData("Car1")]
        public void Should_parking_boy_return_empty_when_costumer_using_null_ticket(string carNameCorrect)
        {
            ParkingLot parkingLot1 = new ParkingLot("1");
            ParkingLot parkingLot2 = new ParkingLot("2");
            StandardParkingBoy parkingBoy = new StandardParkingBoy();
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);
            Ticket ticketCorrect = parkingBoy.Park(carNameCorrect);
            Ticket ticketNull = null;

            Action action = () => parkingBoy.Fetch(ticketNull);

            var exception = Assert.Throws<WrongTicketExceptoion>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("Car")]
        [InlineData("Car2")]
        public void Should_parking_boy_throw_exception_when_costumer_fetching_car_with_used_ticket(string carName)
        {
            ParkingLot parkingLot1 = new ParkingLot("1");
            ParkingLot parkingLot2 = new ParkingLot("2");
            StandardParkingBoy parkingBoy = new StandardParkingBoy();
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);
            Ticket ticket = parkingBoy.Park(carName);
            string carReceived = parkingBoy.Fetch(ticket);

            Action action = () => parkingBoy.Fetch(ticket);

            var exception = Assert.Throws<WrongTicketExceptoion>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("Car", "Parking Lot AAA")]
        public void Should_parking_boy_return_no_ticket_when_parking_lot_has_no_position_left(string carName, string parkingLotName)
        {
            ParkingLot parkingLot1 = new ParkingLot("1");
            ParkingLot parkingLot2 = new ParkingLot("2");
            StandardParkingBoy parkingBoy = new StandardParkingBoy();
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);

            for (var i = 0; i < 2 * parkingLot1.Capacity; i++)
            {
                Ticket teampTicket = parkingBoy.Park(carName + i);
            }

            Action action = () => parkingBoy.Park(carName + parkingLot1.Capacity);

            var exception = Assert.Throws<WrongTicketExceptoion>(action);
            Assert.Equal("No available position.", exception.Message);
        }
    }
}

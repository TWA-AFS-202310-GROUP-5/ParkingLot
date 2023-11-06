using ParkingLotManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Theory]
        [InlineData("Car")]
        [InlineData("Car2")]
        public void Should_parking_boy_park_car_to_first_lot_given_two_available_lots(string carName)
        {
            ParkingLot parkingLot1 = new ParkingLot("1");
            ParkingLot parkingLot2 = new ParkingLot("2");
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.SetStrategy(new StandardStrategy());
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
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.SetStrategy(new StandardStrategy());
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);
            for (var i = 0; i < parkingLot1.Capacity; i++)
            {
                Ticket tempTicket = parkingBoy.Park(carName + i);
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
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.SetStrategy(new StandardStrategy());
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);

            Ticket ticket1 = parkingBoy.Park(carName1);
            for (var i = 0; i < parkingLot1.Capacity; i++)
            {
                Ticket tempTicket = parkingBoy.Park(carName1 + i);
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
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.SetStrategy(new StandardStrategy());
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
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.SetStrategy(new StandardStrategy());
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
            ParkingBoy parkingBoy = new ParkingBoy();
            parkingBoy.SetStrategy(new StandardStrategy());
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);

            for (var i = 0; i < 2 * parkingLot1.Capacity; i++)
            {
                Ticket tempTicket = parkingBoy.Park(carName + i);
            }

            Action action = () => parkingBoy.Park(carName + parkingLot1.Capacity);

            var exception = Assert.Throws<WrongTicketExceptoion>(action);
            Assert.Equal("No available position.", exception.Message);
        }
    }
}

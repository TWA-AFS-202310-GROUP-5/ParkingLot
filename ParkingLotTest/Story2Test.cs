namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class Story2Test
    {
        [Fact] //Case1
        public void Should_return_nothing_with_erroe_msg_when_fetch_car_given_unrecognized_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();

            string unrecognizedTicket = "errorT";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(unrecognizedTicket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact] //Case2
        public void Should_return_nothing_with_erroe_msg_when_fetch_car_given_used_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string car = "Car";
            string carTicket = parkingLot.Park(car);
            string fetchCar = parkingLot.Fetch(carTicket);
            string usedTicket = carTicket;

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(usedTicket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact] //Case3
        public void Should_return_nothing_with_erroe_msg_when_park_car_with_no_position()
        {
            ParkingLot parkingLot = new ParkingLot();
            int numOfCars = 10;
            List<string> cars = Enumerable.Range(1, numOfCars)
                .Select(i => i.ToString())
                .ToList();
            cars.ForEach(car => parkingLot.Park(car));
            string car = "newCar";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Park(car));
            Assert.Equal("No available position.", wrongTicketException.Message);
        }
    }
}

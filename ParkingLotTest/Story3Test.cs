namespace ParkingLotTest
{
    using ParkingLot;
    using ParkingBoy;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class Story3Test
    {
        [Fact] //Case1
        public void Should_return_a_ticket_when_park_a_car()
        {
            ParkingLot parkingLot = new ParkingLot();
            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string car = "parkthiscar";

            string ticket = standardParkingBoy.Park(car);

            Assert.Equal("T-parkthiscar", ticket);
        }

        [Fact] //Case2
        public void Should_return_parked_car_when_fetch_car_given_parked_car_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string car = "parkedCar";
            string ticket = parkingLot.Park(car);

            string fetchCar = standardParkingBoy.Fetch(ticket);

            Assert.Equal("parkedCar", fetchCar);
        }

        [Fact] //Case3
        public void Should_return_right_car_when_fecth_twice_given_two_parked_cars_tickets()
        {
            ParkingLot parkingLot = new ParkingLot();
            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string car1 = "parkedCar1";
            string car2 = "parkedCar2";
            string ticket1 = parkingLot.Park(car1);
            string ticket2 = parkingLot.Park(car2);

            string fetchCar1 = standardParkingBoy.Fetch(ticket1);
            string fetchCar2 = standardParkingBoy.Fetch(ticket2);

            Assert.Equal("parkedCar1", fetchCar1);
            Assert.Equal("parkedCar2", fetchCar2);
        }

        [Fact] //Case4
        public void Should_return_nothing_with_error_msg_when_fetch_car_given_unrecognized_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string unrecognizedTicket = "errorT";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.Fetch(unrecognizedTicket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact] //Case5
        public void Should_return_nothing_with_error_msg_when_fetch_car_given_used_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string car = "Car";
            string carTicket = parkingLot.Park(car);
            string fetchCar = parkingLot.Fetch(carTicket);
            string usedTicket = carTicket;

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.Fetch(usedTicket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact] //Case6
        public void Should_return_nothing_with_error_msg_when_park_car_with_no_position()
        {
            ParkingLot parkingLot = new ParkingLot();
            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            int numOfCars = 10;
            List<string> cars = Enumerable.Range(1, numOfCars)
                .Select(i => i.ToString())
                .ToList();
            cars.ForEach(car => parkingLot.Park(car));
            string car = "newCar";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.Park(car));
            Assert.Equal("No available position.", wrongTicketException.Message);
        }
    }
}
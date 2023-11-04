namespace ParkingLotTest
{
    using ParkingLot;
    using ParkingBoy;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class Story4Test
    {
        [Fact] //Case1
        public void Should_park_a_car_to_first_parkinglot_when_park_a_car_given_two_available_parkinglots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string car = "parkthiscar";

            string ticket = standardParkingBoy.Park(car);
            int indexOfParkedlot = standardParkingBoy.ReturnIndexOfCarParkedLotOrZero(ticket);

            Assert.Equal(0, indexOfParkedlot);
        }

        [Fact] //Case2
        public void Should_park_a_car_to_second_parkinglot_when_park_a_car_given_first_lot_is_full_and_second_lot_has_available_position()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            int numOfCars = 10;
            List<string> cars = Enumerable.Range(1, numOfCars)
                .Select(i => i.ToString())
                .ToList();
            cars.ForEach(car => parkingLot1.Park(car));

            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot1, new ParkingLot() };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string car = "parkthiscar";

            string ticket = standardParkingBoy.Park(car);
            int indexOfParkedlot = standardParkingBoy.ReturnIndexOfCarParkedLotOrZero(ticket);

            Assert.Equal(1, indexOfParkedlot);
        }

        [Fact] //Case3
        public void Should_return_right_car_when_fecth_twice_given_two_parked_cars_tickets_separately_in_two_lots()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            string car1 = "parkedCar1";
            string car2 = "parkedCar2";
            string ticket1 = parkingLot1.Park(car1);
            string ticket2 = parkingLot2.Park(car2);
            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot1, parkingLot2 };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);

            string fetchCar1 = standardParkingBoy.Fetch(ticket1);
            string fetchCar2 = standardParkingBoy.Fetch(ticket2);

            Assert.Equal("parkedCar1", fetchCar1);
            Assert.Equal("parkedCar2", fetchCar2);
        }

        [Fact] //Case4
        public void Should_return_nothing_with_error_msg_when_fetch_car_given_unrecognized_ticket_in_two_lots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string unrecognizedTicket = "errorT";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.Fetch(unrecognizedTicket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact] //Case5
        public void Should_return_nothing_with_error_msg_when_fetch_car_given_used_ticket_in_two_lots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string car = "Car";
            string carTicket = standardParkingBoy.Park(car);
            string fetchCar = standardParkingBoy.Fetch(carTicket);
            string usedTicket = carTicket;

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.Fetch(usedTicket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact] //Case6
        public void Should_return_nothing_with_error_msg_when_park_car_with_no_position_in_two_lots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            int numOfCars = 10 * 2;
            List<string> cars = Enumerable.Range(1, numOfCars)
                .Select(i => i.ToString())
                .ToList();
            cars.ForEach(car => standardParkingBoy.Park(car));

            string car = "newCar";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.Park(car));
            Assert.Equal("No available position.", wrongTicketException.Message);
        }
    }
}
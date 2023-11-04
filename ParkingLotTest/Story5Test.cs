namespace ParkingLotTest
{
    using ParkingLot;
    using ParkingBoy;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class Story5Test
    {
        [Fact]
        public void Should_park_a_car_to_first_parkinglot_when_park_a_car_given_two_empty_parkinglots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            SmartParkingBoyStrategy smartParkingBoy = new SmartParkingBoyStrategy(parkingLots);
            string car = "parkthiscar";

            string ticket = smartParkingBoy.Park(car);
            int indexOfParkedlot = smartParkingBoy.ReturnIndexOfCarParkedLotOrDefaultZero(ticket);

            Assert.Equal(0, indexOfParkedlot);
        }

        [Fact]
        public void Should_park_a_car_to_second_parkinglot_when_park_a_car_given_first_lot_parked_1car_with_second_lot_empty()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            string car1 = "parkedCar1";
            string ticket1 = parkingLot1.Park(car1);

            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot1, new ParkingLot() };
            SmartParkingBoyStrategy smartParkingBoy = new SmartParkingBoyStrategy(parkingLots);
            string car = "parkthiscar";

            string ticket = smartParkingBoy.Park(car);
            int indexOfParkedlot = smartParkingBoy.ReturnIndexOfCarParkedLotOrDefaultZero(ticket);

            Assert.Equal(1, indexOfParkedlot);
        }

        [Fact]
        public void Should_park_a_car_to_first_parkinglot_when_park_a_car_given_second_lot_parked_1car_with_first_lot_empty()
        {
            ParkingLot parkingLot2 = new ParkingLot();
            string car1 = "parkedCar1";
            string ticket1 = parkingLot2.Park(car1);

            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(), parkingLot2 };
            SmartParkingBoyStrategy smartParkingBoy = new SmartParkingBoyStrategy(parkingLots);
            string car = "parkthiscar";

            string ticket = smartParkingBoy.Park(car);
            int indexOfParkedlot = smartParkingBoy.ReturnIndexOfCarParkedLotOrDefaultZero(ticket);

            Assert.Equal(0, indexOfParkedlot);
        }

        [Fact]
        public void Should_return_right_car_when_fecth_twice_given_two_parked_cars_tickets_separately_in_two_lots()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            string car1 = "parkedCar1";
            string car2 = "parkedCar2";
            string ticket1 = parkingLot1.Park(car1);
            string ticket2 = parkingLot2.Park(car2);
            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot1, parkingLot2 };
            SmartParkingBoyStrategy smartParkingBoy = new SmartParkingBoyStrategy(parkingLots);

            string fetchCar1 = smartParkingBoy.Fetch(ticket1);
            string fetchCar2 = smartParkingBoy.Fetch(ticket2);

            Assert.Equal("parkedCar1", fetchCar1);
            Assert.Equal("parkedCar2", fetchCar2);
        }

        [Fact]
        public void Should_return_nothing_with_error_msg_when_fetch_car_given_unrecognized_ticket_in_two_lots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            SmartParkingBoyStrategy smartParkingBoy = new SmartParkingBoyStrategy(parkingLots);
            string unrecognizedTicket = "errorT";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => smartParkingBoy.Fetch(unrecognizedTicket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_msg_when_fetch_car_given_used_ticket_in_two_lots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            SmartParkingBoyStrategy smartParkingBoy = new SmartParkingBoyStrategy(parkingLots);
            string car = "Car";
            string carTicket = smartParkingBoy.Park(car);
            string fetchCar = smartParkingBoy.Fetch(carTicket);
            string usedTicket = carTicket;

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => smartParkingBoy.Fetch(usedTicket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_msg_when_park_car_with_no_position_in_two_lots()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            SmartParkingBoyStrategy smartParkingBoy = new SmartParkingBoyStrategy(parkingLots);
            int numOfCars = 10 * 2;
            List<string> cars = Enumerable.Range(1, numOfCars)
                .Select(i => i.ToString())
                .ToList();
            cars.ForEach(car => smartParkingBoy.Park(car));

            string car = "newCar";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => smartParkingBoy.Park(car));
            Assert.Equal("No available position.", wrongTicketException.Message);
        }
    }
}
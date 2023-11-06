namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class SingleParkigLotTest
    {
        [Fact] //Case1
        public void Should_return_a_ticket_when_park_a_car()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string car = "new car";

            //when
            string ticket = parkingLot.Park(car);

            //then
            Assert.Equal("T-new car", ticket);
        }

        [Fact] //Case2
        public void Should_return_parked_car_when_fetch_car_given_parked_car_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string car = "parkedCar";
            string ticket = parkingLot.Park(car);

            //when
            string fetchCar = parkingLot.Fetch(ticket);

            //then
            Assert.Equal("parkedCar", fetchCar);
        }

        [Fact] //Case3
        public void Should_return_right_car_when_fecth_twice_given_two_parked_cars_tickets()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string car1 = "parkedCar1";
            string car2 = "parkedCar2";
            string ticket1 = parkingLot.Park(car1);
            string ticket2 = parkingLot.Park(car2);

            //when
            string fetchCar1 = parkingLot.Fetch(ticket1);
            string fetchCar2 = parkingLot.Fetch(ticket2);

            //then
            Assert.Equal("parkedCar1", fetchCar1);
            Assert.Equal("parkedCar2", fetchCar2);
        }

        [Fact] //Case4
        public void Should_return_nothing_when_fetch_car_given_wrong_parking_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string car = "parkedCar";
            string ticket = parkingLot.Park(car);

            string wrongTicket = "ttCar";

            Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(wrongTicket));
        }

        [Fact] //Case5
        public void Should_return_nothing_when_fetch_car_given_used_parking_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string car1 = "parkedCar1";
            string ticket1 = parkingLot.Park(car1);
            string fetchCar1 = parkingLot.Fetch(ticket1);

            Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket1));
        }

        [Fact] //Case6
        public void Should_return_nothing_when_park_car_given_no_position_parkinglot()
        {
            ParkingLot parkingLot = new ParkingLot();
            int numOfCars = 10;
            List<string> cars = Enumerable.Range(1, numOfCars)
                .Select(i => i.ToString())
                .ToList();
            cars.ForEach(car => parkingLot.Park(car));
            string car = "newCar";

            Assert.Throws<WrongTicketException>(() => parkingLot.Park(car));
        }
    }
}
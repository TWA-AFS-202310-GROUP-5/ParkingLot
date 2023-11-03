namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_a_parking_ticket_when_park_car_given_a_parking_lot_a_standard_parking_boy_and_a_car()
        {
            //Given
            int capacity = 10;
            ParkingLot parkinglot = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot);
            Car car = new Car();

            //When
            var ticket = parkingBoy.Park(car);

            //Then
            Assert.IsType<Ticket>(ticket);
        }

        [Fact]
        public void Should_return_the_parked_car_when_fetch_the_car_given_a_standard_parking_boy_and_a_parking_lot_with_a_parked_car()
        {
            //Given
            int capacity = 10;
            ParkingLot parkinglot = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot);
            Car car = new Car();
            var ticket = parkingBoy.Park(car);

            //When
            var result = parkingBoy.Fetch(ticket);

            //Then
            Assert.True(car == result);
        }

        [Fact]
        public void Should_return_the_right_car_with_each_ticket_when_fetch_the_car_twice_given_a_standard_parking_boy_and_a_parking_lot_with_two_parked_car()
        {
            //Given
            int capacity = 10;
            ParkingLot parkinglot = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot);
            Car car1 = new Car();
            Car car2 = new Car();
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);

            //When
            var result1 = parkingBoy.Fetch(ticket1);
            var result2 = parkingBoy.Fetch(ticket2);

            //Then
            Assert.True(car1 == result1);
            Assert.True(car2 == result2);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_fetch_the_car_given_a_standard_parking_boy_and_a_parking_lot_and_a_wrong_parking_ticket()
        {
            //Given
            int capacity = 10;
            string expectedErrorMessage = "Unrecognized parking ticket.";
            ParkingLot parkinglot = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot);
            Car car = new Car();
            var ticket = parkingBoy.Park(car);
            var invalidTicket = new Ticket();

            //When
            var exception = Assert.Throws<InvalidTicketException>(() => parkingBoy.Fetch(invalidTicket));

            //Then
            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_fetch_the_car_given_a_standard_parking_boy_and_a_parking_lot_and_a_used_parking_ticket()
        {
            //Given
            int capacity = 10;
            string expectedErrorMessage = "Unrecognized parking ticket.";
            ParkingLot parkinglot = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot);
            Car car = new Car();
            var ticket = parkingBoy.Park(car);
            parkingBoy.Fetch(ticket);

            //When
            var exception = Assert.Throws<InvalidTicketException>(() => parkingBoy.Fetch(ticket));

            //Then
            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_park_the_car_given_a_standard_parking_boy_and_a_parking_without_any_position()
        {
            //Given
            int capacity = 1;
            string expectedErrorMessage = "No available position.";
            ParkingLot parkinglot = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot);
            Car car1 = new Car();
            Car car2 = new Car();
            parkinglot.Park(car1);

            //When
            var exception = Assert.Throws<FullLotException>(() => parkingBoy.Park(car2));

            //Then
            Assert.Equal(expectedErrorMessage, exception.Message);
        }
    }
}

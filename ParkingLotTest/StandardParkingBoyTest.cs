namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class StandardParkingBoyTest
    {
        // ----------------------- a parking lot for single standard parking boy ------------------------------------------
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
            parkingBoy.Park(car1);

            //When
            var exception = Assert.Throws<FullLotException>(() => parkingBoy.Park(car2));

            //Then
            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        // ---------------------- two parking lots for single standard parking boy ------------------------------------------
        [Fact]
        public void Should_parked_in_first_parking_lot_when_park_car_given_two_parking_lot_a_standard_parking_boy_and_a_car()
        {
            //Given
            int capacity = 1;
            ParkingLot parkinglot1 = new ParkingLot(capacity);
            ParkingLot parkinglot2 = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot1, parkinglot2);
            Car car = new Car();

            //When
            var ticket = parkingBoy.Park(car);

            //Then
            Assert.Equal(parkinglot1.Id, ticket.ParkingLotId);
        }

        [Fact]
        public void Should_parked_in_second_parking_lot_when_park_car_given_a_standard_parking_boy_and_first_full_parking_lot_second_empty_parking_lot_and_a_car()
        {
            //Given
            int capacity = 1;
            ParkingLot parkinglot1 = new ParkingLot(capacity);
            ParkingLot parkinglot2 = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot1, parkinglot2);
            Car car1 = new Car();
            Car car2 = new Car();
            var ticket1 = parkingBoy.Park(car1);

            //When
            var ticket2 = parkingBoy.Park(car2);

            //Then
            Assert.Equal(parkinglot2.Id, ticket2.ParkingLotId);
        }

        [Fact]
        public void Should_return_the_right_cars_when_fetch_car_twice_given_a_standard_parking_boy_and_two_nonEmpty_parking_lot_and_a_car()
        {
            //Given
            int capacity = 1;
            ParkingLot parkinglot1 = new ParkingLot(capacity);
            ParkingLot parkinglot2 = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot1, parkinglot2);
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
        public void Should_return_nothing_with_error_message_when_fetch_car_given_a_standard_parking_boy_and_two_parking_lot_and_unrecognized_ticket()
        {
            //Given
            int capacity = 10;
            string expectedErrorMessage = "Unrecognized parking ticket.";
            ParkingLot parkinglot1 = new ParkingLot(capacity);
            ParkingLot parkinglot2 = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot1, parkinglot2);
            Car car1 = new Car();
            Car car2 = new Car();
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);
            var invalidTicket = new Ticket();

            //When
            var exception = Assert.Throws<InvalidTicketException>(() => parkingBoy.Fetch(invalidTicket));

            //Then
            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_fetch_car_given_a_standard_parking_boy_and_two_parking_lot_and_used_ticket()
        {
            //Given
            int capacity = 1;
            string expectedErrorMessage = "Unrecognized parking ticket.";
            ParkingLot parkinglot1 = new ParkingLot(capacity);
            ParkingLot parkinglot2 = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot1, parkinglot2);
            Car car1 = new Car();
            Car car2 = new Car();
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);
            parkingBoy.Fetch(ticket1);

            //When
            var exception = Assert.Throws<InvalidTicketException>(() => parkingBoy.Fetch(ticket1));

            //Then
            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_park_the_car_given_a_standard_parking_boy_and_two_parkingLots_without_any_position()
        {
            //Given
            int capacity = 1;
            string expectedErrorMessage = "No available position.";
            ParkingLot parkinglot1 = new ParkingLot(capacity);
            ParkingLot parkinglot2 = new ParkingLot(capacity);
            ParkingBoy parkingBoy = new ParkingBoy(parkinglot1, parkinglot2);
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();

            parkingBoy.Park(car1);
            parkingBoy.Park(car2);

            //When
            var exception = Assert.Throws<FullLotException>(() => parkingBoy.Park(car3));

            //Then
            Assert.Equal(expectedErrorMessage, exception.Message);
        }
    }
}

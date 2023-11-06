namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();

            string ticket = parkingLot.Park("car");

            //when
            string car = parkingLot.Fetch(ticket);

            //then
            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_car_with_corresponding_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();

            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");

            //when
            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            //then
            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }
    }
}

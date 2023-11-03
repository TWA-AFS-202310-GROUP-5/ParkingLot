namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public Ticket Park(Car car)
        {
            return parkingLot.Park(car);
        }

        public Car Fetch(Ticket ticket)
        {
            return parkingLot.Fetch(ticket);
        }
    }
}

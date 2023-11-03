namespace ParkingBoy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ParkingLot;

    public class ParkingBoy
    {
        private ParkingLot parkingLot;
        private string car;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string Park(string car)
        {
            return parkingLot.Park(car);
        }

        public string Fetch(string ticket)
        {
            return parkingLot.Fetch(ticket);
        }
    }
}

namespace ParkingBoy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Runtime.ConstrainedExecution;
    using ParkingLot;

    public class StandardParkingBoyStrategy : IParkingBoyStrategy
    {
        private ParkingBoy parkingBoy;
        private List<ParkingLot> parkingLots = new List<ParkingLot>();

        public StandardParkingBoyStrategy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
            this.parkingBoy = new ParkingBoy(this.parkingLots);
        }

        public string Park(string car)
        {
            return parkingBoy.Park(car);
        }

        public int ReturnIndexOfCarParkedLotOrDefaultZero(string parkingTicket)
        {
            return parkingBoy.ReturnIndexOfCarParkedLotOrDefaultZero(parkingTicket);
        }

        public string Fetch(string ticket)
        {
            return parkingBoy.Fetch(ticket);
        }
    }
}

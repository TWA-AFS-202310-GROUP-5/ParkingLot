namespace ParkingBoy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using ParkingLot;

    public class SmartParkingBoyStrategy : IParkingBoyStrategy
    {
        private ParkingBoy parkingBoy;
        private List<ParkingLot> parkingLots = new List<ParkingLot>();

        public SmartParkingBoyStrategy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
            this.parkingBoy = new ParkingBoy(this.parkingLots);
        }

        public string Park(string car)
        {
            int mostEmptyPosition = parkingLots.Max(parkingLot => parkingLot.NumOfEmptyPosition);
            return parkingLots.FirstOrDefault(parkingLot => parkingLot.NumOfEmptyPosition == mostEmptyPosition).Park(car);
        }

        public string Fetch(string ticket)
        {
            return parkingBoy.Fetch(ticket);
        }
    }
}

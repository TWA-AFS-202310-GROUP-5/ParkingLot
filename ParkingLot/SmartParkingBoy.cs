namespace ParkingBoy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using ParkingLot;

    public class SmartardParkingBoy : StandardParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        private string car;

        public SmartardParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public override string Park(string car)
        {
            int mostEmptyPosition = parkingLots.Max(parkingLot => parkingLot.NumOfEmptyPosition);

            if (mostEmptyPosition > 0)
            {
                string parkingTicket = parkingLots.FirstOrDefault(parkingLot => parkingLot.NumOfEmptyPosition == mostEmptyPosition).Park(car);
                return parkingTicket;
            }

            return parkingLots[0].Park(car);
        }
    }
}

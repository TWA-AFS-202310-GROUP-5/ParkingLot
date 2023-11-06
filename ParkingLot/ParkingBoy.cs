namespace ParkingBoy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using ParkingLot;

    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        //Standard parkingboy Park logic
        public string Park(string car)
        {
            return parkingLots.FirstOrDefault(parkingLot => parkingLot.NumOfEmptyPosition > 0)?
                .Park(car) ?? parkingLots[0].Park(car);
        }

        public string Fetch(string ticket)
        {
            int indexOfParkingLot = parkingLots.FindIndex(parkinglot => parkinglot.Ticket2carParking
                .ContainsKey(ticket));
            if (indexOfParkingLot != -1)
            {
                return parkingLots[indexOfParkingLot].Fetch(ticket);
            }
            else
            {
                return parkingLots[0].Fetch(ticket);
            }
        }
    }
}

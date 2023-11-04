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
        private string car;

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public string Park(string car)
        {
            for (int i = 0; i < parkingLots.Count; i++)
            {
                if (parkingLots[i].NumOfParkedCars < parkingLots[i].Capacity)
                {
                    string parkingTicket = parkingLots[i].Park(car);
                    return parkingTicket;
                }
            }

            return parkingLots[0].Park(car);
        }

        public int ReturnIndexOfCarParkedLotOrZero(string parkingTicket)
        {
            int indexOfParkingLot = parkingLots.FindIndex(parkinglot => parkinglot.Ticket2carParking.ContainsKey(parkingTicket));
            return indexOfParkingLot != -1 ? indexOfParkingLot : 0;
        }

        public string Fetch(string ticket)
        {
            int indexOfParkingLot = ReturnIndexOfCarParkedLotOrZero(ticket);
            return parkingLots[indexOfParkingLot].Fetch(ticket);
        }
    }
}

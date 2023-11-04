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

        public int ReturnIndexOfCarParkedLotOrDefaultZero(string parkingTicket)
        {
            int indexOfParkingLot = parkingLots.FindIndex(parkinglot => parkinglot.Ticket2carParking
                .ContainsKey(parkingTicket));
            return indexOfParkingLot != -1 ? indexOfParkingLot : 0;
        }

        public string Fetch(string ticket)
        {
            return parkingLots[ReturnIndexOfCarParkedLotOrDefaultZero(ticket)].Fetch(ticket);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private Dictionary<Guid, ParkingLot> parkingLots = new Dictionary<Guid, ParkingLot>();

        public ParkingBoy(ParkingLot parkingLot)
        {
            parkingLots.Add(parkingLot.Id, parkingLot);
        }

        public ParkingBoy(ParkingLot[] parkingLots)
        {
            parkingLots.ToList().ForEach(parkingLot => this.parkingLots.Add(parkingLot.Id, parkingLot));
        }

        public Ticket Park(Car car)
        {
            try
            {
                return parkingLots
                    .Values
                    .Where(parkingLot => parkingLot.EmptyLotNum > 0)
                    .First()
                    .Park(car);
            }
            catch (Exception)
            {
                throw new FullLotException();
            }
        }

        public Car Fetch(Ticket ticket)
        {
            try
            {
                return parkingLots[ticket.ParkingLotId].Fetch(ticket);
            }
            catch (KeyNotFoundException)
            {
                throw new InvalidTicketException();
            }
        }
    }
}

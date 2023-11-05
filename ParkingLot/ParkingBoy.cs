using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private Dictionary<Guid, ParkingLot> parkingLots = new Dictionary<Guid, ParkingLot>();
        private IParkingStrategy parkingStrategy = new StandardParkingStrategy();

        public ParkingBoy(params ParkingLot[] parkingLots)
        {
            parkingLots.ToList().ForEach(parkingLot => this.parkingLots.Add(parkingLot.Id, parkingLot));
        }

        public ParkingBoy(IParkingStrategy parkingStrategy, params ParkingLot[] parkingLots)
        {
            parkingLots.ToList().ForEach(parkingLot => this.parkingLots.Add(parkingLot.Id, parkingLot));
            this.parkingStrategy = parkingStrategy;
        }

        public virtual Ticket Park(Car car)
        {
            return parkingStrategy.Park(car, parkingLots);
        }

        public virtual Car Fetch(Ticket ticket)
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

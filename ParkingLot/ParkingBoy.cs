using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();

        public ParkingBoy(ParkingLot parkingLot)
        {
            parkingLots.Add(parkingLot);
        }

        public ParkingBoy(ParkingLot[] parkingLots)
        {
            parkingLots.ToList().ForEach(parkingLot => this.parkingLots.Add(parkingLot));
        }

        public Ticket Park(Car car)
        {
            try
            {
                return parkingLots
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
                return parkingLots
                    .Where(parkingLot => parkingLot.HasCar(ticket))
                    .First()
                    .Fetch(ticket);
            }
            catch (Exception)
            {
                throw new InvalidTicketException();
            }
        }
    }
}

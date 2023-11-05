using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class StandardParkingStrategy : IParkingStrategy
    {
        public Ticket Park(Car car, Dictionary<Guid, ParkingLot> parkingLots)
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
    }
}

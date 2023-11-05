using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingStrategy : IParkingStrategy
    {
        public Ticket Park(Car car, Dictionary<Guid, ParkingLot> parkingLots)
        {
            try
            {
                return parkingLots
                    .Values
                    .OrderByDescending(parkingLot => parkingLot.EmptyLotNum)
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

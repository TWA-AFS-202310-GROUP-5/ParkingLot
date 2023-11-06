using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class StandardParkingStrategy : IParkingStrategy
    {
        public ParkingLot FindAvailableLot(Dictionary<Guid, ParkingLot> parkingLots)
        {
            try
            {
                return parkingLots
                .Values
                .Where(parkingLot => parkingLot.EmptyLotNum > 0)
                .First();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

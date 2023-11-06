using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingStrategy : IParkingStrategy
    {
        public ParkingLot FindAvailableLot(Dictionary<Guid, ParkingLot> parkingLots)
        {
            try
            {
                return parkingLots
                .Values
                .OrderByDescending(parkingLot => parkingLot.EmptyLotNum)
                .First();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

using System.Collections.Generic;
using System;

namespace ParkingLot
{
    public interface IParkingStrategy
    {
        public ParkingLot FindAvailableLot(Dictionary<Guid, ParkingLot> parkingLots);
    }
}
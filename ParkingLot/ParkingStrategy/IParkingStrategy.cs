using System.Collections.Generic;
using System;

namespace ParkingLot
{
    public interface IParkingStrategy
    {
        public Ticket Park(Car car, Dictionary<Guid, ParkingLot> parkingLots);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class StandardStrategy : IParkingStrategy
    {
        public ParkingLot GetFirstAvailableParkingLot(List<ParkingLot> parkingLots)
        {
            return parkingLots.FirstOrDefault(x => x.CountEmptySpots() > 0);
        }
    }

    public class SmartStrategy : IParkingStrategy
    {
        public ParkingLot GetFirstAvailableParkingLot(List<ParkingLot> parkingLots)
        {
            return parkingLots.OrderByDescending(x => x.CountEmptySpots())
                .FirstOrDefault(x => x.CountEmptySpots() > 0);
        }
    }
}

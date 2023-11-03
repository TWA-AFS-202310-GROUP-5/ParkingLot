using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class StandardStrategy : IStrategy
    {
        ParkingLot IStrategy.GetFirstAvailableParkingLot(List<ParkingLot> parkingLots)
        {
            return parkingLots.FirstOrDefault(x => x.GetEmptyPosition() > 0);
        }
    }

    public class SmartStrategy : IStrategy
    {
        public ParkingLot GetFirstAvailableParkingLot(List<ParkingLot> parkingLots)
        {
            return parkingLots.OrderByDescending(x => x.GetEmptyPosition())
                .FirstOrDefault(x => x.GetEmptyPosition() > 0);
        }
    }
}

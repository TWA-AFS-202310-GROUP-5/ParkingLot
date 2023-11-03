using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class StandardStrategy : IStrategy
    {
<<<<<<< HEAD
        public ParkingLot GetFirstAvailableParkingLot(List<ParkingLot> parkingLots)
=======
        ParkingLot IStrategy.GetFirstAvailableParkingLot(List<ParkingLot> parkingLots)
>>>>>>> 3f3152a0df0d542462716adbb19f0c7297740456
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

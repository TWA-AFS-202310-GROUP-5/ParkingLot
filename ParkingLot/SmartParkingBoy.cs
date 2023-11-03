using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class SmartParkingBoy : StandardParkingBoy
    {
        public override ParkingLot GetFirstAvailableParkingLot()
        {
            return ParkingLots.OrderByDescending(x => x.GetEmptyPosition())
                .FirstOrDefault(x => x.GetEmptyPosition() > 0);
        }
    }
}

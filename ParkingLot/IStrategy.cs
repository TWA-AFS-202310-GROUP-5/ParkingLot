using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public interface IStrategy
    {
        public ParkingLot GetFirstAvailableParkingLot(List<ParkingLot> parkingLots);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public interface IParkingStrategy
    {
        public ParkingLot GetFirstAvailableParkingLot(List<ParkingLot> parkingLots);
    }
}

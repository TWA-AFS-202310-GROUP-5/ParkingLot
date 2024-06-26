using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage.searchLotStrategy
{
    public class SmartSearchStrategy : ISearchStrategy
    {
        public ParkingLot SearchParkingLot(List<ParkingLot> parkingLots)
        {
            return parkingLots.OrderByDescending(x => x.EmptyNum).First();
        }
    }
}

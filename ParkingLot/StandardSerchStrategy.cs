using ParkingLotManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class StandardSearchStrategy : ISearchStrategy
    {
        public ParkingLot SearchParkingLot(List<ParkingLot> parkingLots)
        {
            return parkingLots.Find(x => !x.IsFull);
        }
    }
}
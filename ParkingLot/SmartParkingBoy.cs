using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class SmartParkingBoy : StandardParklotBoy
    {
        public SmartParkingBoy(ParkingLot parkingLot) : base(parkingLot)
        {
        }

        public SmartParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }
    }
}

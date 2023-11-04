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

        public override Ticket Park(Car car)
        {
           return parkingLots.OrderByDescending(x => x.EmptyNum).First().Park(car);
        }

    }
}

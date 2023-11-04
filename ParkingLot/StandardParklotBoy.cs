using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class StandardParklotBoy
    {
        private ParkingLot parkingLot;
        public StandardParklotBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public string Park(string car)
        {
            return parkingLot.Park(car);
        }
    }
}

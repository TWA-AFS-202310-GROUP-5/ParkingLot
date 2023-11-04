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
        private ParkingLot[] parkingLots;

        public StandardParklotBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public StandardParklotBoy(ParkingLot[] parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Car Fetch(Ticket ticket)
        {
            return parkingLot.Fetch(ticket);
        }

        public Ticket Park(Car car)
        {
            return parkingLot.Park(car);
        }
    }
}

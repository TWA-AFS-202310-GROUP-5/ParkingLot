using ParkingBoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoyStrategyContext
    {
        private IParkingBoyStrategy parkingBoyStrategy;

        public ParkingBoyStrategyContext(IParkingBoyStrategy strategy)
        {
            this.parkingBoyStrategy = strategy;
        }

        public string Park(string car)
        {
            return parkingBoyStrategy.Park(car);
        }

        public int ReturnIndexOfCarParkedLotOrDefaultZero(string ticket)
        {
            return parkingBoyStrategy.ReturnIndexOfCarParkedLotOrDefaultZero(ticket);
        }

        public string Fetch(string ticket)
        {
            return parkingBoyStrategy.Fetch(ticket);
        }
    }
}

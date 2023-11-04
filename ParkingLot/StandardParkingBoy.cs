using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class StandardParkingBoy
    {
        public Parking ParkingLot { get; set; }

        public StandardParkingBoy()
        {
            ParkingLot = new Parking();
        }

        public string Park(string car)
        {
            return ParkingLot.Park(car);
        }

        public string Fetch(string car)
        {
            return ParkingLot.Fetch(car);
        }
    }
}

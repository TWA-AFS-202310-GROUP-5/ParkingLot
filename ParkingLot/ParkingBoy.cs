using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public Parking ParkingLot { get; set; }

        public ParkingBoy()
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

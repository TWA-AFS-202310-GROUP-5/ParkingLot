using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy
    {
        public Parking ParkingLot { get; set; }

        public SmartParkingBoy()
        {
            ParkingLot = new Parking();
        }

        public string Park(string car)
        {
            return ParkingLot.Park(car,true);
        }

        public string Fetch(string car)
        {
            return ParkingLot.Fetch(car);
        }
    }
}

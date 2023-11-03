using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingBoy
    {
        private ParkingLot parkinglot;

        public ParkingBoy()
        {
        }

        public ParkingBoy(ParkingLot p)
        {
            Parkinglot = p;
        }

        public ParkingLot Parkinglot { get => parkinglot; set => parkinglot = value; }
    }
}

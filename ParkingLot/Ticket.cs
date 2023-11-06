using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class Ticket
    {
        private string carName;
        private string parkingLot;

        public Ticket(string car, string name)
        {
            CarName = car;
            parkingLot = name;
        }

        public string CarName
        {
            get { return carName; } set { carName = value; }
        }

        public string ParkingLot { get => parkingLot; set => parkingLot = value; }
    }
}

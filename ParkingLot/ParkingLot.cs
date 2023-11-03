using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Parking
    {
        private string car;

        public string Park(string car)
        {
            this.car = car;
            return "ticket";
        }

        public string Fetch(string ticket)
        {
            return "car";

        }
    
}
}

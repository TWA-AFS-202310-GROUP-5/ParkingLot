using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ParkingLot
{
    public class Parking
    {
        private Dictionary<string, string> ticket2car = new Dictionary<string, string>();

        public string Park(string car)
        {
            var ticket = "T-" + car;
            this.ticket2car.Add(ticket,car);
            return ticket;
        }

        public string Fetch(string ticket)
        {
            if (ticket2car.ContainsKey(ticket))
            {
                var car  = ticket2car[ticket];
                this.ticket2car.Remove(ticket);
                return car;
            }
            return "";
        }
    
}
}

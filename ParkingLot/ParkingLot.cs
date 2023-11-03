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
        private readonly int capacity = 10;

        public string Park(string car)
        {
            if (ticket2car.Count >= capacity)
            {
                return "";
            }
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
            else
            {
                throw new UnrecognizedTicketException("Unrecognized parking ticket");
            }
        }
    
}
}

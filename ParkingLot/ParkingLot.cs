using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingLot
    {
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>();

        public string Fetch(string ticket)
        {
            return ticket2Car.ContainsKey(ticket) ? ticket2Car[ticket] : string.Empty;
        }

        public string Park(string carName)
        {
            string ticket = $"Ticket-{carName}";
            ticket2Car[ticket] = carName;
            return ticket;
        }
    }
}

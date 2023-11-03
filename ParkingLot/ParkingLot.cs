using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingLot
    {
        private Dictionary<Ticket, string> ticket2Car = new Dictionary<Ticket, string>();

        public string Fetch(Ticket ticket)
        {
            if (ticket == null)
            {
                return string.Empty;
            }

            if (ticket.IsValid == true)
            {
                ticket.IsValid = false;
                return ticket2Car.ContainsKey(ticket) ? ticket2Car[ticket] : string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        public Ticket Park(string carName)
        {
            Ticket ticket = new Ticket(carName);
            ticket2Car[ticket] = carName;
            return ticket;
        }
    }
}

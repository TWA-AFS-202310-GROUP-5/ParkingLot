using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingLot
    {
        private readonly int capacity = 10;
        private Dictionary<Ticket, string> ticket2Car = new Dictionary<Ticket, string>();

        public int Capacity { get => capacity; }
        public Dictionary<Ticket, string> Ticket2Car { get => ticket2Car; set => ticket2Car = value; }

        public string Fetch(Ticket ticket)
        {
            if (ticket == null)
            {
                return string.Empty;
            }

            if (ticket.IsValid == true)
            {
                ticket.IsValid = false;
                return Ticket2Car.ContainsKey(ticket) ? Ticket2Car[ticket] : string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        public Ticket Park(string carName)
        {
            if (IsEmptyPositionLeft())
            {
                Ticket ticket = new Ticket(carName);
                Ticket2Car[ticket] = carName;
                return ticket;
            }
            else
            {
                return null;
            }
        }

        public bool IsEmptyPositionLeft()
        {
            return Ticket2Car.Count < Capacity;
        }
    }
}

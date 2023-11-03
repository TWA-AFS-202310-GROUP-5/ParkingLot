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
        private string name;

        private Dictionary<Ticket, string> ticket2Car = new Dictionary<Ticket, string>();
        public ParkingLot(string name)
        {
            Name = name;
        }

        public ParkingLot()
        {
            Name = "Defalt_Name";
        }

        public int Capacity { get => capacity; }
        public Dictionary<Ticket, string> Ticket2Car { get => ticket2Car; set => ticket2Car = value; }
        public string Name { get => name; set => name = value; }

        public string Fetch(Ticket ticket)
        {
            if (ticket == null || !Ticket2Car.ContainsKey(ticket) || ticket.IsValid == false)
            {
                throw new WrongTicketExceptoion("Unrecognized parking ticket.");
            }

            ticket.IsValid = false;
            return Ticket2Car[ticket];
        }

        public Ticket Park(string carName)
        {
            if (GetEmptyPosition() != 0)
            {
                Ticket ticket = new Ticket(carName, Name);
                Ticket2Car[ticket] = carName;
                return ticket;
            }
            else
            {
                throw new WrongTicketExceptoion("No available position.");
            }
        }

        public int GetEmptyPosition()
        {
            return Capacity - Ticket2Car.Count;
        }
    }
}

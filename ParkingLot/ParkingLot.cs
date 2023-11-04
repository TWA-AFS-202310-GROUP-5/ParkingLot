using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ParkingLot
{
    public class Parking
    {
/*        private Dictionary<string, string> ticket2car = new Dictionary<string, string>();
        private Dictionary<string, string> ticket2car = new Dictionary<string, string>();*/
        public List<Dictionary<string,string>> ticket2car { get; set; }
        private readonly int capacity = 10;

        public Parking()
        {
            ticket2car = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>()
            };
        }

        public string Park(string car)
        {
            if (ticket2car[0].Count >= capacity && ticket2car[1].Count >= capacity)
            {
                throw new NoAvailablePositionException("No available position");
            }

            string ticket;
            if (ticket2car[0].Count < 10)
            {
                ticket =  "ParkingLot1-" + car;
                ticket2car[0].Add(ticket, car);
            }
            else
            {
                ticket = "ParkingLot2-" + car;
                ticket2car[1].Add(ticket, car);
            }
            
            
            return ticket;
        }

        public string Fetch(string ticket)
        {
            if (ticket2car[0].ContainsKey(ticket) || ticket2car[1].ContainsKey(ticket))
            {
                string car1;
                string car2;
                ticket2car[0].TryGetValue(ticket,out car1);
                ticket2car[1].TryGetValue(ticket,out car2);
                ticket2car[0].Remove(ticket);
                ticket2car[1].Remove(ticket);
                return car1 ?? car2;
            }
            else
            {
                throw new UnrecognizedTicketException("Unrecognized parking ticket");
            }
        }
    
}
}

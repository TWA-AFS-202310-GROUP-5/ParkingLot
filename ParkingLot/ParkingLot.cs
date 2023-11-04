using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class ParkingLot
    {
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>(10);
        public string Fetch(string ticket)
        {
            if (!ticket2Car.ContainsKey(ticket))
            {
                return null;
            }

            string car = ticket2Car[ticket];
            ticket2Car.Remove(ticket);
            return car;
        }

        public string Park(string car)
        {
            if (ticket2Car.Count >= 10)
            {
                return null;
            }

            string ticket = "T-" + car;
            ticket2Car.Add(ticket, car);
            return ticket;
        }
    }
}

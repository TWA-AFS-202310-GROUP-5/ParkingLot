using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class ParkingLot
    {
        private Dictionary<string, Car> ticket2Car = new Dictionary<string, Car>();
        private int capacity = 10;
        public string ParkingLotId { get; }
        
        public bool IsFull => ticket2Car.Count >= capacity;
        public int EmptyNum => capacity - ticket2Car.Count;

        public ParkingLot()
        {
            ParkingLotId = Guid.NewGuid().ToString();
        }

        public ParkingLot(int capacity)
        {
            ParkingLotId = Guid.NewGuid().ToString();
            this.capacity = capacity;
        }

        public Car Fetch(Ticket ticket)
        {
            if (!ticket2Car.ContainsKey(ticket.TicketId))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            Car car = ticket2Car[ticket.TicketId];
            ticket2Car.Remove(ticket.TicketId);
            
            return car;
        }

        public Ticket Park(Car car)
        {
            if (ticket2Car.Count >= capacity)
            {
                throw new NoPositionException("No available position.");
            }

            Ticket ticket = new Ticket(ParkingLotId, car.ID);
            ticket2Car.Add(ticket.TicketId, car);
        
            return ticket;
        }
    }
}

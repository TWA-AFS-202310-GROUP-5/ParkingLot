namespace ParkingLot
{
    using System.Collections.Generic;

    public class ParkingLot
    {
        private int capacity;
        private Dictionary<Ticket, Car> ticketCarMap;

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
            ticketCarMap = new Dictionary<Ticket, Car>();
        }

        public int EmptyLotNum => capacity - ticketCarMap.Count;

        public Car Fetch(Ticket ticket)
        {
            Car car = ticketCarMap.GetValueOrDefault(ticket, null);
            if (car is null)
            {
                throw new InvalidTicketException();
            }

            ticketCarMap.Remove(ticket);

            return car;
        }

        public Ticket Park(Car car)
        {
            if (EmptyLotNum == 0)
            {
                throw new FullLotException();
            }

            Ticket ticket = new Ticket();

            ticketCarMap[ticket] = car;

            return ticket;
        }
    }
}

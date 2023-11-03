namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Data;

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
                throw new InvalidOperationException("Unrecognized parking ticket.");
            }

            ticketCarMap.Remove(ticket);

            return car;
        }

        public Ticket Park(Car car)
        {
            if (EmptyLotNum == 0)
            {
                throw new InvalidOperationException("No available position.");
            }

            Ticket ticket = new Ticket();

            ticketCarMap[ticket] = car;

            return ticket;
        }
    }
}

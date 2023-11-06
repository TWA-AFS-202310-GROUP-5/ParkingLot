namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Guid parkingLotId;
        private int capacity;
        private Dictionary<Ticket, Car> ticketCarMap;

        public ParkingLot(int capacity)
        {
            this.parkingLotId = Guid.NewGuid();
            this.capacity = capacity;
            ticketCarMap = new Dictionary<Ticket, Car>();
        }

        public int EmptyLotNum => capacity - ticketCarMap.Count;
        public Guid Id => parkingLotId;

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

            Ticket ticket = new Ticket(parkingLotId);

            ticketCarMap[ticket] = car;

            return ticket;
        }
    }
}

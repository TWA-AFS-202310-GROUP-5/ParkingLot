using System;

namespace ParkingLot
{
    public class Ticket
    {
        private readonly Guid ticketGuid;

        public Ticket()
        {
            ticketGuid = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            Ticket ticket = obj as Ticket;
            return ticketGuid.Equals(ticket.ticketGuid);
        }

        public override int GetHashCode()
        {
            return ticketGuid.GetHashCode();
        }
    }
}
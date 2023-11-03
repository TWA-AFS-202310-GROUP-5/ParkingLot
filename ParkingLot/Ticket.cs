using System;

namespace ParkingLot
{
    public class Ticket
    {
        private readonly Guid ticketGuid;
        private readonly Guid parkingLotId;

        public Ticket(Guid parkingLotId)
        {
            ticketGuid = Guid.NewGuid();
            this.parkingLotId = parkingLotId;
        }

        public Ticket()
        {
            ticketGuid = Guid.NewGuid();
        }

        public Guid ParkingLotId => parkingLotId;

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
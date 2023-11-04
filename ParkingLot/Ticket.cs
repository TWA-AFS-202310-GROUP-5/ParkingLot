using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class Ticket
    {
        public string? ParkingLotId { get; }
        public string TicketId { get; }
        public string? CarId { get; }
        public Ticket(string parkingLotId, string carId)
        {
            ParkingLotId = parkingLotId;
            TicketId = Guid.NewGuid().ToString();
            CarId = carId;
        }

        public Ticket()
        {
            TicketId = Guid.NewGuid().ToString();
        }
    }
}

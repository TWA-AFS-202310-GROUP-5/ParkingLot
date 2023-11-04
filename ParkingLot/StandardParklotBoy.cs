using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class StandardParklotBoy
    {
        protected List<ParkingLot> parkingLots = new List<ParkingLot>();

        public StandardParklotBoy(ParkingLot parkingLot)
        {
            this.parkingLots.Add(parkingLot);
        }

        public StandardParklotBoy(ParkingLot[] parkingLots)
        {
            this.parkingLots.AddRange(parkingLots);
        }

        public virtual Car Fetch(Ticket ticket)
        {
            try
            {                
                return parkingLots.Find(x => x.ParkingLotId == ticket.ParkingLotId).Fetch(ticket);
            }
            catch (Exception)
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }
        }

        public virtual Ticket Park(Car car)
        {
            try
            {
                return parkingLots.Find(x => !x.IsFull).Park(car);
            }
            catch (Exception)
            {
                throw new NoPositionException("No available position.");
            }
        }
    }
}

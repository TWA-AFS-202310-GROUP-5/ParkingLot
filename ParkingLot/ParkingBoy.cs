using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotManage.searchLotStrategy;

namespace ParkingLotManage
{
    public class ParkingBoy
    {
        protected List<ParkingLot> parkingLots = new List<ParkingLot>();
        protected ISearchStrategy _searchStrategy;

        public ParkingBoy(ParkingLot parkingLot, ISearchStrategy searchStrategy)
        {
            this.parkingLots.Add(parkingLot);
            this._searchStrategy = searchStrategy;
        }

        public ParkingBoy(ParkingLot[] parkingLots, ISearchStrategy searchStrategy)
        {
            this.parkingLots.AddRange(parkingLots);
            this._searchStrategy = searchStrategy;
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
                return _searchStrategy.SearchParkingLot(parkingLots).Park(car);
            }
            catch (Exception)
            {
                throw new NoPositionException("No available position.");
            }
        }
    }
}

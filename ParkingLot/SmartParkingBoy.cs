using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class SmartParkingBoy : StandardParklotBoy
    {
          
        public SmartParkingBoy(ParkingLot parkingLot, ISearchStrategy searchStrategy) : base(parkingLot, searchStrategy)
        {
            
        }

        public SmartParkingBoy(ParkingLot[] parkingLots,ISearchStrategy searchStrategy) : base(parkingLots, searchStrategy)
        {
        }

        public override Ticket Park(Car car)
        {
            try
            {
                return _searchStrategy.SearchParkingLot(parkingLots).Park(car);
            }catch (Exception)
            {
                throw new NoPositionException("No available position.");
            }
           
        }

    }
}

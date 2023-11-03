using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingBoy : StandardParkingBoy
    {
        public SmartParkingBoy(ParkingLot parkingLot) : base(parkingLot)
        {
        }

        public SmartParkingBoy(ParkingLot[] parkingLots) : base(parkingLots)
        {
        }

        public override Ticket Park(Car car)
        {
            try
            {
                return ParkingLots
                    .Values
                    .OrderByDescending(parkingLot => parkingLot.EmptyLotNum)
                    .First()
                    .Park(car);
            }
            catch (Exception)
            {
                throw new FullLotException();
            }
        }
    }
}

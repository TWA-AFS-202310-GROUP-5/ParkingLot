using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots;

        public ParkingBoy()
        {
            ParkingLots = new List<ParkingLot>();
        }

        public ParkingBoy(List<ParkingLot> p)
        {
            ParkingLots = p;
        }

        public List<ParkingLot> ParkingLots
        {
            get => parkingLots;
            set => parkingLots = value;
        }

        public void AddParkingLot(ParkingLot parkingLot)
        {
            ParkingLots.Add(parkingLot);
        }

        public Ticket Park(string carName)
        {
            return ParkingLots.Find(x => x.GetEmptyPosition() != 0).Park(carName);
        }

        public string Fetch(Ticket ticket)
        {
            foreach (var parkingLot in ParkingLots)
            {
                try
                {
                    return parkingLot.Fetch(ticket);
                }
                catch
                {
                    continue;
                }
            }

            throw new WrongTicketExceptoion("Unrecognized parking ticket.");
        }
    }
}

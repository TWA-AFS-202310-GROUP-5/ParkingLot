using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class StandardParkingBoy
    {
        private List<ParkingLot> parkingLots;

        public StandardParkingBoy()
        {
            ParkingLots = new List<ParkingLot>();
        }

        public StandardParkingBoy(List<ParkingLot> p)
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
            var firstAvailableParkingLot = GetFirstAvailableParkingLot();
            if (firstAvailableParkingLot == null)
            {
                throw new WrongTicketExceptoion("No available position.");
            }

            return firstAvailableParkingLot.Park(carName);
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

        public virtual ParkingLot GetFirstAvailableParkingLot()
        {
            return ParkingLots.FirstOrDefault(x => x.GetEmptyPosition() > 0);
        }
    }
}

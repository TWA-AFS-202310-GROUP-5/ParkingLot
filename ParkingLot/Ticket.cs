using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class Ticket
    {
        private string carName;
        private string parkingLot;
        private bool isValid;
        public Ticket(string car, string name)
        {
            Name = $"Ticket-{car}";
            isValid = true;
            parkingLot = name;
        }

        public string Name
        {
            get { return carName; } set { carName = value; }
        }

        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        public string ParkingLot { get => parkingLot; set => parkingLot = value; }
    }
}

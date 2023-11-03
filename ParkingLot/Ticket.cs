using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class Ticket
    {
        private string name;
        private bool isValid;
        public Ticket(string car)
        {
            Name = $"Ticket-{car}";
            isValid = true;
        }

        public string Name
        {
            get { return name; } set { name = value; }
        }

        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }
    }
}

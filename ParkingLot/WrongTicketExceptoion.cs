using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class WrongTicketExceptoion : Exception
    {
        public WrongTicketExceptoion(string message) : base(message)
        {
        }
    }
}

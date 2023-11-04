using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    [Serializable]
    public class WrongTicketException : Exception
    {
        public WrongTicketException()
        {
        }

        public WrongTicketException(string message) : base(message)
        {
        }
    }
}

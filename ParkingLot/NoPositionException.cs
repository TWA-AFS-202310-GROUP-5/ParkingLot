using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    [Serializable]
    public class NoPositionException : Exception
    {
        public NoPositionException()
        {
        }

        public NoPositionException(string message) : base(message)
        {
        }
    }
}

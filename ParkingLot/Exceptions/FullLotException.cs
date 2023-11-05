using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    public class FullLotException : Exception
    {
        public FullLotException() : base("No available position.")
        {
        }

        public FullLotException(string message) : base(message)
        {
        }

        public FullLotException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FullLotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

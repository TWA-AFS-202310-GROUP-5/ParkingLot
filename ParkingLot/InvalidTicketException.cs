using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    public class InvalidTicketException : Exception
    {
        public InvalidTicketException() : base("Unrecognized parking ticket.")
        {
        }

        public InvalidTicketException(string message) : base(message)
        {
        }

        public InvalidTicketException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTicketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

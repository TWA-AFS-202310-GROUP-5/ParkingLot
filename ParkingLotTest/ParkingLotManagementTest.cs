using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLotManagement;

namespace ParkingLotManagementTest
{
    public class ParkingLotManagementTest
    {
        [Theory]
        [InlineData("Car")]
        public void Should_return_ticket_when_user_parking_given_car(string carName)
        {
            ParkingLot parkingLot = new ParkingLot();
            var ticket = parkingLot.Park(carName);

            var carReceived = parkingLot.Fetch(ticket);

            Assert.Equal(carName, carReceived);
        }
    }
}

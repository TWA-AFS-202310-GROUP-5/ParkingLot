﻿using System;
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
        [InlineData("Car2")]
        public void Should_return_ticket_when_costumer_parking_given_car(string carName)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticket = parkingLot.Park(carName);

            string carReceived = parkingLot.Fetch(ticket);

            Assert.Equal(carName, carReceived);
        }

        [Theory]
        [InlineData("Car1", "Car2")]
        public void Should_return_correct_ticket_when_many_costumers_parking_given_car(string carName1, string carName2)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticket1 = parkingLot.Park(carName1);
            Ticket ticket2 = parkingLot.Park(carName2);

            string carReceived1 = parkingLot.Fetch(ticket1);
            string carReceived2 = parkingLot.Fetch(ticket2);

            Assert.Equal($"Ticket-{carName1}", ticket1.Name);
            Assert.Equal($"Ticket-{carName2}", ticket2.Name);
            Assert.Equal(carName1, carReceived1);
            Assert.Equal(carName2, carReceived2);
        }

        [Theory]
        [InlineData("Car1", "Car2")]
        public void Should_return_empty_when_costumer_using_incorrect_ticket(string carNameCorrect, string carNameFalse)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticketCorrect = parkingLot.Park(carNameCorrect);
            Ticket ticketFalse = new Ticket(carNameFalse);

            string carReceived = parkingLot.Fetch(ticketFalse);

            Assert.Equal(string.Empty, carReceived);
        }

        [Theory]
        [InlineData("Car1")]
        public void Should_return_empty_when_costumer_using_null_ticket(string carNameCorrect)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticketCorrect = parkingLot.Park(carNameCorrect);
            Ticket ticketNull = null;

            string carReceived = parkingLot.Fetch(ticketNull);

            Assert.Equal(string.Empty, carReceived);
        }

        [Theory]
        [InlineData("Car")]
        [InlineData("Car2")]
        public void Should_return_empty_when_costumer_fetching_car_with_used_ticket(string carName)
        {
            ParkingLot parkingLot = new ParkingLot();
            Ticket ticket = parkingLot.Park(carName);

            string carReceived = parkingLot.Fetch(ticket);
            carReceived = parkingLot.Fetch(ticket);
            Assert.Equal(string.Empty, carReceived);
        }
    }
}

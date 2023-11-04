﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class ParkingLot
    {
        private Dictionary<string, string> ticket2Car = new Dictionary<string, string>();
        private int capacity = 10;

        public ParkingLot()
        {
        }

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
        }

        public string Fetch(string ticket)
        {
            if (!ticket2Car.ContainsKey(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            string car = ticket2Car[ticket];
            ticket2Car.Remove(ticket);
            return car;
        }

        public string Park(string car)
        {
            if (ticket2Car.Count >= capacity)
            {
                throw new NoPositionException("No available position.");
            }

            string ticket = "T-" + car;
            ticket2Car.Add(ticket, car);
            return ticket;
        }
    }
}

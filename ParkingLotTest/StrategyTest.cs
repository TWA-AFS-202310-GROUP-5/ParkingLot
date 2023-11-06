namespace ParkingLotTest
{
    using ParkingLot;
    using ParkingBoy;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using System.Net.Sockets;

    public class StrategyTest
    {
        // {fisrt lot's parked number}F {second lot's parked number}S
        [Fact] //3F2S
        public void Should_park_a_car_to_first_parkinglot_when_park_a_car_given_first_lot_has_more_cars_parked_chose_standardStrategy()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot();
            List<string> cars1 = Enumerable.Range(1, 3)
                .Select(i => i.ToString())
                .ToList();
            cars1.ForEach(car => parkingLot1.Park(car));

            ParkingLot parkingLot2 = new ParkingLot();
            List<string> cars2 = Enumerable.Range(1, 2)
                .Select(i => i.ToString())
                .ToList();
            cars2.ForEach(car => parkingLot2.Park(car));

            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot1, parkingLot2 };
            IParkingBoyStrategy standard = new StandardParkingBoyStrategy(parkingLots);
            ParkingBoyStrategyContext standardContext = new ParkingBoyStrategyContext(standard);

            string car = "parkthiscar";
            string ticket = standardContext.Park(car);

            string carFetch = parkingLots[0].Fetch(ticket);

            Assert.Equal(car, carFetch);
        }

        [Fact] //3F2S
        public void Should_park_a_car_to_second_parkinglot_when_park_a_car_given_first_lot_has_more_cars_parked_chose_smartStrategy()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot();
            List<string> cars1 = Enumerable.Range(1, 3)
                .Select(i => i.ToString())
                .ToList();
            cars1.ForEach(car => parkingLot1.Park(car));

            ParkingLot parkingLot2 = new ParkingLot();
            List<string> cars2 = Enumerable.Range(1, 2)
                .Select(i => i.ToString())
                .ToList();
            cars2.ForEach(car => parkingLot2.Park(car));

            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot1, parkingLot2 };
            IParkingBoyStrategy smart = new SmartParkingBoyStrategy(parkingLots);
            ParkingBoyStrategyContext smartContext = new ParkingBoyStrategyContext(smart);

            string car = "parkthiscar";
            string ticket = smartContext.Park(car);

            string carFetch = parkingLots[1].Fetch(ticket);

            Assert.Equal(car, carFetch);
        }

        [Fact] //3F8S
        public void Should_park_a_car_to_first_parkinglot_when_park_a_car_given_second_lot_has_more_cars_parked_chose_standardStrategy()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot();
            List<string> cars1 = Enumerable.Range(1, 3)
                .Select(i => i.ToString())
                .ToList();
            cars1.ForEach(car => parkingLot1.Park(car));

            ParkingLot parkingLot2 = new ParkingLot();
            List<string> cars2 = Enumerable.Range(1, 8)
                .Select(i => i.ToString())
                .ToList();
            cars2.ForEach(car => parkingLot2.Park(car));

            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot1, parkingLot2 };
            IParkingBoyStrategy standard = new StandardParkingBoyStrategy(parkingLots);
            ParkingBoyStrategyContext standardContext = new ParkingBoyStrategyContext(standard);
            string car = "parkthiscar";
            string ticket = standardContext.Park(car);

            string carFetch = parkingLots[0].Fetch(ticket);

            Assert.Equal(car, carFetch);
        }

        [Fact] //3F8S
        public void Should_park_a_car_to_first_parkinglot_when_park_a_car_given_second_lot_has_more_cars_parked_chose_smartStrategy()
        {
            //given
            ParkingLot parkingLot1 = new ParkingLot();
            List<string> cars1 = Enumerable.Range(1, 3)
                .Select(i => i.ToString())
                .ToList();
            cars1.ForEach(car => parkingLot1.Park(car));

            ParkingLot parkingLot2 = new ParkingLot();
            List<string> cars2 = Enumerable.Range(1, 8)
                .Select(i => i.ToString())
                .ToList();
            cars2.ForEach(car => parkingLot2.Park(car));

            List<ParkingLot> parkingLots = new List<ParkingLot> { parkingLot1, parkingLot2 };
            IParkingBoyStrategy smart = new SmartParkingBoyStrategy(parkingLots);
            ParkingBoyStrategyContext smartContext = new ParkingBoyStrategyContext(smart);

            string car = "parkthiscar";
            string ticket = smartContext.Park(car);

            string carFetch = parkingLots[0].Fetch(ticket);

            Assert.Equal(car, carFetch);
        }
    }
}
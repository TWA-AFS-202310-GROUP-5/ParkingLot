using System;

namespace ParkingLot
{
    public class Car
    {
        private readonly Guid carGuid;

        public Car()
        {
            carGuid = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            Car car = obj as Car;
            return carGuid.Equals(car.carGuid);
        }

        public override int GetHashCode()
        {
            return carGuid.GetHashCode();
        }
    }
}

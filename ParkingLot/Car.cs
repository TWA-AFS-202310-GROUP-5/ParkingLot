using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManage
{
    public class Car
    {
        public string ID { get; }

        public Car()
        {
            this.ID = Guid.NewGuid().ToString();
        }
    }
}

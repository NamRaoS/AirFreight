using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFreight
{
    public class OrderSchedule
    {
        public Order? order { get; set; }
        public FlightSchedule? flightSchedule { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFreight
{
    public class FlightSchedule
    {
        public string? flightNumber { get; set; }
        public string? departureCity  { get; set; }
        public string? arrivalCity { get; set; }
        public string? day { get; set; }
        public int capacity { get; set; }

    }
}

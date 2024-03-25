using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirFreight
{
    public class Flight
    {
        List<string> arrivalCities = new List<string> { "YYZ", "YYC", "YVR" };
        List<string> departureCities = new List<string> { "YUL" };
        const int days = 2;

        public List<FlightSchedule> GetFlightSchedule()
        {
            List<FlightSchedule> schedule = new List<FlightSchedule>();
            int tempFlightNumber = 0;
            for (int i = 1; i <= days; i++)
            {
                foreach (string depCity in departureCities)
                {
                    foreach (string arrCity in arrivalCities)
                    {
                        tempFlightNumber++;
                        FlightSchedule schedule2 = new FlightSchedule();
                        schedule2.flightNumber = tempFlightNumber.ToString();
                        schedule2.departureCity = depCity;
                        schedule2.arrivalCity = arrCity;
                        schedule2.day = "day" + i;
                        schedule.Add(schedule2);
                    }
                }
            }

            return schedule;
        }

        public Orders LoadOrders()
        {
            using (StreamReader r = new StreamReader("D:\\Namratha\\AirFreight\\AirFreight\\orders.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Orders>(json);

            }
        }

        public List<OrderSchedule> GenerateOrderSchedule()
        {
            List<OrderSchedule> orderSchedule = new List<OrderSchedule>();
            bool isOrderScheduled;
            List<FlightSchedule> flightSchedules = GetFlightSchedule();
            Orders orders = LoadOrders();

            List<Order>? orderList = orders.order;

            foreach (Order orderItem in orderList)
            {
                isOrderScheduled = false;
                string destination = orderItem.destination;
                foreach (FlightSchedule flightSchedule in flightSchedules)
                {
                   if (flightSchedule.arrivalCity == destination)
                    {
                        if(flightSchedule.capacity < 20)
                        {
                            orderSchedule.Add(new OrderSchedule{order = orderItem, flightSchedule = flightSchedule });
                            flightSchedule.capacity++;
                            isOrderScheduled = true;
                            break;
                        }
                    }
                                    
                }
                if (!isOrderScheduled)
                    orderSchedule.Add(new OrderSchedule { order = orderItem, flightSchedule = new FlightSchedule { flightNumber = "Not Scheduled" } });


            }
            return orderSchedule;
        }
    }
}

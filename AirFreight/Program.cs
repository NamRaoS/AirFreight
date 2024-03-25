using AirFreight;

class Program
{
    static void Main(string[] args)
    {
        Flight flight = new Flight();
        string output = "";

        List<FlightSchedule> schedule = flight.GetFlightSchedule();
        foreach (FlightSchedule scheduleItem in schedule)
        {
            output = "Flight:" + scheduleItem.flightNumber + " departure:" + scheduleItem.departureCity + ", arrival:" + scheduleItem.arrivalCity + ", " + scheduleItem.day;
            Console.WriteLine(output);
        }

        List<OrderSchedule> orderSchedules = flight.GenerateOrderSchedule();
        foreach(OrderSchedule scheduleItem in orderSchedules)
        {
            output = "Order: " + scheduleItem.order.orderId + ", flightNumber: " + scheduleItem.flightSchedule.flightNumber +  (scheduleItem.flightSchedule.departureCity != null ? ", departure: " + scheduleItem.flightSchedule.departureCity + ", arrival:" + scheduleItem.flightSchedule.arrivalCity + ", day:" + scheduleItem.flightSchedule.day : " ");
            Console.WriteLine(output);
        }
    }
}


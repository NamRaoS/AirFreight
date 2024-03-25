using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFreight
{
    public class Orders
    {
        public List<Order>? order { get; set; }
    }

    public class Order
    {
        public string? orderId { get; set; }
        public string? destination { get; set; }
    }

}

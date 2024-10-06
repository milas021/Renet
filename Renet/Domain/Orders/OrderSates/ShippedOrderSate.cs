using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.OrderSates {
    public class ShippedOrderSate : OrderStateBase {
        public int DeliverCode { get; set; }
        public override OrderStateBase Deliver(User actor) {
            return new DeliveredOrderSate();
        }
    }
}

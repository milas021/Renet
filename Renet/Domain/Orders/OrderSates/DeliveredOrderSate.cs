using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.OrderSates {
    public class DeliveredOrderSate : OrderStateBase {
        public override OrderStateBase Close(User actor) {
            return new DoneOrderState();
        }
    }
}

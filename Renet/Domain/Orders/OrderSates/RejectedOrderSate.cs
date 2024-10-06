using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.OrderSates {
    public class RejectedOrderSate : OrderStateBase {
        public override OrderStateBase Close(User actor) {
            return new DoneOrderState();        
        }
    }
}

using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.OrderSates {
    public class ProcessingOrderSate : OrderStateBase {
        public override OrderStateBase Confirm( User actor ) {
            //do some logic 
            if (actor.Role != UserRole.Admin) {
                throw new Exception("you cant do this action");
            }

            return new PreparingOrderState();
        }
    }
}

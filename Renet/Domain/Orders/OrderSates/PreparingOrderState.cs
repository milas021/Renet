using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders.OrderSates {
    public class PreparingOrderState : OrderStateBase {
        public override OrderStateBase Reject(User actor) {

            //do bussiness logic ,domain event and ...
            return new RejectedOrderSate();
        }

        public override OrderStateBase SendToPost(User actor) {

            return new ShippedOrderSate();
        }
    }
}

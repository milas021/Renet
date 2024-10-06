using Domain.Users;

namespace Domain.Orders.OrderSates;
public class ProcessingOrderSate : OrderStateBase {
    public override OrderStateBase Confirm(User actor) {
        //do some logic 
        if (actor.Role != UserRole.Admin) {
            throw new Exception("you cant do this action");
        }

        return new PreparingOrderState();
    }





    public override OrderStateBase Reject(User actor) {
        return new RejectedOrderSate();
    }
}

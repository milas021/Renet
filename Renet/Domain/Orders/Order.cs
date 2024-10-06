using Domain.Orders.OrderSates;
using Domain.Payments;
using Domain.Users;

namespace Domain.Orders {
    public class Order {
        public Order() {
            Id = Guid.NewGuid();
            States.Add(new ProcessingOrderSate());

        }
        public Guid Id { get; private set; }
        public int Number { get; private set; }
        public User User { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public IEnumerable<OrderItem> OrderItems { get; private set; }

        public Payment Payment { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<OrderStateBase> States { get; private set; } = new List<OrderStateBase>();
        public OrderStateBase LastState => States.OrderByDescending(x => x.CreateDate).FirstOrDefault();

        public void Confirm(User actor) {
            //send sms if totalPrize > 100,000,00
            if (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 17) {
                States.Add(LastState.Confirm(actor));

            }
        }
    }

    public enum OrderStatus {
        Processing = 1,
        Preparing = 2,
        Shipped = 3,
        Delivered = 4,
        Rejected = 5

    }
}

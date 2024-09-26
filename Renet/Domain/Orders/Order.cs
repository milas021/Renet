using Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public IEnumerable<OrderItem> OrderItems { get; private set; }
        public Guid? PaymentId { get; private set; } 
        public Payment Payment { get; private set; }
        public OrderStatus Status { get; private set; }
    }

    public enum OrderStatus
    {

    }
}

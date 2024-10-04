using Domain.Payments;
using Domain.Users;
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
        public int Number { get;private set; }
        public User User { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public IEnumerable<OrderItem> OrderItems { get; private set; }
      
        public Payment Payment { get; private set; }
        public OrderStatus Status { get; private set; }
    }

    public enum OrderStatus
    {
        Processing = 1 ,
        Preparing = 2 ,
        Shipped =3 ,
        Delivered = 4

    }
}

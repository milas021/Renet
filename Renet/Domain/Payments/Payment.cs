using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payments
{
    public class Payment
    {
        public Guid Id { get;private set; }
        public Guid OrderId { get;private set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get;private set; }
        public decimal Amount { get;private set; }
        public PaymentMethod PaymentMethod { get;private set; }
        public PaymentStatus PaymentStatus { get;private set; }

    }

    public enum PaymentMethod
    {

    }

    public enum PaymentStatus
    {

    }
}

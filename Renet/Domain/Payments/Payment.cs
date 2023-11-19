using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payments
{
    public class Payment
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string TraceCode { get; set; }
        public Guid UserId { get; set; }

    }
}

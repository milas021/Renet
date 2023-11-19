using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Baskets
{
    public class Basket
    {
        public Guid Id { get; set; }
        public double TotalPrice { get; set; }
        public double FinalPrice { get; set; }
        public Guid UserId { get; set; }
    }
}

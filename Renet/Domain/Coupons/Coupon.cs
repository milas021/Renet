using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Coupons
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int DiscountPercent { get; set; }
        public bool IsActive { get; set; }

    }
}

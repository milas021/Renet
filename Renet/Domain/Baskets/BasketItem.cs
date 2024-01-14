using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Baskets
{
    public class BasketItem
    {
        public BasketItem(Guid productId, int count)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            if (count <= 0)
                throw new Exception("تعداد محصول نمیتواند کوچکتر از یک باشد");

            Count = count;
        }

        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Count { get; private set; }        
        public double UnitPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Baskets
{
    public class BasketItem
    {
        private BasketItem() { }
        public BasketItem(Guid productId, int count)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Count = count;
        }

        public Guid Id { get; private set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
    }
}

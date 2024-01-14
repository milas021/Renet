using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Baskets
{
    public class Basket
    {
        public Basket(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
        }
        public Guid Id { get; private set; }
        public double FinalPrice { get;private set; }
        public Guid UserId { get;private set; }
        public List<BasketItem> Items { get;private set; } = new List<BasketItem>();

        public void AddBasketItem(BasketItem item)
        {
            Items.Add(item);
           
        }
    }


}

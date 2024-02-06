using Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Baskets
{
    public class Basket
    {
        private Basket() { }
        public Basket(Guid userId)
        {
            UserId = userId;
            Id = Guid.NewGuid();
        }
        public Guid Id { get;private set; }
        public Guid UserId { get;private set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();


        [Timestamp]
        public byte[] RowVersion { get; set; }

        public void AddToBasket(BasketItem item) 
        {
            Items.Add(item);
        }
    }


}

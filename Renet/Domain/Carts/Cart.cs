using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Carts {
    public class Cart {
        private Cart() { }
        public Cart(Guid userId) {
            Id = Guid.NewGuid();
            UserId = userId;
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedDate { get; private set; }


        public List<CartItem> CartItems { get; private set; } = new List<CartItem>();

        public CartItem GetCartItemByVariantId(Guid variantId) {
            var result = CartItems.SingleOrDefault(x => x.VariantId == variantId);
            return result;
        }

        //public void AddCartItem(Guid variant) {

        //    var item = GetCartItemByVariantId(variant);
        //    if (item == null) {

        //        item = new CartItem(variant);
        //        CartItems.Add(item);
        //    }
        //    else {
        //        item.AddQuantity();
        //    }
        //}
    }
}

using Domain.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
  public  interface ICartItemRepository : IRepository
    {
        Task<CartItem> GetCartItemByVariantAndCart(Guid variantId , Guid cartId);
        Task Add (CartItem cartItem);
    }
}

using Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IBasketRepository : IRepository
    {
        Task Add(Basket basket);
        Task<Basket> GetByUserId(Guid userId);

        Task AddBasketItemToBasket(Basket basket , BasketItem item);

       
    }
}

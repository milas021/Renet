using Domain.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface ICartRepository : IRepository
    {
        Task<Cart> GetByUserId(Guid userId);
        Task Add(Cart cart);
    }
}

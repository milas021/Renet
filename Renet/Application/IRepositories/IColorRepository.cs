using Domain.Products;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IColorRepository : IRepository
    {
        Task<Color> GetById(Guid id);
    }
}

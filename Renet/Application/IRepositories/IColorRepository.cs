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
        Task AddColor(Color color);
        Task<bool> AnyColor(string name);
        Task<IEnumerable<Color>> GetColors(int page, int pageSize);
    }
}

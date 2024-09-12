using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task Add(Category category);
        Task<bool> IsExist(string name);
        Task<Category> GetById(Guid id);
    }
}

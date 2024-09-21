using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetById(Guid id);
        Task<User> GetByUserName(string userName);
        Task<bool> IsUserExist(string userName);
        Task<IEnumerable<User>> GetAllUser(int page, int pageSize);
        Task<int> GetAllUserCount();

        Task Add(User user);
    }
}

using Application.IRepositories;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : Repository, IUserRepository {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task Add(User user)
        {
            await _context.AddAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUser(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var result = await _context.Users
                 .Where(x => x.Role == UserRole.Customer)
                 .Skip(skip)
                 .Take(pageSize)
                 .ToListAsync();

            return result;
        }

        public async Task<int> GetAllUserCount()
        {
           var count = await _context.Users.Where(x=>x.Role == UserRole.Customer).CountAsync();
            return count;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<User> GetByMobile(string mobile) {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Mobile == mobile);
            return user;
        }

        public async Task<User> GetByUserName(string userName)
        {
            var result = await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName);
            return result;
        }

        public async Task<bool> IsUserExist(string userName)
        {
            var result = await _context.Users.AnyAsync(x => x.UserName == userName);
            return result;
        }

        public async Task<bool> IsUserExistByMobile(string mobile) {
            var result = await _context.Users.AnyAsync(x => x.Mobile == mobile);
            return result;
        }
    }
}

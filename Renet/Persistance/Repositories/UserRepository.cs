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
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x=>x.Id == id);
            return user;
        }
    }
}

using Application.IRepositories;
using Domain.Tokens;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class TokenRepository : Repository, ITokenRepository
    {
        public TokenRepository(AppDbContext context) : base(context)
        {
        }

        public async Task Add(Token token)
        {
            await _context.Tokens.AddAsync(token);
        }

        public async Task Delete(Token token)
        {
            _context.Tokens.Remove(token);
        }

        public async Task<Token> Get(Guid userId, string os, string browser)
        {
            var result = await _context.Tokens.SingleOrDefaultAsync(x => 
            x.Id == userId 
            && x.UserAgent.OS == os 
            && x.UserAgent.Browser == browser);

            return result;
        }

        public async Task<Token> Get(string refreshToken)
        {
            var result = await _context.Tokens.SingleOrDefaultAsync(x => x.RefreshToken == refreshToken);
            return result;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

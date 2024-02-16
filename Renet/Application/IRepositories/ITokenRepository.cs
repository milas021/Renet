using Domain.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface ITokenRepository : IRepository
    {
        Task<Token> Get(Guid userId, string os, string browser);
        Task Add(Token token);
    }
}

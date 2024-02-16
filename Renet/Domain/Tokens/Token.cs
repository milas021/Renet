using Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tokens
{
    public class Token
    {
        private Token() { }
        public Token(Guid userId ,string refreshToken , UserAgent userAgent)
        {
            Id = Guid.NewGuid();
            UserID = userId;
            UserAgent = userAgent;
            RefreshToken = refreshToken;

            LifeTime = 24;
            Created = DateTime.Now;
            Expired = Created.AddHours(LifeTime);
        }

        public Guid Id { get; private set; }

        public Guid UserID { get; private set; }

        public UserAgent UserAgent { get; private set; }

        public string RefreshToken { get; private set; }

        public DateTime Created { get; private set; }

        public DateTime Expired { get; private set; }

        public int LifeTime { get; private set; }

        public void UpdateToken(string refreshToken)
        {
            LifeTime = 24;
            Created = DateTime.Now;
            Expired = Created.AddHours(LifeTime);
            RefreshToken = refreshToken;
            
        }


    }
}

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
        public Token()
        {
            LifeTime = 24;
            Created = DateTime.Now;
            Expired = Created.AddHours(LifeTime);
        }

        public Guid Id { get; set; }

        public Guid UserID { get; set; }

        public UserAgent UserAgent { get; set; }

        public string RefreshToken { get; set; }

        public DateTime Created { get;private set; } 

        public DateTime Expired { get; set; }

        public int LifeTime { get; set; }

        
    }
}

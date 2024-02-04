using Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get;private set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
       


    }
}

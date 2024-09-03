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
        private User() { }
        public User(string userName , string hashedPassword)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = hashedPassword;
            Role = UserRole.Customer;
        }
        public Guid Id { get;private set; }
        public string UserName { get;private set; }
        public string Password { get;private set; }
        public string? Email { get; set; }
        public UserRole Role { get;private set; }
       
    }
    public enum UserRole
    {
        Admin,
        Customer
    }
}

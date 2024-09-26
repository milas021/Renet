using Domain.Baskets;
using Domain.Common;
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
        public User(string userName, string hashedPassword)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = hashedPassword;
            Role = UserRole.Customer;
        }
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Mobile { get; private set; }
        public string? Email { get; private set; }
        public Province? Province { get; private set; }
        public string? City { get; private set; }
        public string? Address { get; private set; }
        public string? PostalCode { get; private set; }
        public UserRole Role { get; private set; }

    }
    public enum UserRole
    {
        Admin = 1,
        Customer = 2
    }
}

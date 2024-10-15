using Domain.Common;

namespace Domain.Users {
    public class User {
        private User() {
            Id = Guid.NewGuid();
            Role = UserRole.Customer;
            IsMobileConfirmed = false;
        }
        //todo : reactor public constructor
        public User(string userName, string hashedPassword) {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = hashedPassword;
            Role = UserRole.Customer;
            IsMobileConfirmed = false;
        }

        public static User CreatByMobile(string mobile) {
            var user = new User() {
                Mobile = mobile,
            };

            return user;
        }
        public Guid Id { get; private set; }
        public string? UserName { get; private set; }
        public string? Password { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Mobile { get; private set; }
        public string? Email { get; private set; }
        public Province? Province { get; private set; }
        public string? City { get; private set; }
        public string? Address { get; private set; }
        public string? PostalCode { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsMobileConfirmed { get; private set; }

        public void ConfirmMobile() {
            IsMobileConfirmed = true;
        }

    }
    public enum UserRole {
        Admin = 1,
        Customer = 2
    }
}

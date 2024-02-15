using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserData : CommandResponseBase
    {
        public UserDto  User  { get; set; }
        public TokenDto Tokens { get; set; }
    }
}

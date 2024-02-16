using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class RegistrationCommand :CommandBase
    {
        public string   UserName { get; set; }
        //public string Email { get; set; }
        public string Password { get; set; }
    }
}

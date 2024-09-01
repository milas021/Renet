using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message = "عملیات با خطا مواجه شد") : base(message) 
        {
            
        }
    }
}

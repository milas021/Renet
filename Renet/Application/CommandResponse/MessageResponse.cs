using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandResponse
{
    public class MessageResponse :CommandResponseBase
    {
        public string Message { get; set; }
        public static MessageResponse CreateSuccesMessage(string message="عملیات با موفقیت انجام شد")
        {
            return new MessageResponse { Message = message };
        }

        public static MessageResponse CreateErrorMessage(string message = "عملیات با شکست مواجه شد")
        {
            return new MessageResponse { Message = message };
        }

    }
}

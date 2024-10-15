using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;
public class SendOTPDto {
    public long OtpId { get; set; }
    public Guid UserId { get; set; }
}

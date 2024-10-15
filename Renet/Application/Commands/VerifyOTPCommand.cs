using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands;
public class VerifyOTPCommand {
    public string OTPCode { get; set; }
    public long OtpId { get; set; }
    public Guid UserId { get; set; }
}

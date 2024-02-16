using Domain.Tokens;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAParser;



namespace Infrastructure
{
    public class Utilities
    {
        public static  Domain.Tokens.UserAgent GetUserAgentData(StringValues userAgentHeader)
        {
            var uaParser = Parser.GetDefault();
            var clietnInfo = uaParser.Parse(userAgentHeader);

            return new Domain.Tokens.UserAgent
            {
                OS = clietnInfo.OS.ToString(),
                Browser = clietnInfo.UA.ToString()
            };
        }
    }
}

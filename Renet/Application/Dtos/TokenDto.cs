using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class TokenDto
    {
        //todo change structure of token dto so that express expired date and life time for access token
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expired { get; set; }
        public int LifeTime { get; set; }

        
    }
}

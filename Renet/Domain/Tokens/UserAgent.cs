using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tokens
{
    public class UserAgent
    {
        public Guid Id { get; set; }
        public string OS { get; set; }

        public string Browser { get; set; }
    }
}

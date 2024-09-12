using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Color
    {
        public Color(string name , string hexCode)
        {
            Id = Guid.NewGuid();
            Name = name;
            HexCode = hexCode;
        }
        public Guid Id { get;private set; }
        public string  Name { get;private set; }
        public string HexCode { get;private set; }
    }
}


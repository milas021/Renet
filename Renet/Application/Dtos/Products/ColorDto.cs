using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Products
{
    public class ColorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands
{
    public class AddProductImageCommand
    {
      
        public string Name { get; set; }
        public bool IsMainImage { get; set; }
    }
}

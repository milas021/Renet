using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands
{
    public class AddVariantsCommand
    {
       
        public Guid ColorId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}

using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public  class AddProductToBasketCommand : CommandBase
    {
        public Guid UserId { get; set; }
        public Guid VariantId { get; set; }
       

    }
}

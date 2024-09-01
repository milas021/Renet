using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands
{
    public class AddCategoryCommand :CommandBase
    {
        public string Name { get; set; }
    }
}

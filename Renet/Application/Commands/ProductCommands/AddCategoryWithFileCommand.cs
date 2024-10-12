using Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands;
public class AddCategoryWithFileCommand : CommandBase {

    public string Name { get; set; }
    public IFormFile Image { get; set; }
    public IFormFile Icon { get; set; }
}

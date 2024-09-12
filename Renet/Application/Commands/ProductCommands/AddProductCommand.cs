using Domain.Products;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands
{
    public class AddProductCommand :CommandBase
    {
       
        public string Name { get; set; }
        public string EnglishName { get; set; }

        public string Guaranty { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }

        public Guid CategoryId { get; set; }
        public IEnumerable<AddArticleCommand> Articles { get; set; }
        public IEnumerable<AddVariantsCommand> Variants { get; set; }
        public IEnumerable<AddProductImageCommand> Images { get; set; }
        public IEnumerable<AddFeatureCommand> Features { get; set; }
    }
}

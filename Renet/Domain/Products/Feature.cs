using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Feature
    {
        public Feature(string name  , string value)
        {
            Id = Guid.NewGuid();
            Name = name;
            Value = value;
        }
        public Guid Id { get;private set; }
        public string Name { get;private set; }
        public string Value { get;private set; }
        public Guid ProductId { get; set; }
    }
}

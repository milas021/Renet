using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class SimpleProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }

    }

    public class PaginationDto<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int TotalRecord { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class SimpleProductAdminDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }

    }

    public class PaginationDto<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int TotalRecord { get; set; }
    }

}

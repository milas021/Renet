using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BasketDto
    {
        public List<BasketItemDto> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Orders {
    public class BasicOrderDto {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProvince { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
    }
}

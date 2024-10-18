using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Products;
public class SimpleProductCustomerDto {

    public Guid Id { get; set; }
    public string MainImage { get; set; }
    public List<string> HexColor { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public string Brand { get; set; }
}

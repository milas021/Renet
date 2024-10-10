using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface IVariantRepository :IRepository {
    Task<IEnumerable<ProductVariant>> GetVariantsByProductId(Guid productId);
}

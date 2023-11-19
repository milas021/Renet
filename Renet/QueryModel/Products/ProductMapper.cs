
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QueryModel.Products
{
    public static class ProductMapper
    {
        public static ProductItemDto ToDto(this Product product)
        {
            var dto = new ProductItemDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                MainPicture = product.Pictures.Where(x => x.IsMainPicture).FirstOrDefault().Name ,
                
            };

            return dto;
        }
    }
}

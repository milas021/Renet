using Application.Dtos;
using Application.IRepositories;
using Domain.Baskets;
using Domain.Products;

namespace Application.Mappers
{
    public static  class BasketItemMapper
    {
        public static async Task<BasketItemDto> ToDto(this BasketItem item , IProductRepository productRepository)
        {
            var product = await productRepository.GetById(item.ProductId);
            var dto = new BasketItemDto()
            {
                Count = item.Count,
                ProductId = item.ProductId,
                Name = product.Name,
                Price = product.Price,
                
            };
            return dto;
        }
    }
}

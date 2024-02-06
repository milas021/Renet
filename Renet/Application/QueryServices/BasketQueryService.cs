using Application.CommandHandlers;
using Application.Dtos;
using Application.IRepositories;
using Application.Mappers;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryServices
{
    public class BasketQueryService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productsRepository;

        public BasketQueryService(IBasketRepository basketRepository, IProductRepository productsRepository)
        {
            _basketRepository = basketRepository;
            _productsRepository = productsRepository;
        }

        public async Task<BasketDto> GetUserBasket(Guid userId)
        {
            var basket = await _basketRepository.GetByUserId(userId);
            List<Product> products = new List<Product>();
            foreach (var items in basket.Items)
            {
                var product = await _productsRepository.GetById(items.ProductId);
                products.Add(product);
            }

            var dto = basket.ToDto(_productsRepository);

            return dto;


        }
    }
}

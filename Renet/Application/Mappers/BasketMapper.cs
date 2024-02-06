using Application.Dtos;
using Application.IRepositories;
using Domain.Baskets;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class BasketMapper
    {
        public static BasketDto ToDto(this Basket basket, IProductRepository productRepositories)
        {
            var dto = new BasketDto
            {
                Items = basket.Items.Select(x => x.ToDto(productRepositories).Result).ToList(),

            };

            dto.TotalPrice = dto.Items.Sum(x => x.Price * x.Count);

            return dto;
            
        }
    }
}

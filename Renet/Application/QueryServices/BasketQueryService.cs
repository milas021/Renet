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

        private readonly IProductRepository _productsRepository;

        public BasketQueryService( IProductRepository productsRepository)
        {
            
            _productsRepository = productsRepository;
        }

        public async Task<BasketDto> GetUserBasket(Guid userId)
        {

            return null;


        }
    }
}

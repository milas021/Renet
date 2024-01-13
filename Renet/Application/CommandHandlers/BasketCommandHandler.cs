using Application.CommandResponse;
using Application.Commands;
using Application.IRepositories;
using Domain.Baskets;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    public class BasketCommandHandler : ICommandHandler<AddProductToBasketCommand, AddProductToBasketCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepositories _productRepositories;

        public BasketCommandHandler(IProductRepositories productRepositories, IUserRepository userRepository)
        {
            _productRepositories = productRepositories;
            _userRepository = userRepository;
        }

        public async Task<AddProductToBasketCommandResponse> Handle(AddProductToBasketCommand command)
        {
            var product = await _productRepositories.GetById(command.ProductId);
            var basketItem = new BasketItem(command.ProductId ,command.Count)
            {
                UnitPrice =product.Price ,   
            };
            var basket = new Basket
            {
                Items = new List<BasketItem> {  basketItem } ,
                UserId = command.UserId,
            };
            return null;

            //todo complete this methode
        }
    }
}

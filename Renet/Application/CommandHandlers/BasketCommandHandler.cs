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
    public class BasketCommandHandler : ICommandHandler<AddProductToBasketCommand, MessageResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepositories _productRepositories;
        private readonly IBasketRepository _basketRepository;

        public BasketCommandHandler(IProductRepositories productRepositories, IUserRepository userRepository, IBasketRepository basketRepository)
        {
            _productRepositories = productRepositories;
            _userRepository = userRepository;
            _basketRepository = basketRepository;
        }

        public async Task<MessageResponse> Handle(AddProductToBasketCommand command)
        {
            var product = await _productRepositories.GetById(command.ProductId);

            var basket = await _basketRepository.GetByUserId(command.UserId);

            if (basket == null)
                basket = new Basket(command.UserId);

            var basketItem = new BasketItem(command.ProductId, command.Count)
            {
                UnitPrice = product.Price,
            };

            basket.AddBasketItem(basketItem);

            //todo if we have a basket before this line throw exception
            await _basketRepository.Add(basket);

            return MessageResponse.CreateSuccesMessage();

        }
    }
}

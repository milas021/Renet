using Application.CommandResponse;
using Application.Commands;
using Application.IRepositories;
using Domain.Baskets;
using Domain.Users;
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

            var user = await _userRepository.GetById(command.UserId);

            var basketitem = new BasketItem(command.ProductId ,command.Count)
            {
                UnitPrice = product.Price 
            };
            user.UserName = "amin";


            user.Basket.AddBasketItem(basketitem);

            await _userRepository.Save();

            return MessageResponse.CreateSuccesMessage();


        }
    }
}

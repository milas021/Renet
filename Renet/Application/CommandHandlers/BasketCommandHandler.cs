﻿using Application.CommandResponse;
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
        private readonly IProductRepository _productRepositories;
        private readonly IBasketRepository _basketRepository;

        public BasketCommandHandler(IProductRepository productRepositories, IUserRepository userRepository, IBasketRepository basketRepository)
        {
            _productRepositories = productRepositories;
            _userRepository = userRepository;
            _basketRepository = basketRepository;
        }

        public async Task<MessageResponse> Handle(AddProductToBasketCommand command)
        {

            var user = await _userRepository.GetById(command.UserId);

            if (user == null)
            {
                throw new Exception("کاربر یافت نشد");
            }

            Basket basket = await _basketRepository.GetByUserId(user.Id);

            if (basket == null)
            {
                basket = new Basket(command.UserId);
                await _basketRepository.Add(basket);
            }

            var item = new BasketItem(command.ProductId, command.Count);

            await _basketRepository.AddBasketItemToBasket(basket, item);


            await _basketRepository.Save();


            return MessageResponse.CreateSuccesMessage();
        }
    }
}

using Application.CommandResponse;
using Application.Commands;
using Application.IRepositories;
using Domain.Carts;
using Domain.Common;
using Domain.Exceptions;
using Infrastructure;

namespace Application.CommandHandlers;
public class CartCommandHandler : ICommandHandler<AddProductToBasketCommand, MessageResponse> {
    private readonly IUserRepository _userRepository;
    private readonly ICartRepository _cartRepository;

    public CartCommandHandler(IUserRepository userRepository, ICartRepository cartRepository) {
        _userRepository = userRepository;
        _cartRepository = cartRepository;
    }

    public async Task<MessageResponse> Handle(AddProductToBasketCommand command) {

        var userExist = await _userRepository.IsUserExist(command.UserId);

        if (!userExist)
            throw new AppException(ErrorMessage.UserNotExist);

        var cart = await _cartRepository.GetByUserId(command.UserId);
        if (cart == null) 
            {
            cart = new Cart(command.UserId);
            await _cartRepository.Add(cart);
        }

        //todo check quantity not geater than stock
        cart.AddCartItem(command.VariantId);

        await _cartRepository.Save();

        return MessageResponse.CreateSuccesMessage();

    }
}

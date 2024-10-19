using Application.CommandResponse;
using Application.Commands;
using Application.IRepositories;
using Domain.Carts;
using Domain.Common;
using Domain.Exceptions;
using Domain.Products;
using Infrastructure;

namespace Application.CommandHandlers;
public class CartCommandHandler : ICommandHandler<AddProductToBasketCommand, MessageResponse> {
    private readonly IUserRepository _userRepository;
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IVariantRepository _variantRepository;

    public CartCommandHandler(IUserRepository userRepository, ICartRepository cartRepository, ICartItemRepository cartItemRepository, IVariantRepository variantRepository) {
        _userRepository = userRepository;
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
        _variantRepository = variantRepository;
    }

    public async Task<MessageResponse> Handle(AddProductToBasketCommand command) {

        var userExist = await _userRepository.IsUserExist(command.UserId);

        if (!userExist)
            throw new AppException(ErrorMessage.UserNotExist);

        var cart = await _cartRepository.GetByUserId(command.UserId);
        if (cart == null) {
            cart = new Cart(command.UserId);
            await _cartRepository.Add(cart);
        }

        Variant variant = await _variantRepository.GetById(command.VariantId);
        var item = await _cartItemRepository.GetCartItemByVariantAndCart(command.VariantId, cart.Id);

        if (item == null) {
            item = new CartItem(command.VariantId, cart.Id);
            await _cartItemRepository.Add(item);

        }

        item.AddQuantity();

        if (item.Quantity > variant.Stock)
            throw new AppException(ErrorMessage.ProductOutOfStock);


        await _cartRepository.Save();
        await _cartItemRepository.Save();

        return MessageResponse.CreateSuccesMessage();

    }
}

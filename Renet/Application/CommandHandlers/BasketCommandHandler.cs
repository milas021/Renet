using Application.CommandResponse;
using Application.Commands;
using Application.IRepositories;
using Infrastructure;

namespace Application.CommandHandlers
{
    public class BasketCommandHandler : ICommandHandler<AddProductToBasketCommand, MessageResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepositories;
        

        public BasketCommandHandler(IProductRepository productRepositories, IUserRepository userRepository)
        {
            _productRepositories = productRepositories;
            _userRepository = userRepository;
            
        }

        public async Task<MessageResponse> Handle(AddProductToBasketCommand command)
        {

            
            return MessageResponse.CreateSuccesMessage("به زودی ...");
        }
    }
}


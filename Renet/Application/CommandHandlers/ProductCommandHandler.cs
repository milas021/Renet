using Application.CommandResponse;
using Application.Commands.ProductCommands;
using Application.IRepositories;
using Domain.Products;
using Infrastructure;
using Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    public class ProductCommandHandler : ICommandHandler<AddCategoryCommand, MessageResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<MessageResponse> Handle(AddCategoryCommand command)
        {
            if (string.IsNullOrEmpty(command.Name))
                throw new AppException(ErrorMessage.InvalidCategoryName);

            if (_categoryRepository.IsExist(command.Name).Result)
                throw new AppException(ErrorMessage.DuplicateCategoryName);

            if(string.IsNullOrEmpty(command.Image) || string.IsNullOrEmpty(command.Icon))
                throw new AppException(ErrorMessage.InvalidCategoryIconOrImage);


            var category = new Category(command.Name , command.Icon , command.Image);
            await _categoryRepository.Add(category);

            return MessageResponse.CreateSuccesMessage();

        }
    }
}

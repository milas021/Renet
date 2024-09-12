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
    public class ProductCommandHandler :
        ICommandHandler<AddCategoryCommand, MessageResponse>
        , ICommandHandler<AddProductCommand, MessageResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IColorRepository _colorRepository;

        public ProductCommandHandler(ICategoryRepository categoryRepository, IProductRepository productRepository, IColorRepository colorRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _colorRepository = colorRepository;
        }

        public async Task<MessageResponse> Handle(AddCategoryCommand command)
        {
            if (string.IsNullOrEmpty(command.Name))
                throw new AppException(ErrorMessage.InvalidCategoryName);

            if (_categoryRepository.IsExist(command.Name).Result)
                throw new AppException(ErrorMessage.DuplicateCategoryName);

            if (string.IsNullOrEmpty(command.Image) || string.IsNullOrEmpty(command.Icon))
                throw new AppException(ErrorMessage.InvalidCategoryIconOrImage);


            var category = new Category(command.Name, command.Icon, command.Image);
            await _categoryRepository.Add(category);

            return MessageResponse.CreateSuccesMessage();

        }

        public async Task<MessageResponse> Handle(AddProductCommand command)
        {
            var category = await _categoryRepository.GetById(command.CategoryId);

            var features = new List<Feature>();
            foreach (var f in command.Features)
            {
                features.Add(new Feature(f.Name, f.Value));
            }

            var articles = new List<Article>();
            foreach (var article in command.Articles)
            {
                articles.Add(new Article(article.Title, article.Text));
            }

            var images = new List<ProductImage>();
            foreach (var image in command.Images)
            {
                images.Add(new ProductImage(image.Name, image.IsMainImage));
            }

            var variants = new List<ProductVariant>();
            foreach (var variant in command.Variants)
            {
                var color = await _colorRepository.GetById(variant.ColorId);
                variants.Add(new ProductVariant(variant.Price, variant.Stock)
                {
                    Color = color,
                });
            }

            var product = new Product()
            {
                Name = command.Name,
                EnglishName = command.EnglishName,
                Description = command.Description,
                Brand = command.Brand,
                Guaranty = command.Guaranty,

                Variants = variants,
                Category = category,
                Features = features,
                Articles = articles,
                Images = images

            };

            await _productRepository.Add(product);

            return MessageResponse.CreateSuccesMessage();
        }
    }
}

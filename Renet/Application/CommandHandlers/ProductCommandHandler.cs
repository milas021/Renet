using Application.CommandResponse;
using Application.Commands.ProductCommands;
using Application.IRepositories;
using Domain.Common;
using Domain.Exceptions;
using Domain.Products;
using Infrastructure;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace Application.CommandHandlers {
    public class ProductCommandHandler :
        ICommandHandler<AddCategoryCommand, MessageResponse>
        , ICommandHandler<AddProductCommand, MessageResponse>
        , ICommandHandler<EditCategoryCommand, MessageResponse>
         , ICommandHandler<AddColorCommand, MessageResponse>
        , ICommandHandler<AddCategoryWithFileCommand, MessageResponse>
        , ICommandHandler<EditeProductCommand, MessageResponse> {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IColorRepository _colorRepository;

        private readonly DirectorySettings directorySettings;

        public ProductCommandHandler(ICategoryRepository categoryRepository, IProductRepository productRepository, IColorRepository colorRepository, IOptions<DirectorySettings> directory) {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _colorRepository = colorRepository;
            directorySettings = directory.Value;
        }

        public async Task<MessageResponse> Handle(AddCategoryCommand command) {


            if (_categoryRepository.IsExist(command.Name).Result)
                throw new AppException(ErrorMessage.DuplicateCategoryName);

            var category = new Category(command.Name, command.Icon, command.Image);
            await _categoryRepository.Add(category);
            await _categoryRepository.Save();

            return MessageResponse.CreateSuccesMessage();

        }

        public async Task<MessageResponse> Handle(AddProductCommand command) {
            var category = await _categoryRepository.GetById(command.CategoryId);

            var features = new List<Feature>();
            foreach (var f in command.Features) {
                features.Add(new Feature(f.Name, f.Value));
            }

            var articles = new List<Article>();
            foreach (var article in command.Articles) {
                articles.Add(new Article(article.Title, article.Text));
            }

            var images = new List<ProductImage>();
            foreach (var image in command.Images) {
                images.Add(new ProductImage(image.Name, image.IsMainImage));
            }

            var variants = new List<Variant>();
            foreach (var variant in command.Variants) {
                var color = await _colorRepository.GetById(variant.ColorId);
                variants.Add(new Variant(variant.Price, variant.Stock) {
                    Color = color,
                });
            }



            var product = Product.Create(command.Name, category, variants)
                .WithEnglishName(command.EnglishName)
                .WithDescription(command.Description)
                .WithBrand(command.Brand)
                .WithGuaranty(command.Guaranty)
                .WithFeatute(features)
                .WithArticles(articles)
                .WithImages(images);

            await _productRepository.Add(product);
            await _productRepository.Save();

            return MessageResponse.CreateSuccesMessage();
        }

        public async Task<MessageResponse> Handle(EditCategoryCommand command) {
            var category = await _categoryRepository.GetById(command.Id);

            category.Update(command.Name, command.Icon, command.Image);

            await _categoryRepository.Save();

            return MessageResponse.CreateSuccesMessage();
        }

        public async Task<MessageResponse> Handle(AddColorCommand command) {
            var color = new Color(command.Name, command.HexCode);

            if (await _colorRepository.AnyColor(command.Name))
                throw new AppException(ErrorMessage.DuplicatedColorName);

            await _colorRepository.AddColor(color);
            await _colorRepository.Save();
            return MessageResponse.CreateSuccesMessage();

        }

        public async Task<MessageResponse> Handle(AddCategoryWithFileCommand command) {
            //throw new NotImplementedException();

            if (command.Image.Length > 0) {
                var filePath = Path.Combine(directorySettings.BaseImageDirectory,
                    Path.GetRandomFileName());

                using (var stream = System.IO.File.Create(filePath)) {
                    await command.Image.CopyToAsync(stream);
                }
            }

            if (command.Icon.Length > 0) {
                var filePath = Path.Combine(directorySettings.BaseImageDirectory,
                    Path.GetRandomFileName());

                using (var stream = System.IO.File.Create(filePath)) {
                    await command.Icon.CopyToAsync(stream);

                }
            }




            if (_categoryRepository.IsExist(command.Name).Result)
                throw new AppException(ErrorMessage.DuplicateCategoryName);

            var category = new Category(command.Name, command.Icon.FileName, command.Image.FileName);
            await _categoryRepository.Add(category);
            await _categoryRepository.Save();

            return MessageResponse.CreateSuccesMessage();


        }

        public async Task<MessageResponse> Handle(EditeProductCommand command) {
            //todo : refactor PLZ
            var product = await _productRepository.GetById(command.Id);

            var category = await _categoryRepository.GetById(command.CategoryId);

            var variants = new List<Variant>();
            foreach (var variant in command.Variants) {
                var color = await _colorRepository.GetById(variant.ColorId);
                variants.Add(new Variant(variant.Price, variant.Stock) {
                    Color = color,
                });
            }

            var features = new List<Feature>();
            foreach (var f in command.Features) {
                features.Add(new Feature(f.Name, f.Value));
            }

            var articles = new List<Article>();
            foreach (var article in command.Articles) {
                articles.Add(new Article(article.Title, article.Text));
            }

            var images = new List<ProductImage>();
            foreach (var image in command.Images) {
                images.Add(new ProductImage(image.Name, image.IsMainImage));
            }

            product.SetName(command.Name)
                .SetCategory(category)
                .SetVariants(variants)
                .WithDescription(command.Description)
                .WithEnglishName(command.EnglishName)
                .WithBrand(command.Brand)
                .WithGuaranty(command.Guaranty)
                .WithArticles(articles)
                .WithImages(images)
                .WithFeatute(features);

            await _productRepository.Save();
            return MessageResponse.CreateSuccesMessage();

        }
    }
}

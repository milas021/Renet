using Domain.Common;
using Domain.Exceptions;

namespace Domain.Products {
    public class Product {
        //todo : privat set all
        private Product() { }
        private Product(string name, Category category, IEnumerable<Variant> variants) {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string EnglishName { get; private set; }
        public string Guaranty { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public Category Category { get; private set; }
        public IEnumerable<Variant> Variants { get; private set; }
        public IEnumerable<Article> Articles { get; private set; }
        public IEnumerable<ProductImage> Images { get; private set; }
        public IEnumerable<Feature> Features { get; private set; }

        public static Product Create(string name, Category category, IEnumerable<Variant> variants) {
            var product = new Product(name, category, variants);

            return product;
        }
        public Product SetCategory(Category category) {
            Category = category;
            return this;
        }
        public Product SetName(string name) {
            if (string.IsNullOrEmpty(name))
                throw new AppException(ErrorMessage.InvalidProductName);
            Name = name;
            return this;
        }

        public Product SetVariants(List<Variant> variants) {
            Variants.ToList().Clear();
            Variants = variants;
            return this;
        }
        public Product WithDescription(string description) {
            Description = description;
            return this;
        }

        public Product WithEnglishName(string EnglishAme) {
            EnglishName = EnglishAme;
            return this;
        }

        public Product WithBrand(string brand) {
            Brand = brand;
            return this;
        }

        public Product WithGuaranty(string guaranty) {
            Guaranty = guaranty;
            return this;
        }

        public Product WithArticles(List<Article> articles) {
            Articles.ToList().Clear();
            Articles = articles;
            return this;
        }
        public Product WithImages(List<ProductImage> images) {
            Images.ToList().Clear();
            Images = images;
            return this;
        }
        public Product WithFeatute(List<Feature> features) {
            Features.ToList().Clear();
            Features = features;
            return this;
        }



        public decimal GetMinPrice() {
            var min = Variants.Min(x => x.Price);
            return min;
        }

        public decimal GetMaxPrice() {
            var max = Variants.Max(x => x.Price);
            return max;
        }

        public bool AnyColor(Guid colorId) {
            var result = Variants.Any(x => x.Color.Id == colorId);
            return result;
        }

        public string GetMainImage() {
            var image = Images == null || Images.Count() == 0 ? null : Images.SingleOrDefault(x => x.IsMainPicture).Name;
            return image;
        }

        public List<string> GetHexColors() {
            var colors = Variants.Select(x => x.Color.HexCode).ToList();
            return colors;
        }
        public bool AnySmallerPrice(decimal price) {
            return Variants.Any(x => x.Price < price);
        }

        public bool AnyBiggerPrice(decimal price) {
            return Variants.Any(x => x.Price > price);
        }
    }






}

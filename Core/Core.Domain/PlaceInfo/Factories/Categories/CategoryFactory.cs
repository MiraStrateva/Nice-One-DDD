namespace Core.Domain.PlaceInfo.Factories.Categories
{
    using Core.Domain.PlaceInfo.Models.Categories;

    public class CategoryFactory : ICategoryFactory
    {
        private string name = default!;
        private string description = default!;
        private string imageUrl = default!;

        public ICategoryFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public ICategoryFactory WithDescription(string description)
        {
            this.description = name;
            return this;
        }

        public ICategoryFactory WithImageUrl(string imageUrl)
        {
            this.imageUrl = name;
            return this;
        }

        public Category Build()
        {
            return new Category(
                this.name,
                this.description,
                this.imageUrl);
        }
    }
}

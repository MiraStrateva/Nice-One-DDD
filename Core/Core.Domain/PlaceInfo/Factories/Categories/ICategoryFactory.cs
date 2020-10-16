namespace Core.Domain.PlaceInfo.Factories.Categories
{
    using Common.Domain;
    using Core.Domain.PlaceInfo.Models.Categories;

    public interface ICategoryFactory : IFactory<Category>
    {
        ICategoryFactory WithName(string name);
    }
}

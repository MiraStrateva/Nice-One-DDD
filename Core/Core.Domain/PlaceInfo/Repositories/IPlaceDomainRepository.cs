namespace Core.Domain.PlaceInfo.Repositories
{
    using Common.Domain;
    using Core.Domain.PlaceInfo.Models.Categories;
    using Core.Domain.PlaceInfo.Models.Places;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPlaceDomainRepository : IDomainRepository<Place>
    {
        Task<IEnumerable<Category>> GetCategoriesOrderedByPlaces();
        Task<IEnumerable<Category>> GetCategories();
        Task<string> GetCategoryName(int id);
        Task<Category> GetCategory(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Place>> GetPlaces();
        Task<IEnumerable<Place>> GetPlacesByCategory(int categoryId);
        Task<IEnumerable<Place>> GetPlacesByUserId(string userId);
        Task<Place> GetPlace(int id);
        Task<IEnumerable<Place>> Search(string searchText);
        Task<IEnumerable<Feedback>> GetFeedbacksForCurrentUser();
        Task<Feedback> GetFeedback(int id);
    }
}

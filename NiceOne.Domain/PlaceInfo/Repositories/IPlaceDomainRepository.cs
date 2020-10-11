namespace NiceOne.Domain.PlaceInfo.Repositories
{
    using NiceOne.Domain.Common;
    using NiceOne.Domain.PlaceInfo.Models.Places;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    interface IPlaceDomainRepository : IDomainRepository<Place>
    {
        Task<IEnumerable<Category>> GetCategoriesOrderedByPlaces();
        Task<IEnumerable<Category>> GetCategories();
        Task<string> GetCategoryName(int id);
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Place>> GetPlaces();
        Task<IEnumerable<Place>> GetPlacesByCategory(int categoryId);
        Task<IEnumerable<Place>> GetPlacesByUserId(string userId);
        Task<Place> GetPlace(int id);
        Task<IEnumerable<Place>> Search(string searchText);
        Task<IEnumerable<Feedback>> GetFeedbacksForCurrentUser();
        Task<Feedback> GetFeedback(int id);
    }
}

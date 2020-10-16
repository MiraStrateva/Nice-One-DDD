namespace Core.Application.PlaceInfo.Categories
{
    using Common.Application.Contracts;
    using Core.Application.PlaceInfo.Places.Queries.Common;
    using Core.Domain.PlaceInfo.Models.Categories;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICategoryQueryRepository : IQueryRepository<Category>
    {
        Task<IEnumerable<CategoryOutputModel>> Get(CancellationToken cancellationToken);
        Task<CategoryOutputModel> Get(int id, CancellationToken cancellationToken);
    }
}

namespace Core.Application.PlaceInfo.Places
{
    using Common.Application.Contracts;
    using Core.Application.PlaceInfo.Places.Queries.Common;
    using Core.Domain.PlaceInfo.Models.Places;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPlaceQueryRepository : IQueryRepository<Place>
    {
        Task<IEnumerable<PlaceOutputModel>> Get(CancellationToken cancellationToken = default);

        Task<IEnumerable<PlaceOutputModel>> GetByCategory(int categoryId, 
            CancellationToken cancellationToken = default);

        Task<IEnumerable<PlaceOutputModel>> GetByUser(int userId,
            CancellationToken cancellationToken = default);

        Task<PlaceOutputModel> GetById(int userId, CancellationToken cancellationToken);
    }
}

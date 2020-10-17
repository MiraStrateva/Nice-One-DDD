namespace Core.Infrastructure.PlaceInfo.Repositories
{
    using AutoMapper;
    using Common.Infrastructure.Persistence;
    using Core.Application.PlaceInfo.Places;
    using Core.Application.PlaceInfo.Places.Queries.Common;
    using Core.Domain.PlaceInfo.Models.Places;
    using Core.Domain.PlaceInfo.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
 
    internal class PlaceRepository : DataRepository<IPlaceInfoDbContext, Place>,
        IPlaceDomainRepository,
        IPlaceQueryRepository
    {
        private readonly IMapper mapper;

        public PlaceRepository(IPlaceInfoDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<IEnumerable<PlaceOutputModel>> Get(CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<PlaceOutputModel>(this.Data.Places)
                .ToListAsync();

        public async Task<IEnumerable<PlaceOutputModel>> GetByCategory(int categoryId, CancellationToken cancellationToken = default)
        {
            var category = await this.Data.Categories
                .Where(c => c.Id == categoryId)
                .FirstOrDefaultAsync();

            return await this.mapper
                .ProjectTo<PlaceOutputModel>(this.Data.Places)
                .Where(p => p.CategoryName == category.Name)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<PlaceOutputModel> GetById(int Id, CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<PlaceOutputModel>(this.Data.Places)
                .FirstOrDefaultAsync(c => c.Id == Id);

        public Task<IEnumerable<PlaceOutputModel>> GetByUser(int userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

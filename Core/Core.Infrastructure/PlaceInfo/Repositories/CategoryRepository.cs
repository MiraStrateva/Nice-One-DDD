namespace Core.Infrastructure.PlaceInfo.Repositories
{
    using AutoMapper;
    using Common.Infrastructure.Persistence;
    using Core.Application.PlaceInfo.Categories;
    using Core.Application.PlaceInfo.Places.Queries.Common;
    using Core.Domain.PlaceInfo.Models.Categories;
    using Core.Domain.PlaceInfo.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CategoryRepository : DataRepository<IPlaceInfoDbContext, Category>,
        ICategoryDomainRepository,
        ICategoryQueryRepository
    {
        private readonly IMapper mapper;

        public CategoryRepository(IPlaceInfoDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<IEnumerable<CategoryOutputModel>> Get(CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<CategoryOutputModel>(this.Data.Categories)
                .ToListAsync();

        public async Task<CategoryOutputModel> Get(int id, CancellationToken cancellationToken)
            => await this.mapper
                .ProjectTo<CategoryOutputModel>(this.Data.Categories)
                .FirstOrDefaultAsync(c => c.Id == id);
    }
}

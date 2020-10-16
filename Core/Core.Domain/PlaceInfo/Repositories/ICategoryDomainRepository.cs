namespace Core.Domain.PlaceInfo.Repositories
{
    using Common.Domain;
    using Core.Domain.PlaceInfo.Models.Categories;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    public class ICategoryDomainRepository : IDomainRepository<Category>
    {
        public Task Save(Category entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

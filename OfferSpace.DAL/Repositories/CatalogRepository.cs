using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;

namespace OfferSpace.DAL.Repositories
{
    public class CatalogRepository : Repository<Catalog, long>, ICatalogRepository
    {
        public CatalogRepository(UnitOfWork uow) : base(uow)
        {
        }
    }
}

using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;

namespace OfferSpace.DAL.Repositories
{
   public  class CompanyRepository : Repository<Company, long>, ICompanyRepository
    {
        public CompanyRepository(UnitOfWork uow) : base(uow)
        {
        }
    }
}

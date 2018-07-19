using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.DAL.Repositories
{
   public  class CompanyRepository : Repository<Company, long>, ICompanyRepository
    {
        public CompanyRepository(/*IUnitOfWork*/ UnitOfWork uow) : base(uow)
        {
        }
    }
}

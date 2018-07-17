using OfferSpace.BL.Core;
using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.DAL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer, string>, ICustomerRepository
    {
        public CustomerRepository(/*IUnitOfWork*/ UnitOfWork uow) : base(uow)
        {
        }
    }
}

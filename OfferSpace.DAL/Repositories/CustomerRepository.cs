using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OfferSpace.DAL.Repositories
{
    public class CustomerRepository : Repository<UserProfile, long>, ICustomerRepository
    {
        public CustomerRepository(UnitOfWork uow) : base(uow)
        {
        }
        public UserProfile GerUserProfileByUserId(string id)
        {
            var custumer = GetAll().ToList().FirstOrDefault(customer=>customer.UserId==id);
            return custumer;
        }
    }
}

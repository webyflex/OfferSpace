using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace OfferSpace.DAL.Repositories
{
    public class CustomerRepository : Repository<UserProfile, long>, ICustomerRepository
    {
        private readonly DbSet<UserProfile> _dbSet;
        public CustomerRepository(UnitOfWork uow) : base(uow)
        {
            _dbSet = uow.Context.Set<UserProfile>();
        }
        public UserProfile GetUserProfileByUserId(string id)
        {
            var custumer = _dbSet.FirstOrDefault(customer=>customer.UserId==id);
            return custumer;
        }
    } 
}

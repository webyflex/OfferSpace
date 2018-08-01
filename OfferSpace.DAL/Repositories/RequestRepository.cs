using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace OfferSpace.DAL.Repositories
{
    public class RequestRepository : Repository<Request, long>, IRequestRepository
    {
        private readonly DbSet<Request> _dbSet;
        public RequestRepository(UnitOfWork uow) : base(uow)
        {
            _dbSet = uow.Context.Set<Request>();
        }

        public List<Request> GetRequestByUserProfileId(UserProfile userProfile)
        {
            List<Request> requests = _dbSet.Where(reques => reques.CustomerId == userProfile.Id).ToList();
            return requests;
        }
    }
}

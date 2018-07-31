using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace OfferSpace.DAL.Repositories
{
    public class RequestRepository : Repository<Request, long>, IRequestRepository
    {
        public RequestRepository(UnitOfWork uow) : base(uow)
        {
        }

        public List<Request> GetRequestByUserProfileId(UserProfile userProfile)
        {
            List<Request> requests = GetAll().ToList().Where(reques => reques.CustomerId == userProfile.Id).ToList();
            return requests;
        }
    }
}

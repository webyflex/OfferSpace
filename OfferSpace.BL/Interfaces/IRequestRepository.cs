using OfferSpace.BL.Models;
using OfferSpace.BL.Core;
using System.Collections.Generic;

namespace OfferSpace.BL.Interfaces
{
    public interface IRequestRepository : IRepository<Request, long>
    {
        List<Request> GetRequestByUserProfileId(UserProfile userProfile);
    }
}

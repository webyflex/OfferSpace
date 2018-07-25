using OfferSpace.BL.Models;
using OfferSpace.BL.Core;

namespace OfferSpace.BL.Interfaces
{
    public interface ICustomerRepository : IRepository<UserProfile, long>
    {
    }
}

using OfferSpace.BL.Models;
using OfferSpace.BL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Interfaces
{
    public interface IRequestCustomerRepository : IRepository<RequestCustomer, long>
    {
    }
}

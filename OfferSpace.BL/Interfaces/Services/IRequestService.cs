using OfferSpace.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Interfaces.Services
{
    public interface IRequestService
    {
        List<Request> GetUserRequests(string id);
    }
}

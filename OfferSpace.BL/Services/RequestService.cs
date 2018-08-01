using OfferSpace.BL.Interfaces;
using OfferSpace.BL.Interfaces.Services;
using OfferSpace.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Services
{
    public class RequestService: IRequestService
    {
        ICustomerRepository _customerRepository;
        IRequestRepository _requestRepository;
        public RequestService(ICustomerRepository customerRepository, IRequestRepository requestRepository)
        {
            _customerRepository = customerRepository;
            _requestRepository = requestRepository;
        }

        public List<Request> GetUserRequests(string id)
        {
            var customer = _customerRepository.GetUserProfileByUserId(id);
            var requests = _requestRepository.GetRequestByUserProfileId(customer);
            return requests;
        }
    }
}

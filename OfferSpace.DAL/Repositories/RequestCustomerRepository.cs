﻿using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.DAL.Repositories
{
    public class RequestCustomerRepository : Repository<RequestCustomer, long>, IRequestCustomerRepository
    {
        public RequestCustomerRepository(/*IUnitOfWork*/ UnitOfWork uow) : base(uow)
        {
        }
    }
}

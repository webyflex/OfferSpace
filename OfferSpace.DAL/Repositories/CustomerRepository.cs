﻿using OfferSpace.BL.Models;
using OfferSpace.DAL.Core;
using OfferSpace.BL.Interfaces;

namespace OfferSpace.DAL.Repositories
{
    public class CustomerRepository : Repository<Customer, long>, ICustomerRepository
    {
        public CustomerRepository(UnitOfWork uow) : base(uow)
        {
        }
    }
}

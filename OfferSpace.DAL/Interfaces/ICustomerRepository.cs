using OfferSpace.BL.Models;
using OfferSpace.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.DAL.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer, string>
    {
        //void Add(Customer entity);
        //Customer Find(int id);
        //IEnumerable<Customer> Get();
        //void Update(Customer entity);

        //void Delete(int id);
        //void Delete(Customer entity);
    }
}

using OfferSpace.BL.Models;
using OfferSpace.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.DAL.Interfaces
{
    public interface IExecutorRepository : IGenericRepository<Executor, string>
    {
    }
}

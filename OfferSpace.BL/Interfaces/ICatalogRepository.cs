
using OfferSpace.BL.Core;
using OfferSpace.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Interfaces
{
    public interface ICatalogRepository : IRepository<Catalog, long>
    {
    }
}

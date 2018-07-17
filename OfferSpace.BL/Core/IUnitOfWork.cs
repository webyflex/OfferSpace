using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Core
{
    public interface IUnitOfWork
    {
        DbContext Context { get; set; }

        void Commit();
    }
}

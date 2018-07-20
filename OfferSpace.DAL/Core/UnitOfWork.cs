using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfferSpace.BL.Core;

namespace OfferSpace.DAL.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get;}
        public UnitOfWork(OfferSpaceContext dbContext)
        {
            Context = dbContext;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}

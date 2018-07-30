using System.Data.Entity;
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

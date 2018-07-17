using OfferSpace.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.BL.Repositories
{
    public interface IGenericRepository<TEntity, /*in*/ TKey> where TEntity : class, IEntity<TKey>
    {
        void Create(TEntity entity);
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);

        void Delete(TKey id);
        void Delete(TEntity entity);

        void MarkAsDeleted(TKey id);
        void MarkAsDeleted(TEntity entity);
    }
}

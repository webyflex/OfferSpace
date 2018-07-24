﻿using System.Collections.Generic;

namespace OfferSpace.BL.Core
{
    public interface IRepository<TEntity, in TKey> where TEntity : class, IEntity<TKey>
    {
        void Create(TEntity entity);
        TEntity GetById(TKey id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TKey id);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}

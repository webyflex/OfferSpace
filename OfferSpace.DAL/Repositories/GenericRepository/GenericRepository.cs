using OfferSpace.BL.Core;
using OfferSpace.BL.Models;
using OfferSpace.BL.Repositories;
using OfferSpace.DAL.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferSpace.DAL.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        public readonly IUnitOfWork /*UnitOfWork*/ _unitOfWork;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(IUnitOfWork /*UnitOfWork*/ unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.AddOrUpdate(entity);
            _unitOfWork.Commit();
        }

        public void Delete(TKey id)
        {
            _dbSet.Remove(_dbSet.Find(id) ?? throw new InvalidOperationException());
            _unitOfWork.Commit();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _unitOfWork.Commit();
        }

        public TEntity GetById(TKey id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public void Update(TEntity entity)
        {
            _dbSet.AddOrUpdate(entity);
            _unitOfWork.Commit();
        }

        public void MarkAsDeleted(TKey id)
        {
            TEntity entity = _dbSet.Find(id);
            entity.MarkAsDeleted = true;
            _unitOfWork.Commit();
        }

        public void MarkAsDeleted(TEntity entity)
        {
            entity.MarkAsDeleted = true;
            _unitOfWork.Commit();
        }
    }
}

using E.Entities.Interfaces;
using E.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E.Service.Services.Base
{
    /// <summary>
    /// Manager base.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TRepository">Repository type</typeparam>
    public abstract class ManagerBase<TEntity, TRepository> : IManager<TEntity>
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        #region Properties

        /// <summary>
        /// Gets the repository.
        /// </summary>
        protected TRepository Repository { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes manager base.
        /// </summary>
        /// <param name="repository">Repository</param>
        protected ManagerBase(
            TRepository repository)
        {
            Repository = repository;
        }

        #endregion Constructors

        #region Methods

        public virtual void Create(
            TEntity entity)
        {
            Repository.Add(entity);
            Repository.Save();
        }

        public virtual void Delete(
            TEntity entity)
        {
            Repository.Remove(entity);
            Repository.Save();
        }

        public virtual List<TEntity> Get(
            Func<TEntity, bool> filter = null)
        {
            return Repository
                .Get(filter)
                .ToList();
        }

        public virtual void Update(
            TEntity entity)
        {
            Repository.Update(entity);
            Repository.Save();
        }

        #endregion Methods
    }
}

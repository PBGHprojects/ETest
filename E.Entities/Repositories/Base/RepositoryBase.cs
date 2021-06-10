using E.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace E.Entities.Repositories.Base
{
    /// <summary>
    /// Repository base.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        #region Properties

        /// <summary>
        /// Gets the context.
        /// </summary>
        protected IAppContext Context { get; private set; }

        /// <summary>
        /// Gets the set.
        /// </summary>
        protected DbSet<TEntity> Set { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes repository base.
        /// </summary>
        /// <param name="appContext">App context</param>
        protected RepositoryBase(
            IAppContext appContext)
        {
            Context = appContext;
            Set = appContext.Set<TEntity>();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds the entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Add(
            TEntity entity)
        {
            Set.Add(entity);
        }

        /// <summary>
        /// Finds entities.
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            Func<TEntity, bool> filter)
        {
            return Set.Where(filter ?? (f => true));
        }

        /// <summary>
        /// Removes the entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Remove(
            TEntity entity)
        {
            Set.Remove(entity);
        }

        /// <summary>
        /// Saves the changes made in context.
        /// </summary>
        public virtual void Save()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(
            TEntity entity)
        {
            Set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        #endregion Methods
    }
}

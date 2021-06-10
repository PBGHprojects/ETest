using System;
using System.Collections.Generic;

namespace E.Entities.Interfaces
{
    /// <summary>
    /// Repository contract.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        #region Methods

        /// <summary>
        /// Adds the entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Add(TEntity entity);

        /// <summary>
        /// Gets the entities.
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(Func<TEntity, bool> filter);

        /// <summary>
        /// Removes the entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Saves the changes made in context.
        /// </summary>
        void Save();

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(TEntity entity);

        #endregion Methods
    }
}

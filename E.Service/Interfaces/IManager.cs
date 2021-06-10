using System;
using System.Collections.Generic;

namespace E.Service.Interfaces
{
    /// <summary>
    /// Manager contract.
    /// </summary>
    public interface IManager<TEntity>
    {
        #region Methods

        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="model">Model</param>
        void Create(TEntity model);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="model">Model</param>
        void Delete(TEntity model);

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns></returns>
        List<TEntity> Get(Func<TEntity, bool> filter = null);

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="model">Model</param>
        void Update(TEntity model);

        #endregion Methods
    }
}

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace E.Entities.Interfaces
{
    /// <summary>
    /// App context contract.
    /// </summary>
    public interface IAppContext
    {
        #region Properties

        /// <summary>
        /// Gets the db catalog set.
        /// </summary>
        DbSet<Catalog> Catalog { get; }

        /// <summary>
        /// Gets the db product set.
        /// </summary>
        DbSet<Product> Product { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets a System.Data.Entity.Infrastructure.DbEntityEntry`1 object for the given
        /// entity providing access to information about the entity and the ability to perform
        /// actions on the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>An entry for the entity.</returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Returns a db set instance for access to entities of the given type in the context and the underlying store.
        /// </summary>
        /// <typeparam name="TEntity">The type entity for which a set should be returned.</typeparam>
        /// <returns>A set for the given entity type.</returns>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>The number of objects written to the underlying database.</returns>
        int SaveChanges();

        #endregion Methods
    }
}

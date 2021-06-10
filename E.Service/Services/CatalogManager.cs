using E.Entities;
using E.Entities.Interfaces;
using E.Service.Interfaces;
using E.Service.Services.Base;
using System.Linq;

namespace E.Service.Services
{
    /// <summary>
    /// Catalog manager.
    /// </summary>
    public class CatalogManager : ManagerBase<Catalog, ICatalogRepository>, ICatalogManager
    {
        #region Constructors

        /// <summary>
        /// Initializes catalog manager.
        /// </summary>
        /// <param name="repository">Catalog repository</param>
        public CatalogManager(
            ICatalogRepository repository)
            : base(repository)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Checks if catalog can be deleted.
        /// </summary>
        /// <param name="entity">Catalog</param>
        /// <returns>true if catalog can be deleted, otherwise false</returns>
        public bool CanDeleteCatalog(
            int id)
        {
            var catalog = GetById(id);

            return !catalog.Product
                .Any(p => p.Catalog.Count == 1);
        }

        /// <summary>
        /// Gets catalogs by id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Catalog GetById(
            int id)
        {
            return Repository
                .Get(p => p.Id == id)
                .SingleOrDefault();
        }

        #endregion Methods
    }
}

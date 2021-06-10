using E.Entities;

namespace E.Service.Interfaces
{
    /// <summary>
    /// Catalog manager contract.
    /// </summary>
    public interface ICatalogManager : IManager<Catalog>
    {
        #region Methods

        /// <summary>
        /// Checks if catalog can be deleted.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>true if catalog can be deleted, otherwise false</returns>
        bool CanDeleteCatalog(int id);

        /// <summary>
        /// Gets catalogs by id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Catalog GetById(int id);

        #endregion Methods
    }
}

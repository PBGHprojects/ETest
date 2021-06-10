using E.Entities.Interfaces;
using E.Entities.Repositories.Base;

namespace E.Entities.Repositories
{
    /// <summary>
    /// Catalog repository.
    /// </summary>
    public class CatalogRepository : RepositoryBase<Catalog>, ICatalogRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes catalog repository.
        /// </summary>
        /// <param name="context">Context</param>
        public CatalogRepository(
            IAppContext context)
            : base(context)
        {
        }

        #endregion Constructors
    }
}

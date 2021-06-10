using E.Entities.Interfaces;
using E.Entities.Repositories.Base;

namespace E.Entities.Repositories
{
    /// <summary>
    /// Product repository.
    /// </summary>
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes product repository.
        /// </summary>
        /// <param name="context">Context</param>
        public ProductRepository(
            IAppContext context)
            : base(context)
        {
        }

        #endregion Constructors
    }
}

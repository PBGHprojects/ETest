using E.Entities;
using E.Entities.Interfaces;
using E.Service.Interfaces;
using E.Service.Services.Base;
using System.Linq;

namespace E.Service.Services
{
    /// <summary>
    /// Product manager.
    /// </summary>
    public class ProductManager : ManagerBase<Product, IProductRepository>, IProductManager
    {
        #region Properties

        /// <summary>
        /// Gets the catalog repository.
        /// </summary>
        protected ICatalogRepository CatalogRepository { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes product manager.
        /// </summary>
        /// <param name="repository">Product repository</param>
        /// <param name="catalogRepository">Catalog pepository</param>
        public ProductManager(
            IProductRepository repository,
            ICatalogRepository catalogRepository)
            : base(repository)
        {
            CatalogRepository = catalogRepository;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets product by id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Product GetById(
            int id)
        {
            return Repository
                .Get(p => p.Id == id)
                .SingleOrDefault();
        }

        /// <summary>
        /// Updates the product and product catalogs.
        /// </summary>
        /// <param name="entity">Product</param>
        public override void Update(
            Product entity)
        {
            var newCatalogIds = entity.Catalog.Select(c => c.Id);

            var old = GetById(entity.Id);
            old.Code = entity.Code;
            old.Description = entity.Description;
            old.Catalog
                .Where(c => !newCatalogIds.Contains(c.Id))
                .ToList()
                .ForEach(c => old.Catalog.Remove(c));

            var existingCatalogIds = old.Catalog
                .Select(c => c.Id);

            var catalogs = CatalogRepository.Get(c =>
                newCatalogIds
                    .Except(existingCatalogIds)
                    .Contains(c.Id));
            catalogs
                .ToList()
                .ForEach(c => old.Catalog.Add(c));

            Repository.Save();
        }

        #endregion Methods
    }
}

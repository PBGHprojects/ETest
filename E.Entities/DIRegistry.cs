using E.Entities.Interfaces;
using E.Entities.Repositories;
using Unity;
using Unity.AspNet.Mvc;

namespace E.Entities
{
    /// <summary>
    /// DI registry.
    /// </summary>
    public static class DIRegistry
    {
        #region Methods

        /// <summary>
        /// Registers dependencies from this project.
        /// </summary>
        /// <param name="container">Unity container</param>
        /// <returns></returns>
        public static IUnityContainer RegisterEntities(
            this IUnityContainer container)
        {
            container.RegisterType<IAppContext, AppContext>(new PerRequestLifetimeManager());
            container.RegisterType<ICatalogRepository, CatalogRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();

            return container;
        }

        #endregion Methods
    }
}

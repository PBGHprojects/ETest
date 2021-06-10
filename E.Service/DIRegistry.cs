using E.Service.Interfaces;
using E.Service.Services;
using Unity;

namespace E.Service
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
        public static IUnityContainer RegisterServices(
            this IUnityContainer container)
        {
            container.RegisterType<ICatalogManager, CatalogManager>();
            container.RegisterType<IProductManager, ProductManager>();

            return container;
        }

        #endregion Methods
    }
}

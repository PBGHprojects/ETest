using System.Collections.Generic;

namespace ETest.Web.Models
{
    /// <summary>
    /// Catalog with products view model.
    /// </summary>
    public class CatalogWithProductsViewModel : CatalogViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public List<ProductViewModel> Products { get; set; }

        #endregion Properties
    }
}
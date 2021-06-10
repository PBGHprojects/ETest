using System.Collections.Generic;

namespace ETest.Web.Models
{
    /// <summary>
    /// Product with catalog view model.
    /// </summary>
    public class ProductWithCatalogViewModel : ProductViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the catalogs.
        /// </summary>
        public List<CatalogViewModel> Catalogs { get; set; }

        #endregion Properties
    }
}
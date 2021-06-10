using ETest.Web.Models.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ETest.Web.Models
{
    /// <summary>
    /// Product create view model.
    /// </summary>
    public class ProductCreateViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the catalog ids.
        /// </summary>
        [Required(ErrorMessage = "Select at least one catalog.")]
        [AtLeastOne(ErrorMessage = "Select at least one catalog.")]
        public List<int> CatalogIds { get; set; }

        /// <summary>
        /// Gets or sets the available catalogs.
        /// </summary>
        public MultiSelectList AvailableCatalogs { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product code is required.")]
        [MaxLength(10, ErrorMessage = "The length of product code must be {1} characters or fewer.")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product description is required.")]
        [MaxLength(50, ErrorMessage = "The length of product description must be {1} characters or fewer.")]
        public string Description { get; set; }

        #endregion Properties
    }
}
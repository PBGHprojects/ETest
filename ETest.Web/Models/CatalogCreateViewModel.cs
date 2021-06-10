using System.ComponentModel.DataAnnotations;

namespace ETest.Web.Models
{
    /// <summary>
    /// Catalog create view model.
    /// </summary>
    public class CatalogCreateViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Catalog code is required.")]
        [MaxLength(10, ErrorMessage = "The length of catalog code must be {1} characters or fewer.")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Catalog description is required.")]
        [MaxLength(50, ErrorMessage = "The length of catalog description must be {1} characters or fewer.")]
        public string Description { get; set; }

        #endregion Properties
    }
}
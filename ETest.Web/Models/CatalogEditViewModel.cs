using System.ComponentModel.DataAnnotations;

namespace ETest.Web.Models
{
    /// <summary>
    /// Catalog edit view model.
    /// </summary>
    public class CatalogEditViewModel : CatalogCreateViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid ID")]
        public int Id { get; set; }

        #endregion Properties
    }
}
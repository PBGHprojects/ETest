using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ETest.Web.Models.Validation
{
    /// <summary>
    /// At least one.
    /// </summary>
    public class AtLeastOne : ValidationAttribute
    {
        #region Methods

        /// <summary>
        /// Determines whether the specified value contains at least one element.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public override bool IsValid(
            object value)
        {
            return (value as IList)?.Count > 0;
        }

        #endregion Methods
    }
}
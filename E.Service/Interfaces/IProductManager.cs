using E.Entities;

namespace E.Service.Interfaces
{
    /// <summary>
    /// Product manager contract.
    /// </summary>
    public interface IProductManager : IManager<Product>
    {
        #region Methods

        /// <summary>
        /// Gets product by id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Product GetById(int id);

        #endregion Methods
    }
}

using E.Entities;
using E.Service.Interfaces;
using ETest.Web.Models;
using System.Linq;
using System.Web.Http;

namespace ETest.Web.Controllers
{
    /// <summary>
    /// REST API product controller.
    /// </summary>
    [RoutePrefix("api/product")]
    public class RESTapiProductController : ApiController
    {
        #region Properties

        /// <summary>
        /// Gets the product manager.
        /// </summary>
        protected IProductManager ProductManager { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes REST API product controller.
        /// </summary>
        /// <param name="manager">Product manager</param>
        public RESTapiProductController(
            IProductManager manager)
        {
            ProductManager = manager;
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        [Route("find")]
        public IHttpActionResult Find(
            int catalogId)
        {
            if (catalogId < 1)
            {
                return BadRequest();
            }

            var result = ProductManager.Get(p => p.Catalog.Any(c => c.Id == catalogId));
            return Ok(result.Select(p => Map(p)));
        }

        #region Mapping

        private ProductRESTViewModel Map(
            Product model)
        {
            return new ProductRESTViewModel
            {
                Code = model.Code,
                Description = model.Description,
                Id = model.Id
            };
        }

        #endregion Mapping

        #endregion Methods
    }
}
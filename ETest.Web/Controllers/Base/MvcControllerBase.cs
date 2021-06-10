using System.Web.Mvc;

namespace ETest.Web.Controllers
{
    /// <summary>
    /// MVC controller base.
    /// </summary>
    public abstract class MvcControllerBase<TManager> : Controller
    {
        #region Properties

        /// <summary>
        /// Gets the manager.
        /// </summary>
        protected TManager Manager { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes MVC controller base.
        /// </summary>
        /// <param name="manager">Manager</param>
        public MvcControllerBase(
            TManager manager)
        {
            Manager = manager;
        }

        #endregion Constructors
    }
}
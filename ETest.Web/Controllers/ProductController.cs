using E.Entities;
using E.Service.Interfaces;
using ETest.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ETest.Web.Controllers
{
    /// <summary>
    /// Product controller.
    /// </summary>
    public class ProductController : MvcControllerBase<IProductManager>
    {
        #region Properties

        /// <summary>
        /// Gets the catalog manager.
        /// </summary>
        protected ICatalogManager CatalogManager { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes product controller.
        /// </summary>
        /// <param name="manager">Product manager</param>
        /// <param name="catalogManager">Catalog manager</param>
        public ProductController(
            IProductManager manager,
            ICatalogManager catalogManager)
            : base(manager)
        {
            CatalogManager = catalogManager;
        }

        #endregion Constructors

        #region Methods

        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductCreateViewModel
            {
                AvailableCatalogs = new MultiSelectList(CatalogManager.Get(), "Id", "Code")
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Create(Map(model));

                return ToIndex();
            }

            model.AvailableCatalogs = new MultiSelectList(CatalogManager.Get(), "Id", "Code");
            return View(model);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(
            int id)
        {
            var entity = Manager.GetById(id);
            if (entity == null)
            {
                return new HttpNotFoundResult();
            }

            Manager.Delete(entity);

            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public ActionResult Details(
            int id)
        {
            if (id < 1)
            {
                return HttpBadRequest();
            }

            var product = Manager.GetById(id);
            if (product == null)
            {
                return new HttpNotFoundResult();
            }

            return View(MapWithCatalogs(product));
        }

        [HttpGet]
        public ActionResult Edit(
            int id)
        {
            if (id < 1)
            {
                return HttpBadRequest();
            }

            var product = Manager.GetById(id);
            if (product == null)
            {
                return new HttpNotFoundResult();
            }

            var model = MapForEdit(product);
            model.AvailableCatalogs = new MultiSelectList(CatalogManager.Get(), "Id", "Code");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSave(
            ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Update(Map(model));

                return ToIndex();
            }

            model.AvailableCatalogs = new MultiSelectList(CatalogManager.Get(), "Id", "Code");
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Products = Manager
                .Get()
                .Select(p => Map(p));

            return View();
        }

        #region Private

        private HttpStatusCodeResult HttpBadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        private RedirectToRouteResult ToIndex()
        {
            return RedirectToAction("Index");
        }

        #endregion Private

        #region Mapping

        private Product Map(
            ProductCreateViewModel model)
        {
            return new Product
            {
                Catalog = CatalogManager.Get(c => model.CatalogIds.Any(id => id == c.Id)),
                Code = model.Code,
                Description = model.Description
            };
        }

        private ProductViewModel Map(
            Product model)
        {
            return new ProductViewModel
            {
                Code = model.Code,
                Description = model.Description,
                Id = model.Id
            };
        }

        private Product Map(
            ProductEditViewModel model)
        {
            return new Product
            {
                Id = model.Id,
                Catalog = CatalogManager.Get(c => model.CatalogIds.Any(id => id == c.Id)),
                Code = model.Code,
                Description = model.Description
            };
        }

        private ProductEditViewModel MapForEdit(
            Product model)
        {
            return new ProductEditViewModel
            {
                CatalogIds = model.Catalog?
                    .Select(c => c.Id)?
                    .ToList(),
                Code = model.Code,
                Description = model.Description
            };
        }

        private ProductWithCatalogViewModel MapWithCatalogs(
            Product model)
        {
            return new ProductWithCatalogViewModel
            {
                Catalogs = new List<CatalogViewModel>(
                    model.Catalog.Select(c =>
                    {
                        return new CatalogViewModel
                        {
                            Code = c.Code,
                            Description = c.Description,
                            Id = c.Id
                        };
                    })),
                Code = model.Code,
                Description = model.Description,
                Id = model.Id
            };
        }

        #endregion Mapping

        #endregion Methods
    }
}
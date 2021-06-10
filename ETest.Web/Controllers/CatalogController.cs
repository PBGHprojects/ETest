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
    /// Catalog controller.
    /// </summary>
    public class CatalogController : MvcControllerBase<ICatalogManager>
    {
        #region Properties

        /// <summary>
        /// Gets the product manager.
        /// </summary>
        protected IProductManager ProductManager { get; private set; }

        #endregion Properties

        #region Controllers

        /// <summary>
        /// Initializes catalog controller.
        /// </summary>
        /// <param name="manager">Manager</param>
        /// <param name="productManager">Product manager</param>
        public CatalogController(
            ICatalogManager manager,
            IProductManager productManager)
            : base(manager)
        {
            ProductManager = productManager;
        }

        #endregion Controllers

        #region Methods

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CatalogCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            CatalogCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Create(Map(model));

                return ToIndex();
            }

            return View(model);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(
            int id)
        {
            if (Manager.CanDeleteCatalog(id))
            {
                var entity = Manager.GetById(id);
                if (entity == null)
                {
                    return new HttpNotFoundResult();
                }

                Manager.Delete(entity);
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);
            }

            return new HttpStatusCodeResult(HttpStatusCode.Conflict);
        }

        [HttpGet]
        public ActionResult Details(
            int id)
        {
            if (id < 1)
            {
                return HttpBadRequest();
            }

            var catalog = Manager.GetById(id);
            if (catalog == null)
            {
                return new HttpNotFoundResult();
            }

            return View(MapWithProducts(catalog));
        }

        [HttpGet]
        public ActionResult Edit(
            int id)
        {
            if (id < 1)
            {
                return HttpBadRequest();
            }

            var catalog = Manager.GetById(id);
            if (catalog == null)
            {
                return new HttpNotFoundResult();
            }

            return View(MapForEdit(catalog));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSave(
            CatalogEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Manager.Update(Map(model));

                return ToIndex();
            }

            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Catalogs = Manager
                .Get()
                .Select(p => Map(p));

            ViewBag.Products = new MultiSelectList(ProductManager.Get(), "Id", "Code");

            return View();
        }

        [HttpGet]
        public PartialViewResult Search(
            int[] productIds)
        {
            ViewBag.Catalogs = Manager
                .Get(c => productIds?.Any(pid => c.Product?.Any(p => p.Id == pid) ?? false) ?? true)
                .Select(p => Map(p));

            return PartialView("_Index");
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

        private Catalog Map(
            CatalogCreateViewModel model)
        {
            return new Catalog
            {
                Code = model.Code,
                Description = model.Description
            };
        }

        private Catalog Map(
            CatalogEditViewModel model)
        {
            return new Catalog
            {
                Id = model.Id,
                Code = model.Code,
                Description = model.Description
            };
        }

        private CatalogEditViewModel MapForEdit(
            Catalog model)
        {
            return new CatalogEditViewModel
            {
                Code = model.Code,
                Description = model.Description
            };
        }

        private CatalogViewModel Map(
            Catalog model)
        {
            return new CatalogViewModel
            {
                Code = model.Code,
                Description = model.Description,
                Id = model.Id
            };
        }

        private CatalogWithProductsViewModel MapWithProducts(
            Catalog model)
        {
            return new CatalogWithProductsViewModel
            {
                Products = new List<ProductViewModel>(
                    model.Product.Select(c =>
                    {
                        return new ProductViewModel
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
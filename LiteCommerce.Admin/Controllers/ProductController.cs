using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int category = 0, int supplier = 0, string searchValue = "", int page = 1)
        {
            try
            {
                int rowCount = 0;
                int pageSize = 10;
                var model = ProductService.List(page, pageSize, category, supplier, searchValue, out rowCount);
                ViewBag.RowCount = rowCount;
                ViewBag.Page = page;

                int pageCount = rowCount / pageSize;
                if (rowCount % pageSize > 0)
                    pageCount++;
                ViewBag.PageCount = pageCount;
                return View(model);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

        }
        public ActionResult Edit(int id)
        {
            var model = ProductService.GetEx(id);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }
        public ActionResult DeleteAttributes(int id, long[] attributeIds)
        {
            if (attributeIds == null)
                return RedirectToAction("Edit", new { id = id });
            ProductService.DeleteAttribute(attributeIds);
            return RedirectToAction("Edit", new { id = id });
        }

        public ActionResult DeleteGallerys(int id, long[] galleryIds)
        {
            if (galleryIds == null)
                return RedirectToAction("Edit", new { id = id });
            ProductService.DeleteGallery(galleryIds);
            return RedirectToAction("Edit", new { id = id });
        }
        public ActionResult Delete(int id)
        {
            if (Request.HttpMethod == "POST")
            {
                ProductService.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                var model = ProductService.Get(id);
                if (model == null)
                    return RedirectToAction("Index");
                return View(model);
            }
        }
    }

}
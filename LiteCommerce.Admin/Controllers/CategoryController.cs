using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult List(int page = 1, string searchValue = "")
        {
            ViewBag.Title = "Quản lý loại hàng hóa";
            int rowCount = 0;
            int pageSize = 10;
            var listOfCategories = DataService.ListCategories(page, pageSize, searchValue, out rowCount);
            var model = new Models.CategoryPaginationQueryResult()
            {
                Page = page,
                PageSize = pageSize,
                SearchValue = searchValue,
                RowCount = rowCount,
                Data = listOfCategories
            };
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Thay đổi thông tin loại hàng hóa";
            var model = DataService.GetCategory(id);
            if (model == null)
                RedirectToAction("Index");
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewBag.Title = "Bổ sung thông tin loại hàng hóa";
            Category model = new Category()
            {
                CategoryID = 0
            };
            return View("Edit", model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            if (Request.HttpMethod == "POST")
            {
                DataService.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            else
            {
                var model = DataService.GetCategory(id);
                if (model == null)
                    RedirectToAction("Index");
                return View(model);
            }
        }

        public ActionResult Save(Category data)
        {
            try
            {
                //return Json(data);
                if (string.IsNullOrWhiteSpace(data.CategoryName))
                    ModelState.AddModelError("CategoryName", "Vui lòng nhập tên loại hàng hóa");
                if (string.IsNullOrWhiteSpace(data.Description))
                    data.Description = "";
                if (data.ParentCategoryId==0)
                    data.ParentCategoryId = 0;
                if (!ModelState.IsValid)
                {
                    if (data.CategoryID == 0)
                        ViewBag.Title = "Bổ sung thông tin loại hàng hóa";
                    else ViewBag.Title = "Thay đổi thông tin loại hàng hóa";
                    return View("Edit", data);
                }
                if (data.CategoryID == 0)
                    DataService.AddCategory(data);
                else DataService.UpdateCategory(data);
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Oops! trang này hình như không tồn tại :)");
            }
        }
    }
}
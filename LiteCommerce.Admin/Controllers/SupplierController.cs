using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List( int page, string searchValue = "")
        {
            
            int rowCount = 0;
            int pageSize = 10;
            var listOfSuppliers = DataService.ListSuppliers(page, pageSize, searchValue, out rowCount);
            var model = new Models.SupplierPaginationQueryResult()
            {
                
                Page = page,
                PageSize = pageSize,
                SearchValue = searchValue,
                RowCount = rowCount,
                Data = listOfSuppliers
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
            ViewBag.Title = "Thay đổi thông tin nhà cung cấp";
            var model = DataService.GetSupplier(id);
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
            ViewBag.Title = "Bổ sung thông tin nhà cung cấp";
            Supplier model = new Supplier()
            {
                SupplierID = 0
            };
            return View("Edit",model);
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
               
                //Xóa Supplier có mã là id
                DataService.DeleteSupplier(id);
                //Quay về trang Index
                return RedirectToAction("Index");
            }
            else
            {
                //Lấy thông tin của Supplier cần xóa
                var model = DataService.GetSupplier(id);
                if (model == null)
                    RedirectToAction("Index");
                return View(model); 
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(Supplier data)
        {
            try
            {
                //return Json(data);
                if (string.IsNullOrWhiteSpace(data.SupplierName))
                    ModelState.AddModelError("SupplierName", "Vui lòng nhập tên nhà cung cấp");
                if (string.IsNullOrWhiteSpace(data.ContactName))
                    ModelState.AddModelError("ContactName", "Bạn chưa nhập tên liên hệ của nhà cung cấp");
                if (string.IsNullOrWhiteSpace(data.Address))
                    data.Address = "";
                if (string.IsNullOrWhiteSpace(data.Country))
                    data.City = "";
                if (string.IsNullOrWhiteSpace(data.PostalCode))
                    data.PostalCode = "";
                if (string.IsNullOrWhiteSpace(data.Phone))
                    data.PostalCode = "";

                if (!ModelState.IsValid)
                {
                    if (data.SupplierID == 0)
                        ViewBag.Title = "Bổ sung nhà cung cấp mới";
                    else ViewBag.Title = "Thay đổi thông tin nhà cung cấp";
                    return View("Edit", data);
                }
                if (data.SupplierID == 0)
                    DataService.AddSupplier(data);
                else DataService.UpdateSupplier(data);
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Oops! trang này hình như không tồn tại :)");
            }
           
        }

    }
}
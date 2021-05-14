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
    public class EmployeeController : Controller
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
            int rowCount = 0;
            int pageSize = 5;
            var listOfEmployees = DataService.ListEmployees(page, pageSize, searchValue, out rowCount);
            var model = new Models.EmployeePaginationQueryResult()
            {
                Page = page,
                PageSize = pageSize,
                SearchValue = searchValue,
                RowCount = rowCount,
                Data = listOfEmployees
            };
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewBag.Title = "Bổ sung thông tin nhân viên";
            Employee model = new Employee()
            {
                EmployeeID = 0
            };
            return View("Edit", model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Chỉnh sửa thông tin nhân viên";
            var model = DataService.GetEmployee(id);
            if (model == null)
                RedirectToAction("Index");
            return View(model);
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
                DataService.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            else
            {
                var model = DataService.GetEmployee(id);
                if (model == null)
                    RedirectToAction("Index");
                return View(model);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(Employee data)
        {
            try
            {
                //return Json(data);
                if (string.IsNullOrWhiteSpace(data.LastName))
                    ModelState.AddModelError("LastName", "Vui lòng nhập họ nhân viên");
                if (string.IsNullOrWhiteSpace(data.FirstName))
                    ModelState.AddModelError("FirstName", "Bạn chưa nhập tên nhân viên");
                if (string.IsNullOrWhiteSpace(data.Photo))
                    data.Photo = "";
                if (string.IsNullOrWhiteSpace(data.Notes))
                    data.Notes = "";
                if (string.IsNullOrWhiteSpace(data.Email))
                    data.Email = "";
                if (string.IsNullOrWhiteSpace(data.Password))
                    data.Password = "";

                if (!ModelState.IsValid)
                {
                    if (data.EmployeeID == 0)
                        ViewBag.Title = "Bổ sung thông tin nhân viên";
                    else ViewBag.Title = "Chỉnh sửa thông tin nhân viên";
                    return View("Edit", data);
                }
                data.Password = CryptHelper.Md5(data.Password);
                if (data.EmployeeID == 0)
                    DataService.AddEmployee(data);
                else DataService.UpdateEmployee(data);
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Oops! trang này hình như không tồn tại :)");
            }
        }
    }
}
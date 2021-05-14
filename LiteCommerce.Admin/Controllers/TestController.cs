using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiteCommerce.DataLayers;
using LiteCommerce.DataLayers.SQLServer;
using LiteCommerce.DomainModels;
namespace LiteCommerce.Admin.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LiteCommerceDB"].ConnectionString;
            //ICountryDAL dal = new CountryDAL(connectionString);
            //var data = dal.List();
            //ICityDAL dal = new CityDAL(connectionString);
            //var data = dal.List("USA");
            //ISupplierDAL dal = new SupplierDAL(connectionString);
            //var data = dal.List(1, 10, "");
            //ICategoryDAL dal = new CategoryDAL(connectionString);
            //var data = dal.List(1, 10, "");
            //IShipperDAL dal = new ShipperDAL(connectionString);
            //var data = dal.List(1, 10, "");
            //IEmployeeDAL dal = new EmployeeDAL(connectionString);
            //var data = dal.List(1, 10, "");
            //ICustomerDAL dal = new CustomerDAL(connectionString);
            //var data = dal.List(1, 10, "");
            IEmployeeDAL dal = new EmployeeDAL(connectionString);
            //var data = dal.Get(1);
            Employee s = new Employee()
            {
                EmployeeID = 11,
                LastName = "Nguyen huu ",
                FirstName = "Thanh",
                BirthDate= DateTime.Today,
                Photo= "k cos",
                Notes = "hoc dot + nhiet tinh",
               Email = "thanhngu@husc.edu.vn",
               Password = "123",
              
             

            };
            //bool data = dal.Update(s);
            var data = dal.Count("");
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
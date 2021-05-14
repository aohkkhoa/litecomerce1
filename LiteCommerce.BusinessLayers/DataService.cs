using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;

namespace LiteCommerce.BusinessLayers
{
    /// <summary>
    /// Các chức năng nghiệp vụ liên quan đến quản lý dữ liệu chung
    /// </summary>
    public static class DataService
    {
        private static ICountryDAL CountryDB;
        private static ICityDAL CityDB;
        private static ISupplierDAL SupplierDB;
        private static ICategoryDAL CategoryDB;
        private static ICustomerDAL CustomerDB;
        private static IEmployeeDAL EmployeeDB;
        private static IShipperDAL ShipperDB;
        /// <summary>
        /// Khởi tạo tính năng tác nghiệp (hàm này phải được gọi nếu muốn sử dụng các tính năng của lớp)
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="connectionString"></param>
        public static void Init(DatabaseTypes dbType, string connectionString)
        {
            switch (dbType)
            {
                case DatabaseTypes.SQLServer:
                    CountryDB = new DataLayers.SQLServer.CountryDAL(connectionString);
                    CityDB = new DataLayers.SQLServer.CityDAL(connectionString);
                    SupplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);
                    CategoryDB = new DataLayers.SQLServer.CategoryDAL(connectionString);
                    CustomerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
                    EmployeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
                    ShipperDB = new DataLayers.SQLServer.ShipperDAL(connectionString);
                    break;
                default:
                    throw new Exception("Database type is not supported");
            }
        }

        public static object List(int page, int pageSize, string searchValue, out int rowCount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Danh sách các thành phố
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListCountries()
        {
            return CountryDB.List();
        }
        /// <summary>
        /// Danh sách các thành phố
        /// </summary>
        /// <returns></returns>
        public static List<City> ListCities()
        {
            return CityDB.List();
        }
        /// <summary>
        /// Danh sách các thành phố thuộc quốc gia
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        public static List<City> ListCities(string countryName)
        {
            return CityDB.List(countryName);
        }
        /// <summary>
        /// Danh sách nhà cung cấp (tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Supplier> ListSuppliers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = SupplierDB.Count(searchValue);
            return SupplierDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// Thêm nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data)
        {
            return SupplierDB.Add(data);
        }
        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return SupplierDB.Update(data);
        }
        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int supplierId)
        {
            return SupplierDB.Delete(supplierId);
        }
        /// <summary>
        /// Lấy thông tin 1 nhà cung cấp
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierId)
        {
            return SupplierDB.Get(supplierId);
        }
        /// <summary>
        /// Lấy danh sách loại hàng hóa (tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Category> ListCategories(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = CategoryDB.Count(searchValue);
            return CategoryDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// Thêm loại hàng hóa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCategory(Category data)
        {
            return CategoryDB.Add(data);
        }
        /// <summary>
        /// Cập nhật loại hàng hóa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCategory(Category data)
        {
            return CategoryDB.Update(data);
        }
        /// <summary>
        /// Xóa loại hàng hóa
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int categoryId)
        {
            return CategoryDB.Delete(categoryId);
        }
        /// <summary>
        /// Lấy thông tin 1 loại hàng hóa
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static Category GetCategory(int categoryId)
        {
            return CategoryDB.Get(categoryId);
        }
        /// <summary>
        /// Lấy danh sách khách hàng (tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Customer> ListCustomers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = CustomerDB.Count(searchValue);
            return CustomerDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddCustomer(Customer data)
        {
            return CustomerDB.Add(data);
        }
        /// <summary>
        /// Cập nhật khách hàng
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateCustomer(Customer data)
        {
            return CustomerDB.Update(data);
        }
        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static bool DeleteCustomer(int customerId)
        {
            return CustomerDB.Delete(customerId);
        }
        /// <summary>
        /// Lấy thông tin 1 khách hàng
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static Customer GetCustomer(int customerId)
        {
            return CustomerDB.Get(customerId);
        }
        /// <summary>
        /// Lấy danh sách nhân viên (tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Employee> ListEmployees(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = EmployeeDB.Count(searchValue);
            return EmployeeDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddEmployee(Employee data)
        {
            return EmployeeDB.Add(data);
        }
        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateEmployee(Employee data)
        {
            return EmployeeDB.Update(data);
        }
        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static bool DeleteEmployee(int employeeId)
        {
            return EmployeeDB.Delete(employeeId);
        }
        /// <summary>
        /// Lấy thông tin 1 nhà cung cấp
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public static Employee GetEmployee(int employeeId)
        {
            return EmployeeDB.Get(employeeId);
        }
        /// <summary>
        /// Danh sách nhà vận chuyển (tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public static List<Shipper> ListShippers(int page, int pageSize, string searchValue, out int rowCount)
        {
            rowCount = ShipperDB.Count(searchValue);
            return ShipperDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// Thêm nhà vận chuyển
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddShipper(Shipper data)
        {
            return ShipperDB.Add(data);
        }
        /// <summary>
        /// Cập nhật nhà vận chuyển
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateShipper(Shipper data)
        {
            return ShipperDB.Update(data);
        }
        /// <summary>
        /// Xóa nhà vận chuyển
        /// </summary>
        /// <param name="shipperId"></param>
        /// <returns></returns>
        public static bool DeleteShipper(int shipperId)
        {
            return ShipperDB.Delete(shipperId);
        }
        /// <summary>
        /// Lấy thông tin 1 nhà vận chuyển
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public static Shipper GetShipper(int shipperId)
        {
            return ShipperDB.Get(shipperId);
        }
        /// <summary>
        /// lấy danh sách id và tên loại hàng hóa
        /// </summary>
        /// <returns></returns>
        public static List<Category> ListParentCategories()
        {
            return CategoryDB.ListParentCategories();
        }
    }
}

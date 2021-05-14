using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.BusinessLayers
{
    /// <summary>
    /// Lớp cung cấp các chức năng tác nghiệp liên quan đến quản lý nhân sự
    /// </summary>
    public static class HRService
    {
        private static IEmployeeDAL EmployeeDB;
        /// <summary>
        /// Khởi tạo tầng nghiệp vụ 
        /// (Hàm này phải được gọi trước khi sử dụng các chức năng khác trong lớp)
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="connectionString"></param>
        public static void Init(DatabaseTypes dbType, string connectionString)
        {
            switch (dbType)
            {
                case DatabaseTypes.SQLServer:
                    EmployeeDB = new LiteCommerce.DataLayers.SQLServer.EmployeeDAL(connectionString);
                    break;
                case DatabaseTypes.FakeDB:

                    break;
                default:
                    throw new Exception("Database Type is not supported");
            }
        }

        public static List<Employee> Employee_List()
        {
            return EmployeeDB.List(1,10,"");
        }
    }
}

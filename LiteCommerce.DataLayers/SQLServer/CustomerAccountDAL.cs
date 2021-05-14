using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SQLServer
{
    /// <summary>
    /// Cài đặt chức năng liên quan đến tài khoản khách hàng
    /// </summary>
    public class CustomerAccountDAL:_BaseDAL, IAccountDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public CustomerAccountDAL(string connectionString) : base(connectionString)
        {

        }

        public Account Authorze(string loginName, string password)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(int accountId, string oldpassword, string newpassword)
        {
            throw new NotImplementedException();
        }

        public Account Get(string accountId)
        {
            throw new NotImplementedException();
        }
    }
}

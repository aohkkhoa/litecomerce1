using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace LiteCommerce.Admin
{
    public static class CookieHelper

    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string AccountToCookieString(Account data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static Account CookieStringToAccount(string cookie)
        {
            return JsonConvert.DeserializeObject<Account>(cookie);
        }
    }
}
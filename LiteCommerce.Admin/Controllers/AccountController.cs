using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login( string loginName = "", string password = "")
        {
            ViewBag.LoginName = loginName;
            if (Request.HttpMethod == "POST")
            {
                var account = AccountService.Authorize(loginName, CryptHelper.Md5(password));
                if (account == null)
                {
                    ModelState.AddModelError("", "Thông tin đăng nhập bị sai");
                    return View();
                }
                System.Web.Security.FormsAuthentication.SetAuthCookie(CookieHelper.AccountToCookieString(account), false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }
        [Authorize]
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        [Authorize]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newpassword"></param>
        /// <returns></returns>
        public ActionResult ChangePassword(int accountId , string oldpassword= "", string newpassword = "")
        {
            try
            {
                if (Request.HttpMethod == "POST")
                {
                    var model = CookieHelper.CookieStringToAccount(User.Identity.Name);
                    var account = AccountService.Authorize(model.Email, CryptHelper.Md5(oldpassword));
                    if (account == null)
                        ModelState.AddModelError("oldpassword", "Mật khẩu không đúng");
                    if (string.IsNullOrWhiteSpace(newpassword))
                        ModelState.AddModelError("newpassword", "Vui lòng nhập mật khẩu mới");
                    if (!ModelState.IsValid)
                        return View();
                    AccountService.ChangePassword(Convert.ToInt32(account.UserName), CryptHelper.Md5(oldpassword), CryptHelper.Md5(newpassword));
                    return RedirectToAction("Logout");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return Content("Oops! trang này hình như không tồn tại :)");
            }
        }
    }
}
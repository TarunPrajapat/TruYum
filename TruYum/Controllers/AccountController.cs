using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TruYum.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            if(username=="admin" && password=="admin")
            {
                FormsAuthentication.SetAuthCookie(username, false);
                FormsAuthentication.RedirectFromLoginPage(username, false);
            }
            return RedirectToAction("CustomerIndex","MenuItems");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("HomePage","MenuItems");
        }
    }
}
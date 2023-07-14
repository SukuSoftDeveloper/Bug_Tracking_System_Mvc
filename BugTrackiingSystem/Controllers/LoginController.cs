using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using BugTrackiingSystem.Models;

namespace BugTrackiingSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblLogin item, string returnUrl)
        {
            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            var loginvalue = db.tblLogins.Where(x => x.Username == item.Username && x.Password==item.Password).FirstOrDefault();
            if (loginvalue != null)
            {
                FormsAuthentication.SetAuthCookie(loginvalue.Username, false);
                if (loginvalue.Role=="Admin")
                {
                    return RedirectToAction("Main", "Home");
                }
                else if (loginvalue.Role=="Developer")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (loginvalue.Role == "Lead")
                {
                    return RedirectToAction("Main", "Home");
                }


                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                   && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {

                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ModelState.AddModelError("", "You Have Entered Wrong Username or Password.");
                return View();

            }
         }
      
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(tblLogin tb)
        {

            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            if (ModelState.IsValid)
            {
                var DoesUsernameExists = db.tblLogins.Any(x => x.Username == tb.Username && x.Password ==tb.Password &&x.Role==tb.Role);
                if (DoesUsernameExists)
                {
                    ModelState.AddModelError("", "Username Already exists");
                    return View(tb);
                }
                else
                {
                    db.tblLogins.Add(tb);
                    db.SaveChanges();
                    TempData["msg"] = "User Registered Successfully.";

                    return View();
                }

               

            }

            return View(tb);
           
        }
        [HttpGet]
     
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}
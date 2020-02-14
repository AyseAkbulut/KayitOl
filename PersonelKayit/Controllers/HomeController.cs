using PersonelKayit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelKayit.Controllers
{
    public class HomeController : Controller
    {
        UserDbContext db = new UserDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var log = db.Users.Where(a => a.Name.Equals(user.Name) && a.Password.Equals(user.Password)).FirstOrDefault();
                if (log != null)
                {
                    Session["Name"] = log.Name.ToString();
                    Session["Password"] = log.Password.ToString();
                    Session["Status"] = log.Status.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginError = "Kullanıcı adı veya şifre hatalı ! ";

                }
            }
            return View();

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
        [HttpGet]
        public ActionResult UserCreate()
        {
            return View();
        }


        [HttpPost]
        [LoginControl]
        public ActionResult UserCreate(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Users.Add(user);
            db.SaveChanges();

            ViewBag.Return = "Kaydetme işleminiz gerçekleşti.";
            return RedirectToAction("UserCreate");
        }
    }
}
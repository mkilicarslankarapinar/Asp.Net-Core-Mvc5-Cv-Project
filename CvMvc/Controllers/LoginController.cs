using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CvMvc.Models.Entity;
using CvMvc.Repositories;

namespace CvMvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities2 db = new DbCvEntities2();
            var info = db.TblAdmin.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.UserName,false);
                Session["UserName"] = info.UserName.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
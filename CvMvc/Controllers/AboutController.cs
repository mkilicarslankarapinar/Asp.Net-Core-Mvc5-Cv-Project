using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;
using CvMvc.Repositories;

namespace CvMvc.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }
        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Mail = p.Mail;
            t.Name = p.Name;
            t.Telephone = p.Telephone;
            t.About = p.About;
            t.Image = p.Image;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
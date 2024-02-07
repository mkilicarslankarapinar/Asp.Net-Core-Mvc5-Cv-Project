using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;
using CvMvc.Repositories;

namespace CvMvc.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<TblMyEducations> repo = new GenericRepository<TblMyEducations>();
        [Authorize]
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblMyEducations p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            repo.TDelete(education);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult EditEducation(TblMyEducations t)
        {
            var education = repo.Find(x => x.ID == t.ID);
            education.Header = t.Header;
            education.SubHeader1 = t.SubHeader1;
            education.SubHeader2 = t.SubHeader2;
            education.Date = t.Date;
            education.GPA = t.GPA;
            repo.TUpdate(education);
            return RedirectToAction("Index");
        }
    }
}
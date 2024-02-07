using CvMvc.Models.Entity;
using CvMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvMvc.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        GenericRepository<TblMyExperiences> repo = new GenericRepository<TblMyExperiences>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblMyExperiences p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            TblMyExperiences t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            TblMyExperiences t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetExperience(TblMyExperiences p)
        {
            TblMyExperiences t = repo.Find(x => x.ID == p.ID);
            t.Header = p.Header;
            t.SubHeader = p.SubHeader;
            t.Date = p.Date;
            t.Explanation = p.Explanation;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
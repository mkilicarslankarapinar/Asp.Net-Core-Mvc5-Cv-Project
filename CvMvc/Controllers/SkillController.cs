using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;
using CvMvc.Repositories;

namespace CvMvc.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        GenericRepository<TblSkills> repo = new GenericRepository<TblSkills>();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult NewSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSkill(TblSkills p)
        {
            repo.TAdd(p);
            return View("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            repo.TUpdate(skill);
            return View(skill);
        }
        [HttpPost]
        public ActionResult EditSkill(TblSkills t)
        {
            var s = repo.Find(x => x.ID == t.ID);
            s.Skills = t.Skills;
            s.Percentage = t.Percentage;
            repo.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}
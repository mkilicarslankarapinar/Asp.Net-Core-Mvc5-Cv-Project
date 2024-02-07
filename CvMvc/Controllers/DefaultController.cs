using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;

namespace CvMvc.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        // GET: Default
        DbCvEntities2 db = new DbCvEntities2();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia()
        {
            var socialMedia = db.TblSocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(socialMedia);
        }

        public PartialViewResult Experience()
        {
            var experience = db.TblMyExperiences.ToList();
            return PartialView(experience);
        }
        public PartialViewResult Education()
        {
            var education = db.TblMyEducations.ToList();
            return PartialView(education);
        }
        public PartialViewResult Skill()
        {
            var skill = db.TblSkills.ToList();
            return PartialView(skill);
        }
        public PartialViewResult Hobby()
        {
            var hobby = db.TblMyHobbies.ToList();
            return PartialView(hobby);
        }
        public PartialViewResult Certificate()
        {
            var certificate = db.TblMyCertificates.ToList();
            return PartialView(certificate);
        }
        [HttpGet]
        public PartialViewResult Communication()
        {
            var communication = db.TblCommunication.ToList();
            return PartialView(communication);
        }
        [HttpPost]
        public PartialViewResult Communication(TblCommunication t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblCommunication.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}
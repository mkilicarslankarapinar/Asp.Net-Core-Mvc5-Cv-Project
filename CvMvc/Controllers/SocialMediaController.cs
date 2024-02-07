using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;
using CvMvc.Repositories;

namespace CvMvc.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<TblSocialMedia> repo = new GenericRepository<TblSocialMedia>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetSocialMedia(int id)
        {
            var account = repo.Find(x => x.ID == id);
            return View(account);
        }
        [HttpPost]
        public ActionResult GetSocialMedia(TblSocialMedia p)
        {
            var account = repo.Find(x => x.ID == p.ID);
            account.Name = p.Name;
            account.Status = true;
            account.Link = p.Link;
            account.Icon = p.Icon;
            repo.TUpdate(account);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var account = repo.Find(x => x.ID == id);
            account.Status = false;
            repo.TUpdate(account);
            return RedirectToAction("Index");
        }
    }
}
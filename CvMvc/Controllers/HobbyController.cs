using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;
using CvMvc.Repositories;

namespace CvMvc.Controllers
{
    public class HobbyController : Controller
    {
        // GET: Hobby
        GenericRepository<TblMyHobbies> repo = new GenericRepository<TblMyHobbies>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobbies = repo.List();
            return View(hobbies);
        }
        [HttpPost]
        public ActionResult Index(TblMyHobbies p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Explanation1 = p.Explanation1;
            t.Explanation2 = p.Explanation2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;
using CvMvc.Repositories;

namespace CvMvc.Controllers
{
    public class CertificatesController : Controller
    {
        // GET: Certificates

        GenericRepository<TblMyCertificates> repo = new GenericRepository<TblMyCertificates>();
        public ActionResult Index()
        {
            var certificate = repo.List();
            return View(certificate);
        }
        [HttpGet]
        public ActionResult GetCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(certificate);
        }
        [HttpPost]
        public ActionResult GetCertificate(TblMyCertificates t)
        {
            var certificate = repo.Find(x => x.ID == t.ID);
            certificate.Explanation = t.Explanation;
            certificate.Date = t.Date;
            repo.TUpdate(certificate);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(TblMyCertificates p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var certificate = repo.Find(x => x.ID == id);
            repo.TDelete(certificate);
            return RedirectToAction("Index");
        }
    }
}
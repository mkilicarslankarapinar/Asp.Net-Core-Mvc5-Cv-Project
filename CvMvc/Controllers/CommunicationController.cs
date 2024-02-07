using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvMvc.Models.Entity;
using CvMvc.Repositories;

namespace CvMvc.Controllers
{
    public class CommunicationController : Controller
    {
        // GET: Communictaion
        GenericRepository<TblCommunication> repo = new GenericRepository<TblCommunication>();
        public ActionResult Index()
        {
            var messages = repo.List();
            return View(messages);
        }
    }
}
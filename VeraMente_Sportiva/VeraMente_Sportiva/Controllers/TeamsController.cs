using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VeraMente_Sportiva.Controllers
{
    public class TeamsController : Controller
    {
        public ActionResult Index(string championship)
        {
            ViewBag.Championship = championship;
            return View();
        }

        public ActionResult Team(string championship)
        {
            return PartialView();
        }
    }
}
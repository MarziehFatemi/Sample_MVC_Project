using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Hiexpert.Areas.DoctorsArea.Controllers
{
    public class DefaultController : Controller
    {
        // GET: DoctorsArea/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Hiexpert.Areas.DoctorsArea.Controllers
{
    public class TestController : Controller
    {
        // GET: DoctorsArea/Test
        public ActionResult Index()
        {
            return View();
        }

        // GET: DoctorsArea/Test/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorsArea/Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorsArea/Test/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorsArea/Test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorsArea/Test/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorsArea/Test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorsArea/Test/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

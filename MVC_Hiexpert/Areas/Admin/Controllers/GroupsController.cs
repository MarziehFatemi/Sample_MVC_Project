using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hiexpert_Service.Service;
using MVC_Hiexpert.App_Start;
using MVC_Hiexpert.Models.ViewModel.Group_ViewModel;
using Project_Model.Context;
using Project_Model.Model;

namespace MVC_Hiexpert.Areas.Admin.Controllers
{
    public class GroupsController : Controller
    {
        private Hiexpert_Context db = new Hiexpert_Context();

        private Group_Service Gr_Service;
        public GroupsController()
        {
            Gr_Service = new Group_Service(db); 
        }



        // GET: Admin/Groups
        public ActionResult Index()
        {
            List<Group> G = Gr_Service.GetAll().ToList();
            List<Group_ViewModel> GM = AutoMapperConfig.mapper.Map<List<Group>, List<Group_ViewModel>>(G); 

            return View(GM);
        }

        // GET: Admin/Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = Gr_Service.GetEntity(id.Value);
            Group_ViewModel GM = AutoMapperConfig.mapper.Map<Group, Group_ViewModel>(group);

            if (group == null)
            {
                return HttpNotFound();
            }
            return View(GM);
        }

        // GET: Admin/Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupName")] Group_ViewModel NewG)
        {
            if (ModelState.IsValid)
            {
                Group group = AutoMapperConfig.mapper.Map< Group_ViewModel, Group>(NewG);

                Gr_Service.AddEntity(group);
                Gr_Service.Save(); 
                
                return RedirectToAction("Index");
            }

            return View(NewG);
        }

        // GET: Admin/Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = Gr_Service.GetEntity(id.Value);
            Group_ViewModel GM = AutoMapperConfig.mapper.Map<Group, Group_ViewModel>(group);

            if (group == null)
            {
                return HttpNotFound();
            }
            return View(GM);
        }

        // POST: Admin/Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupName")] Group_ViewModel EditedG)
        {
            if (ModelState.IsValid)
            {
                Group group = AutoMapperConfig.mapper.Map<Group_ViewModel, Group>(EditedG);

                Gr_Service.UpdateEntity(group);
                Gr_Service.Save(); 
                 return RedirectToAction("Index");
            }
            return View(EditedG);
        }

        // GET: Admin/Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Group group =Gr_Service.GetEntity(id.Value);
            Group_ViewModel GM = AutoMapperConfig.mapper.Map<Group, Group_ViewModel>(group);

            if (group == null)
            {
                return HttpNotFound();
            }
            return View(GM);
        }

        // POST: Admin/Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             Gr_Service.DeleteEntity(id); // db.Groups.Find(id);
             Gr_Service.Save(); 
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Gr_Service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

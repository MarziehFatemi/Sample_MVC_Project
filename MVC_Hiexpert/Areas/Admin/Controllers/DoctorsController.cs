using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Model.Context;
using Project_Model.Model;
using Hiexpert_Service.Service;
using MVC_Hiexpert.App_Start;
using MVC_Hiexpert.Models.ViewModel;

namespace MVC_Hiexpert.Areas.Admin.Controllers
{
    public class DoctorsController : Controller
    {
        private Hiexpert_Context db = new Hiexpert_Context();
        Doctor_Service Dr_Service;
        public DoctorsController()
        {
            Dr_Service = new Doctor_Service(db);
        }
         

        // GET: Admin/Doctors
        public ActionResult Index()
        {

           var DrModel = Dr_Service.GetAll().ToList();

           var DrViewModel = AutoMapperConfig.mapper.Map<List<Doctor>, List<Dr_abs_ViewModel>>(DrModel);
            

            return View(DrViewModel);
        }

        // GET: Admin/Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = Dr_Service.GetEntity(id.Value);

            var Detailed_Dr = AutoMapperConfig.mapper.Map<Doctor, Dr_DetailsViewModel>(doctor); 
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(Detailed_Dr);
        }

        // GET: Admin/Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Phone,Name,Password,CardNumber,AccountNumber")] Dr_Create_ViewModel NewDr)
        {
            if (ModelState.IsValid)
            {
                Doctor CompletedDr = AutoMapperConfig.mapper.Map<Dr_Create_ViewModel, Doctor>(NewDr);
                CompletedDr.TotalSale = 0;
                CompletedDr.TotalIncome = 0;
                CompletedDr.TotalCheckedOut = 0;
                CompletedDr.Credit = 0;
                CompletedDr.CommissionPercent = 50; 
                CompletedDr.RegisterDate = DateTime.Now;
                CompletedDr.IsActive = true; 


                Dr_Service.AddEntity(CompletedDr);
                Dr_Service.Save(); 
                return RedirectToAction("Index");
            }

            return View(NewDr);
        }

        // GET: Admin/Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = Dr_Service.GetEntity(id.Value);

            Dr_Edit_ViewModel Dr4Edit = AutoMapperConfig.mapper.Map<Doctor, Dr_Edit_ViewModel>(doctor);


            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(Dr4Edit);
        }

        // POST: Admin/Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,Phone,Name,IsActive,CardNumber,AccountNumber,CommissionPercent")] Dr_Edit_ViewModel EditedDr)
        {
            if (ModelState.IsValid)
            {
               
                Doctor dr = Dr_Service.GetEntity(EditedDr.DoctorId);

                dr.Phone = EditedDr.Phone;
                dr.Name = EditedDr.Name;
                dr.IsActive = EditedDr.IsActive;
                dr.CardNumber= EditedDr.CardNumber;
                dr.AccountNumber= EditedDr.AccountNumber;
                dr.CommissionPercent = EditedDr.CommissionPercent;
                
                Dr_Service.UpdateEntity(dr);
                Dr_Service.Save(); 
            
                return RedirectToAction("Index");
            }
            return View(EditedDr);
        }

        // GET: Admin/Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = Dr_Service.GetEntity(id.Value);
            var Detailed_Dr = AutoMapperConfig.mapper.Map<Doctor, Dr_DetailsViewModel>(doctor);

            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(Detailed_Dr);
        }

        // POST: Admin/Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dr_Service.DeleteEntity(id);
            Dr_Service.Save(); 
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Dr_Service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

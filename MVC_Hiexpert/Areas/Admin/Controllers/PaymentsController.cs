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
using MVC_Hiexpert.Models.ViewModel.Payment_ViewModel;
using Project_Model.Context;
using Project_Model.Model;

namespace MVC_Hiexpert.Areas.Admin.Controllers
{
    public class PaymentsController : Controller
    {
        private Hiexpert_Context db = new Hiexpert_Context();

        Payment_Service P_Service;
        Doctor_Service Dr_Service;
        public PaymentsController()
        {
            P_Service = new Payment_Service(db);
            Dr_Service = new Doctor_Service(db);
        }

        // GET: Admin/Payments
        public ActionResult Index()
        {

            List<Payment> Pay = P_Service.GetAll().ToList();

            var Pay_Model = AutoMapperConfig.mapper.Map<List<Payment>, List<Payment_ViewModel>>(Pay);
            for (int k = 0; k < Pay.Count; k++)
            {
                Doctor Dr = Dr_Service.GetEntity(Pay[k].DoctorId);
                if (Dr != null)
                { Pay_Model[k].DoctorName = Dr.Name; }
            }

             return View(Pay_Model);

           
        }

        // GET: Admin/Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = P_Service.GetEntity(id.Value);
            if (payment == null)
            {
                return HttpNotFound();
            }
            var PayModel = AutoMapperConfig.mapper.Map<Payment, Payment_ViewModel>(payment);


            Doctor Dr = Dr_Service.GetEntity(payment.DoctorId);
            PayModel.DoctorName = Dr.Name;
            return View(PayModel);
            
        }

        // GET: Admin/Payments/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(Dr_Service.GetAll(), "DoctorId", "Name");

            return View();
        }

        // POST: Admin/Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,PaymentId,PayedMoney,PayedTime,PaymentNumber")] Payment_ViewModel PayModel)
        {
            if (ModelState.IsValid)
            {
                var payment = AutoMapperConfig.mapper.Map< Payment_ViewModel, Payment>(PayModel);


                P_Service.AddEntity(payment);
                P_Service.Save();


                Dr_Service.AddCheckOutToDoctor(Dr_Service.GetEntity(payment.DoctorId), payment.PayedMoney);
                Dr_Service.UpdateEntity(Dr_Service.GetEntity(payment.DoctorId));
                Dr_Service.Save();


                return RedirectToAction("Index");
            }

            return View(PayModel);
        }

        // GET: Admin/Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = P_Service.GetEntity(id.Value);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Admin/Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentId,PayedMoney,PayedTime,PaymentNumber")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                P_Service.UpdateEntity(payment);
                P_Service.Save(); 
                
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        // GET: Admin/Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = P_Service.GetEntity(id.Value);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Admin/Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             P_Service.DeleteEntity(id);
            P_Service.Save(); 
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              P_Service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

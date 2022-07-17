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
using MVC_Hiexpert.Models.ViewModel.Appointment_ViewModel;
using Project_Model.Context;
using Project_Model.Model;

namespace MVC_Hiexpert.Areas.Admin.Controllers
{
    public class AppointmentsController : Controller
    {
        private Hiexpert_Context db = new Hiexpert_Context();

        Appointment_Service Ap_Service; 
        Customer_Service C_Service;
        Doctor_Service Dr_Service;
        Group_Service G_Service; 
        public AppointmentsController()
        {
            Ap_Service = new Appointment_Service(db);
            C_Service = new Customer_Service(db);
            Dr_Service = new Doctor_Service(db);
            G_Service = new Group_Service(db);
        }

        // GET: Admin/Appointments
        public ActionResult Index()
        {
            List<Appointment> Ap = Ap_Service.GetAll().ToList();

            var ApModel = AutoMapperConfig.mapper.Map<List<Appointment>, List<Appointment_List_ViewModel>>(Ap);
            for (int k = 0; k < Ap.Count; k++)
            {
                Customer C = C_Service.GetEntity(Ap[k].CustomerId);
                Doctor Dr = Dr_Service.GetEntity(Ap[k].DoctorId);
                ApModel[k].CustomerName = C.Name;
                ApModel[k].DoctorName = Dr.Name;
            }

            //var appointments = db.Appointments.Include(a => a.Customer).Include(a => a.Doctor).Include(a => a.Group);
            return View(ApModel);
        }

        // GET: Admin/Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = Ap_Service.GetEntity(id.Value);
            


            if (appointment == null)
            {
                return HttpNotFound();
            }

            var ApModel = AutoMapperConfig.mapper.Map<Appointment, Appointment_Detail_ViewModel>(appointment);


            Customer C = C_Service.GetEntity(appointment.CustomerId);
            Doctor Dr = Dr_Service.GetEntity(appointment.DoctorId);
            Group Gr = G_Service.GetEntity(appointment.GroupId);
            ApModel.CustomerName = C.Name;
            ApModel.DoctorName = Dr.Name;
            ApModel.GroupName = Gr.GroupName;
            return View(ApModel);
        }


        // GET: Admin/Appointments/Create
        public ActionResult Create()
        {
            
            ViewBag.CustomerId = new SelectList(C_Service.GetAll(), "CustomerId", "Name");
            ViewBag.DoctorId = new SelectList(Dr_Service.GetAll(), "DoctorId", "Name");
            ViewBag.GroupId = new SelectList(G_Service.GetAll(), "GroupId", "GroupName");
            return View();
        }

        // POST: Admin/Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,DoctorId,GroupId,DateOfVisit,NumberOfSessions,Payment,PaymentNumber")] Appointment_Detail_ViewModel appointment)
        {
            if (ModelState.IsValid)
            {
                
                Appointment Converted_Ap = AutoMapperConfig.mapper.Map<Appointment_Detail_ViewModel, Appointment>(appointment); 
                Ap_Service.AddEntity(Converted_Ap);
                Ap_Service.Save();

                
               
                // update info of customer  and save 
                 
                C_Service.AddValuesToCustomer(C_Service.GetEntity(appointment.CustomerId), appointment.Payment, appointment.NumberOfSessions);
                C_Service.UpdateEntity(C_Service.GetEntity(appointment.CustomerId));
                C_Service.Save();

                // update info of Doctor  and save 
                Dr_Service.AddValuesToDoctor(Dr_Service.GetEntity(appointment.DoctorId), appointment.Payment);
                Dr_Service.UpdateEntity(Dr_Service.GetEntity(appointment.DoctorId));
                Dr_Service.Save();

                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(C_Service.GetAll(), "CustomerId", "Name", appointment.CustomerId);
            ViewBag.DoctorId = new SelectList(Dr_Service.GetAll(), "DoctorId", "Name", appointment.DoctorId);
            ViewBag.GroupId = new SelectList(G_Service.GetAll(), "GroupId", "GroupName", appointment.GroupId);
            return View(appointment);
        }

        // GET: Admin/Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = Ap_Service.GetEntity(id.Value);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            var ApModel = AutoMapperConfig.mapper.Map<Appointment, Appointment_Detail_ViewModel>(appointment);


            Customer C = C_Service.GetEntity(appointment.CustomerId);
            Doctor Dr = Dr_Service.GetEntity(appointment.DoctorId);
            Group Gr = G_Service.GetEntity(appointment.GroupId);
            ApModel.CustomerName = C.Name;
            ApModel.DoctorName = Dr.Name;
            ApModel.GroupName = Gr.GroupName;
          
            ViewBag.CustomerId = new SelectList(C_Service.GetAll(), "CustomerId", "Name", appointment.CustomerId);
            ViewBag.DoctorId = new SelectList(Dr_Service.GetAll(), "DoctorId", "Phone", appointment.DoctorId);
            ViewBag.GroupId = new SelectList(G_Service.GetAll(), "GroupId", "GroupName", appointment.GroupId);
            return View(ApModel);
        }

        // POST: Admin/Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,DoctorId,GroupId,DateOfVisit,NumberOfSessions,IsFristSession,Payment,PaymentNumber")] Appointment_Detail_ViewModel ApModel)
        {
            if (ModelState.IsValid)
            {
                Appointment appointment = AutoMapperConfig.mapper.Map< Appointment_Detail_ViewModel, Appointment>(ApModel);


                Ap_Service.UpdateEntity(appointment);
                Ap_Service.Save(); 
                
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(C_Service.GetAll(), "CustomerId", "Name", ApModel.CustomerId);
            ViewBag.DoctorId = new SelectList(Dr_Service.GetAll(), "DoctorId", "Phone", ApModel.DoctorId);
            ViewBag.GroupId = new SelectList(G_Service.GetAll(), "GroupId", "GroupName", ApModel.GroupId);
            return View(ApModel);
        }

        // GET: Admin/Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = Ap_Service.GetEntity(id.Value);

            if (appointment == null)
            {
                return HttpNotFound();
            }
            var ApModel = AutoMapperConfig.mapper.Map<Appointment, Appointment_Detail_ViewModel>(appointment);

            Customer C = C_Service.GetEntity(appointment.CustomerId);
            Doctor Dr = Dr_Service.GetEntity(appointment.DoctorId);
            Group Gr = G_Service.GetEntity(appointment.GroupId);
            ApModel.CustomerName = C.Name;
            ApModel.DoctorName = Dr.Name;
            ApModel.GroupName = Gr.GroupName;

            return View(ApModel);
        }

        // POST: Admin/Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ap_Service.DeleteEntity(id);
            Ap_Service.Save(); 
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Ap_Service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

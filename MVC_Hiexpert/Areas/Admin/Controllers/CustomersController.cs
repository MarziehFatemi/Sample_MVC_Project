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
using MVC_Hiexpert.Models.ViewModel.Customer_ViewModels;
using Project_Model.Context;
using Project_Model.Model;

namespace MVC_Hiexpert.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        private Hiexpert_Context db = new Hiexpert_Context();


        Customer_Service C_Service;
        public CustomersController()
        {
            C_Service = new Customer_Service(db);

        }
       

        // GET: Admin/Customers
        public ActionResult Index()
        {
            List<Customer> Cs = C_Service.GetAll().ToList();
            List<C_List_ViewModel> Cs_List =
            AutoMapperConfig.mapper.Map<List<Customer>, List<C_List_ViewModel>>(Cs); 
            return View(Cs_List);
        }

        // GET: Admin/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = C_Service.GetEntity(id.Value);

            C_Details_ViewModel C_Detail = AutoMapperConfig.mapper.Map<Customer, C_Details_ViewModel>(customer);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(C_Detail);
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Name,Phone,ImageName,Email,Country")] C_Create_ViewModel New_C)
        {
            if (ModelState.IsValid)
            {
                Customer customer = AutoMapperConfig.mapper.Map< C_Create_ViewModel, Customer>(New_C);

                customer.RegisterDate = DateTime.Now;
                customer.NumberOfTotalSessions = 0;
                customer.TotalPayment = 0;
                customer.Credit = 0;
                
                C_Service.AddEntity(customer);
                C_Service.Save();
                
                return RedirectToAction("Index");
            }

            return View(New_C);
        }

        // GET: Admin/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = C_Service.GetEntity(id.Value);
            C_Edit_ViewModel C_4Edit = AutoMapperConfig.mapper.Map<Customer, C_Edit_ViewModel>(customer);


            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(C_4Edit);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Name,Phone,ImageName,Country,Email")] C_Edit_ViewModel EditedC)
        {
            if (ModelState.IsValid)
            {
                Customer customer = C_Service.GetEntity(EditedC.CustomerId);
                customer.Name = EditedC.Name;
                customer.Email = EditedC.Email;
                customer.Phone = EditedC.Phone;
                customer.Country = EditedC.Country;
                customer.ImageName = EditedC.ImageName;
                C_Service.UpdateEntity(customer);
                C_Service.Save(); 

                return RedirectToAction("Index");
            }
            return View(EditedC);
        }

        // GET: Admin/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = C_Service.GetEntity(id.Value);
            C_Details_ViewModel C_Detail = AutoMapperConfig.mapper.Map<Customer, C_Details_ViewModel>(customer);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(C_Detail);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            C_Service.DeleteEntity(id);
            C_Service.Save(); 
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                C_Service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

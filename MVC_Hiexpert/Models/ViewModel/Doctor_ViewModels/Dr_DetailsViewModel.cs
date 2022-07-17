using Project_Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Hiexpert.Models.ViewModel
{
    public class Dr_DetailsViewModel
    {

        [Display(Name = "کد مشاور")]
        public int DoctorId { get; set; }

        [Display(Name = "موبایل")]
        [MaxLength(30)]
        [Required]
        public string Phone { get; set; }


        [Display(Name = "نام")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }


        [Display(Name = "تاریخ عضویت ")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }

       

        [MaxLength(30)]
        [Display(Name = "شماره کارت")]
        public string CardNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = "شماره شبا")]
        public string AccountNumber { get; set; }

        //[Column(TypeName = "Int")]

        [Display(Name = "فروش کل")]
        public int TotalSale { get; set; }


        //[Column(TypeName = "Int")]
        [Display(Name = "درآمد کل")]
        public int TotalIncome { get; set; }


        //[Column(TypeName = "Int")]
        [Display(Name = "درصد مشاور")]
        public int CommissionPercent { get; set; }



        //[Column(TypeName = "Int")]
        [Display(Name = "مبلغ کل پرداختی به مشاور")]
        public int TotalCheckedOut { get; set; }



        //[Column(TypeName = "Int")]
        [Display(Name = "مانده حساب قابل برداشت")]
        public int Credit { get; set; }


        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }


    }
}
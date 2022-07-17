using Project_Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace MVC_Hiexpert.Models.ViewModel.Appointment_ViewModel
{
    public class Appointment_Detail_ViewModel
     
    {
        [Display (Name ="شماره فاکتور")]
        public int Id { get; set; }

        [Required]
        [Display(Name = " شماره مراجع")]
        public int CustomerId { get; set; }

        [Display(Name = "نام مراجع")]
        public string CustomerName { get; set; }

       


        [Required]
        [Display(Name = "شماره مشاور")]
        public int DoctorId { get; set; }


        [Display(Name = "نام مشاور")]
        public string DoctorName { get; set; }



        [Required]
        [Display(Name = "کد حوزه  مشاوره")]
        public int GroupId { get; set; }


        [Display(Name = "حوزه مشاوره")]
        public string GroupName { get; set; }

        [Required]
        [Display(Name = "تاریخ ویزیت")]
        public DateTime DateOfVisit { get; set; }

        [Required]
        [Display(Name = "تعداد جلسات")]
        public int NumberOfSessions { get; set; }


        //[Column(TypeName = "Int")]
        [Required]
        [Display(Name = "مبلغ پرداختی")]
        public int Payment { get; set; }

        [Required]
        [Display(Name = "شماره رسید پرداخت")]
        public string PaymentNumber { get; set; }

        //[ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        //[ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        public Group Group { get; set; }
    }
}
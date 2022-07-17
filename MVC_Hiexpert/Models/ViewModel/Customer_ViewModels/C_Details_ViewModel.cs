
using Project_Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace MVC_Hiexpert.Models.ViewModel.Customer_ViewModels
{
    public class C_Details_ViewModel
    {

            [Display (Name ="شماره عضویت")]
            public int CustomerId { get; set; }

            [MaxLength(30)]
            [Required]
            [Display(Name = "نام")]
        public string Name { get; set; }

            [MaxLength(30)]
            [Required]

        [Display(Name = "شماره موبایل")]
        public string Phone { get; set; }

            [MaxLength(30)]
        [Display(Name = "کشور")]
        public string Country;

            [MaxLength(30)]
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }

            [MaxLength(30)]

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        // [Column(TypeName = "Int")]

        [Display(Name = "مبلغ کل پرداختی")]
        public int TotalPayment { get; set; }

        [Display(Name = "تعداد کل جلسات ")]
        public int NumberOfTotalSessions { get; set; }

        [Display(Name = "اعتبار")]
        public int Credit { get; set; }

        [Display(Name = "اسامی مشاورین")]
        public IEnumerable<Doctor> Doctors { get; set; }

        [Display(Name = "لیست جلسات")]
        public IEnumerable<Appointment> Appointments { get; set; }

        [Display(Name = "حوزه های مشاوره")]
        public IEnumerable<Group> Groups { get; set; }
        }
    
}
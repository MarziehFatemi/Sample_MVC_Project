using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Hiexpert.Models.ViewModel
{
    public class Dr_Edit_ViewModel
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



        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }



        [MaxLength(30)]
        [Display(Name = "شماره کارت")]
        public string CardNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = "شماره شبا")]
        public string AccountNumber { get; set; }

        
        [Display(Name = "درصد مشاور")]
        public int CommissionPercent { get; set; }




    }
}
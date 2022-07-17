using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Hiexpert.Models.ViewModel
{
    public class Dr_abs_ViewModel
    {
        //DatabaseGenerated  DatabaseGeneration.None
        [Display(Name="کد مشاور")]
        public int DoctorId { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "موبایل")]
        public string Phone { get; set; }


        [MaxLength(30)]
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }

        

        [MaxLength(30)]
        [Display(Name = "شماره کارت")]
        public string CardNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = "شماره حساب")]
        public string AccountNumber { get; set; }


        [Display(Name = "درصد مشاور")]
        public int CommissionPercent { get; set; }

        [Display(Name = "اعتبار")]
        public int Credit { get; set; }




    }
}
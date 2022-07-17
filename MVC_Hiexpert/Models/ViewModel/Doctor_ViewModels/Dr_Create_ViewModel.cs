using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Hiexpert.Models.ViewModel
{
    public class Dr_Create_ViewModel
    {

        [MaxLength(30)]
        [Required]
        [Display(Name = "موبایل")]
        public string Phone { get; set; }


       

        [MaxLength(30)]
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "رمز")]
        public string Password { get; set; }




        [MaxLength(30)]
        [Display(Name = "شماره کارت")]
        public string CardNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = "شماره حساب")]
        public string AccountNumber { get; set; }


  
    }
}
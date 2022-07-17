using Project_Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace MVC_Hiexpert.Models.ViewModel.Customer_ViewModels
{
    public class C_Edit_ViewModel
    {

        [Display(Name = "شماره عضویت")]
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

       
        [MaxLength(30)]

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        
    }

}

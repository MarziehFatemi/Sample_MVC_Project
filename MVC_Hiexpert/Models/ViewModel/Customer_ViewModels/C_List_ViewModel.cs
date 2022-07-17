
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace MVC_Hiexpert.Models.ViewModel.Customer_ViewModels
{
    public class C_List_ViewModel
    {
        [Display (Name="شماره")]
        public int CustomerId { get; set; }

        [MaxLength(30)]
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }



        [MaxLength(30)]
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "شماره موبایل")]
        public string Phone { get; set; }

        [Display(Name = "کشور")]
        [MaxLength(30)]
        public string Country;

        
    }
}
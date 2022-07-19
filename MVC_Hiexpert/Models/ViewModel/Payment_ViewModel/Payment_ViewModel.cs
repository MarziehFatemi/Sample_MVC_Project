
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace MVC_Hiexpert.Models.ViewModel.Payment_ViewModel
{
    public class Payment_ViewModel
    {
        [Display(Name ="شماره پرداخت")]
        public int PaymentId { get; set; }

        [Required]
        [Display(Name = "شماره مشاور")]
        public int DoctorId { get; set; }

        [Display(Name = "نام مشاور")]
        public string DoctorName { get; set; }

        [Required]
        [Display(Name = "مبلغ پرداخت شده")]
        public int PayedMoney { get; set; }

        [Required]
        [Display(Name = "زمان پرداخت")]
        public DateTime PayedTime { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "شماره رسید پرداخت")]
        public string PaymentNumber { get; set; }

    }
}
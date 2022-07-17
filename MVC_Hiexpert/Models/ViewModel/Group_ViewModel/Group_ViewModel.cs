
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace MVC_Hiexpert.Models.ViewModel.Group_ViewModel
{
    public class Group_ViewModel
    {
        public int GroupId { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name ="حوزه مشاوره")]
        public string GroupName { get; set; }
    }
}
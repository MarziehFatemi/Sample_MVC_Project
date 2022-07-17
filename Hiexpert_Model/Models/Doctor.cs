using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiexpert_Model.Models
{
    
        [Table("T_Doctors")]
        public class Doctor : BaseEntity
        {
            [Key]
            public int DoctorId { get; set; }


        

            [MaxLength(30)]
            [Required]
            public string Phone { get; set; }


            [MaxLength(30)]
            [Required]
            public string Name { get; set; }


           public string ImageName { get; set; }

          public DateTime RegisterDate { get; set; }

            public bool IsActive { get; set; }

            [MaxLength(30)]
            [Required]
            public string Password { get; set; }


            [MaxLength(30)]
            public string CardNumber { get; set; }

            [MaxLength(30)]
            public string AccountNumber { get; set; }

            //[Column(TypeName = "Int")]
            public int TotalSale { get; set; }


            //[Column(TypeName = "Int")]
            public int TotalIncome { get; set; }


            //[Column(TypeName = "Int")]
            public int CommissionPercent { get; set; }



            //[Column(TypeName = "Int")]
            public int TotalCheckedOut { get; set; }



            //[Column(TypeName = "Int")]
            public int Credit { get; set; }


            public IEnumerable<Customer> Customers { get; set; }
            public IEnumerable<Appointment> Appointments { get; set; }

            public IEnumerable<Payment> CheckOuts { get; set; }

            public IEnumerable<Group> FieldGroups { get; set; }



    }
   
}

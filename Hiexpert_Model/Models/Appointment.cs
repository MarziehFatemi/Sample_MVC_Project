using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiexpert_Model.Models
{
    [Table("T_Appointments")]
    public class Appointment : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }


        [Required]
        public int DoctorId { get; set; }


        [Required]
        public int GroupId { get; set; }

        [Required]
        public DateTime DateOfVisit { get; set; }

        [Required]
        public int NumberOfSessions { get; set; }

        [Required]
        public bool IsFristSession { get; set; }

        //[Column(TypeName = "Int")]
        [Required]
        public int Payment { get; set; }

        [Required]
        public string PaymentNumber { get; set; }

        //[ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        //[ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        public Group Group { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiexpert_Model.Models
{
    [Table("T_Customers")]
    public class Customer : BaseEntity
    {
        [Key]
        public int CustomerId { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(30)]
        public string Country;

        [MaxLength(30)]
        public string ImageName { get; set; }
        public DateTime RegisterDate { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        // [Column(TypeName = "Int")]
        public int TotalPayment { get; set; }


        public int NumberOfTotalSessions { get; set; }
        public int Credit { get; set; }

        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}

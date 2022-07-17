using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model.Model
{
    [Table("T_Payment")]
    public class Payment : BaseEntity
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PayedMoney { get; set; }

        [Required]
        public DateTime PayedTime { get; set; }

        [MaxLength(30)]
        [Required]
        public string PaymentNumber { get; set; }
        //[MaxLength(30)]
        ////public string CardofPayed { get; set; }
        ////[MaxLength(30)]
        ////public string AccountOfPayed { get; set; }

        public Doctor Doctor { get; set; }
    }
}

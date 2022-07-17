using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiexpert_Model.Models
{
    [Table("T_Payment")]
    public class Payment : BaseEntity
    {
        [Key]
        public int PaymentId; 


        public int DoctorId;
        
        public int PayedMoney;

        public DateTime PayedTime;

        [MaxLength(30)]
        public string PaymentNumber;
        [MaxLength(30)]
        public string CardofPayed;
        [MaxLength(30)]
        public string AccountOfPayed;

        public Doctor Doctor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiexpert_Model.Models
{
    [Table("T_Group")]
    public class Group : BaseEntity
    {
        [Key]
        public int GroupId ;

        [MaxLength(30)]
        public string  GroupName; 
    }
}

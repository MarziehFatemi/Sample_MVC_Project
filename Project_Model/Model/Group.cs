using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model.Model
{
    [Table("T_Group")]
    public class Group : BaseEntity
    {
        [Key]
        public int GroupId { get; set; }

        [MaxLength(30)]
        [Required]
        public string GroupName { get; set; }
    }
}

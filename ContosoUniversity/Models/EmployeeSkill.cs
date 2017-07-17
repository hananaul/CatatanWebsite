using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class EmployeeSkill
    {
        [Key]
        [Display(Name = "ID EmployeeSkill")]
        public int IDSkill { get; set; }


        [Display(Name = "ID Employee")]
        public int ID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Skill")]
        public string Skill { get; set; }

        [Required]
        [Display(Name = "Level")]
        public int Level { get; set; }
    }
}
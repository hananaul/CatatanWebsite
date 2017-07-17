using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeeSkills = new List<EmployeeSkill>();
        }

        [Key]
        [Display(Name = "ID Employee")]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string NameLast { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime?  DateOfBirth { get; set; }

        [StringLength(50)]
        [Display(Name = "Place Birth")]
        public string PlaceOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(12, ErrorMessage = "Phone Number cannot be longer than 12 characters.")]
        [Display(Name = "Phone Number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Address")]
        public string Addresss { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "PostalCode")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Married Status")]
        public string MarriedStatus { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime?  HireDatee { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + NameLast;
            }
        }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}

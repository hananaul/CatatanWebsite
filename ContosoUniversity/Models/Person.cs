using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public abstract class Person
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [StringLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(12, ErrorMessage = "Phone Number cannot be longer than 12 characters.")]
        [Display(Name = "Phone")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }



        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class EmployeeDto
    {
        public string firstname { get; set; }
        public String namelast { get; set; }
        public DateTime? dateofbirth { get; set; }
        public string placeofbirth { get; set; }
        public string gender { get; set; }
        public string phonenumber { get; set; }
        public string address { get; set; }
        public string postalcode { get; set; }
        public string marriedstatus { get; set; }
        public DateTime? hiredate { get; set; }
        public IEnumerable<SkillsEmployeeDto> Skills { get; set; }
    }
}
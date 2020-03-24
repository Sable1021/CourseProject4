using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject4.Models
{
    public class Diagnosis
    {
        public int DiagnosisID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        
    }
}

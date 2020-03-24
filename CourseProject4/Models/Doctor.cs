using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject4.Models
{
    public class Doctor
    {

        public int DoctorID { get; set; }
        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public int Room { get; set; }

        public int Age { get; set; }

        public string PatientName { get; set; }

        public int PatientAge { get; set; }

        public string Insurance { get; set; }

        public DateTime AdmitDate { get; set; }

        public DateTime DischargeDate { get; set; }

        public string Diagnosis { get; set; }
    }
}

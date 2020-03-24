using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject4.Models
{
    public class Patient
    {

        public int PatientID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public string Insurance { get; set; }

        public int DoctorID { get; set; }
        public string Doctor { get; set; }

        public int AdmitDateID { get; set; }
        public DateTime AdmitDate { get; set; }
        public int DischargeDateID { get; set; }
        public DateTime DischargeDate { get; set; }
        public int DiagnosisID { get; set; }
        public string Diagnosis { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicantPortal.Models.StudentDTO
{
    public class StudentSteps
    {
        public StudentStep1 studentStep1 { get; set; }
        public StudentStep2 studentStep2 { get; set; }
        public StudentStep3 studentStep3 { get; set; }
    }
}
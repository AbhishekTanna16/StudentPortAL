using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicantPortal.Models.StudentDTO
{
    public class StudentStep3
    {
        [Required(ErrorMessage = "Please Select District")]
        public int step3DistrictId { get; set; }
        [Required(ErrorMessage = "Please Select College")]
        public int step3CollegeId { get; set; }
        [Required(ErrorMessage = "Please Select Stream")]
        public int StreamId { get; set; }
        public IEnumerable<ADistrictMaster> step3Districts { get; set; }
        public IEnumerable<ACollegeMaster> step3Colleges { get; set; }
        public IEnumerable<AStreamMaster> step3Streams { get; set; }


    }
    public class AStreamMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static ApplicantPortal.Models.Helper;

namespace ApplicantPortal.Models.StudentDTO
{
    public class StudentStep1
    {
        [Required(ErrorMessage = "Please choose Examination Board")]
        public int BoardId { get; set; }

        [Required(ErrorMessage ="Please choose Pass Out Year")]
        public int PassingYearId { get; set; }

        [Required(ErrorMessage = "Please choose ExamType")]
        public string ExamType { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public string BOD { get; set; }
        [Required(ErrorMessage ="Please Enter Roll Code")]
        public string RollCode { get; set; }
        [Required(ErrorMessage = "Please Enter Roll Number")]
        public string RollNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Applicant Name")]
        public string ApplicantName { get; set; }
        [Required(ErrorMessage = "Please Enter Father's Name")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Please Enter Mother's Name")]
        public string MotherName { get; set; }

        public string S10MaxiMarks { get; set; }
        public string S10TotalMarks { get; set; }
        public bool? Is10Compartmentally { get; set; }

        [Required(ErrorMessage = "Please Enter School Name")]
        public string SchoolName { get; set; }
        [Required(ErrorMessage = "Please Enter School Address")]
        public string SchoolAddress { get; set; }
        [Required(ErrorMessage = "Please Select District")]
        public int DistrictId { get; set; }
        [Required(ErrorMessage = "Please Select Year of Joining")]
        public int YearOfJoin { get; set; }
        [Required(ErrorMessage = "Please Select Year of Leaving")]
        public int YearOfLeaving { get; set; }

        public string Photo { get; set; }
        public string Signature { get; set; }

        [Required(ErrorMessage = "Please Upload Your Photo.")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        [AllowExtensions(Extensions = "png,jpg,jpeg", ErrorMessage = "Please select only Supported Files .png | .jpg")]
        public HttpPostedFileBase PostedPhoto { get; set; }

        [Required(ErrorMessage = "Please Upload Your Signature.")]
        [AllowExtensions(Extensions = "png,jpg,jpeg", ErrorMessage = "Please select only Supported Files .png | .jpg")]
        public HttpPostedFileBase PostedSignature { get; set; }


        public IEnumerable<ABoardMastrer> Boards { get; set; }

        public IEnumerable<ADistrictMaster> Districts { get; set; }

        public IEnumerable<AYearMaster> Years { get; set; }

        public IEnumerable<ACollegeMaster> Colleges { get; set; }
    }
    public class ABoardMastrer
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class ADistrictMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class AYearMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class ACollegeMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
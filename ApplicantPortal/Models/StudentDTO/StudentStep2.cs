using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicantPortal.Models.StudentDTO
{
    public class StudentStep2
    {
        [Required(ErrorMessage = "Please Select Gender")]
        public int GenderId { get; set; }
        [Required(ErrorMessage = "Please Select Mother Toungue")]
        public int MotherToungueId { get; set; }
        [Required(ErrorMessage = "Please Select Nationality")]
        public int Nationalityid { get; set; }
        public int ReligionId { get; set; }
        public int BloodGroupId { get; set; }
        [Required(ErrorMessage = "Please Select State")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please Select District")]
        public int AddressDistrictId { get; set; }
        [Required(ErrorMessage = "Please Select Block")]
        public int BlockId { get; set; }

        [Required(ErrorMessage ="Please Enter (House No / Street/Village/ Post Office/ Police Station Name ")]
        public string HouseNo { get; set; }

        [Required(ErrorMessage = "Please Enter PinCode")]
        [RegularExpression(@"^\d{6,}$", ErrorMessage = "Pin Code is must be properly formatted(for ex. 310005.")]
        public string PinCode { get; set; }
        [Required(ErrorMessage ="Mobile no. is Required")]
        [RegularExpression(@"^\d{10,}$", ErrorMessage = "Mobile Number is must be properly formatted(for ex. 9999999999.")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]

        public string Email { get; set; }
        public string STD { get; set; }
        public string PhoneNo { get; set; }
       
        public string Cast { get; set; }
        public string IsSpeciallyAbled { get; set; }
        public string EWS { get; set; }

        public IEnumerable<AGenderMaster> Genders { get; set; }

        public IEnumerable<AStateMaster> States { get; set; }

        public IEnumerable<AMotherToungeMaster> MotherTounges { get; set; }

        public IEnumerable<ANationalityMaster> Nationalities { get; set; }

        public IEnumerable<AReligionMaster> Religions { get; set; }

        public IEnumerable<ABloodGroupMaster> BloodGroups { get; set; }

        public IEnumerable<ABlockMaster> Blocks { get; set; }

        public IEnumerable<ADistrictMaster> step2Districts { get; set; }
    }
    public class AGenderMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AMotherToungeMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ANationalityMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AReligionMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ABloodGroupMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ABlockMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AStateMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
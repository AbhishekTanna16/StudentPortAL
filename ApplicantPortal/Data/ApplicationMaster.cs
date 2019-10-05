//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicantPortal.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApplicationMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApplicationMaster()
        {
            this.ApplicantSubjects = new HashSet<ApplicantSubject>();
        }
    
        public int ApplicationId { get; set; }
        public string ApplicationNumber { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public int BoardId { get; set; }
        public int PassingYearId { get; set; }
        public int ExamType { get; set; }
        public System.DateTime BOD { get; set; }
        public string RollCode { get; set; }
        public string RollNumber { get; set; }
        public string ApplicantName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int S10MaxiMarks { get; set; }
        public int S10TotalMarks { get; set; }
        public bool Is10Compartmentally { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> YearOfJoin { get; set; }
        public Nullable<int> YearOfLeaving { get; set; }
        public string Gender { get; set; }
        public string MotherTongue { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string BloodGroup { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string HouseAddress { get; set; }
        public string PinCode { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string TelephoneNo { get; set; }
        public Nullable<int> ReservationId { get; set; }
        public Nullable<int> EWS { get; set; }
        public Nullable<int> SpecialAbied { get; set; }
        public Nullable<bool> IsCondition1 { get; set; }
        public Nullable<bool> IsCondition2 { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }
        public string StudentSubjects { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicantSubject> ApplicantSubjects { get; set; }
    }
}

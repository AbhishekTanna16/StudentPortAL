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
    
    public partial class ApplicantSubject
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public Nullable<int> SectionId { get; set; }
        public Nullable<int> ApplicationId { get; set; }
    
        public virtual ApplicationMaster ApplicationMaster { get; set; }
        public virtual SectionMaster SectionMaster { get; set; }
    }
}
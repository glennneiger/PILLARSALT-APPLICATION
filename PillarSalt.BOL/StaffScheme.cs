//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PillarSalt.BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class StaffScheme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffScheme()
        {
            this.Loans = new HashSet<Loan>();
        }
    
        public int Id { get; set; }
        public string SchemeName { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Interest { get; set; }
        public Nullable<decimal> MaxAmount { get; set; }
        public Nullable<int> PayBackMonths { get; set; }
        public Nullable<int> Moratorium { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
        public string UserId { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> BranchID { get; set; }
        public Nullable<int> MinimumGrade { get; set; }
        public Nullable<int> MinimumExperience { get; set; }
        public Nullable<int> MaxConcurrence { get; set; }
        public Nullable<int> GLBatchNo { get; set; }
        public string ReviewerId { get; set; }
        public string OverrideId { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public string AuthoriseId { get; set; }
        public string RelatorKey { get; set; }
        public Nullable<System.DateTime> ApprovalEntry { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public Nullable<int> StartModuleID { get; set; }
        public string CurrentStage { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string Notes { get; set; }
        public Nullable<int> Revision { get; set; }
        public string Token { get; set; }
        public string EditReason { get; set; }
        public string TokenOwner { get; set; }
        public string TokenManifestId { get; set; }
        public string DeclineId { get; set; }
        public Nullable<decimal> MinAppraisal { get; set; }
        public Nullable<decimal> MaxOfGross { get; set; }
        public Nullable<int> RateId { get; set; }
        public Nullable<System.DateTime> ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string UpdateLocker { get; set; }
        public string TMSResponse { get; set; }
    
        public virtual HR_Loan_RateType HR_Loan_RateType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}

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
    
    public partial class CRM_Partners
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRM_Partners()
        {
            this.Real_Estate = new HashSet<Real_Estate>();
            this.Real_Property = new HashSet<Real_Property>();
            this.Real_PropertyAnalysis = new HashSet<Real_PropertyAnalysis>();
            this.Real_UBAProperties = new HashSet<Real_UBAProperties>();
        }
    
        public int id { get; set; }
        public string Description { get; set; }
        public string PartnerCode { get; set; }
        public Nullable<int> ContactId { get; set; }
        public Nullable<bool> IsCompany { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<int> Bank { get; set; }
        public string BankAcc { get; set; }
        public string OldPartnerNo { get; set; }
        public string RegistrationNo { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> IsForeign { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string TaxAccount { get; set; }
        public string PayAccount { get; set; }
        public string DiscountAcct { get; set; }
        public Nullable<int> SerialAcc { get; set; }
        public string TIN { get; set; }
        public Nullable<System.DateTime> SignOnDate { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public string CurrentStage { get; set; }
        public string UserId { get; set; }
        public string ReviewerId { get; set; }
        public string OverrideId { get; set; }
        public string AuthoriseId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string RelatorKey { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
        public Nullable<System.DateTime> ApprovalEntry { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> StartModuleID { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> Revision { get; set; }
        public string Token { get; set; }
        public string EditReason { get; set; }
        public string TokenOwner { get; set; }
        public string TokenManifestId { get; set; }
        public string DeclineId { get; set; }
        public Nullable<System.DateTime> ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string UpdateLocker { get; set; }
        public string TMSResponse { get; set; }
    
        public virtual CRMContact CRMContact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Real_Estate> Real_Estate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Real_Property> Real_Property { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Real_PropertyAnalysis> Real_PropertyAnalysis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Real_UBAProperties> Real_UBAProperties { get; set; }
    }
}
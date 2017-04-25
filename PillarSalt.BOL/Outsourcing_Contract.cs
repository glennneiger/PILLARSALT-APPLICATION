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
    
    public partial class Outsourcing_Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Outsourcing_Contract()
        {
            this.Outsourcing_Contract_Document = new HashSet<Outsourcing_Contract_Document>();
            this.Outsourcing_ContractCompletion = new HashSet<Outsourcing_ContractCompletion>();
        }
    
        public int Id { get; set; }
        public string ContractNo { get; set; }
        public string Description { get; set; }
        public Nullable<int> TenderId { get; set; }
        public Nullable<int> Awardee { get; set; }
        public Nullable<int> ReservedBidder { get; set; }
        public Nullable<int> SelectedBid { get; set; }
        public Nullable<decimal> AwardedSum { get; set; }
        public Nullable<System.DateTime> CommencementDate { get; set; }
        public Nullable<int> Duration { get; set; }
        public string ContractTerm { get; set; }
        public string AwardMethod { get; set; }
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
        public string Notes { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outsourcing_Contract_Document> Outsourcing_Contract_Document { get; set; }
        public virtual Outsourcing_Tender Outsourcing_Tender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outsourcing_ContractCompletion> Outsourcing_ContractCompletion { get; set; }
    }
}

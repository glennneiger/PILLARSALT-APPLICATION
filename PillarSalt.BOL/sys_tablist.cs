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
    
    public partial class sys_tablist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_tablist()
        {
            this.Sys_Event_Subscription = new HashSet<Sys_Event_Subscription>();
            this.sys_ModuleTable = new HashSet<sys_ModuleTable>();
            this.sys_ShortCut = new HashSet<sys_ShortCut>();
        }
    
        public short TabId { get; set; }
        public string Tabs { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
        public string Permission { get; set; }
        public string Sidehelp { get; set; }
        public int SerialNo { get; set; }
        public string LargeIcon { get; set; }
        public string SmallIcon { get; set; }
        public Nullable<int> GLBatchNo { get; set; }
        public string ReviewerId { get; set; }
        public string OverrideId { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> HasFinancial { get; set; }
        public Nullable<bool> ReqApproval { get; set; }
        public Nullable<bool> ReqAudit { get; set; }
        public Nullable<bool> ReqEditReason { get; set; }
        public Nullable<bool> ReqOverride { get; set; }
        public Nullable<bool> ReqReview { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public string userid { get; set; }
        public string AuthoriseId { get; set; }
        public string RelatorKey { get; set; }
        public Nullable<System.DateTime> ApprovalEntry { get; set; }
        public Nullable<bool> UserReview { get; set; }
        public Nullable<bool> OtherDisapprove { get; set; }
        public Nullable<bool> ReviewerApprove { get; set; }
        public Nullable<bool> UserApprove { get; set; }
        public Nullable<bool> IsReport { get; set; }
        public Nullable<bool> UseInheritance { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public Nullable<int> StartModuleID { get; set; }
        public string CurrentStage { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string Notes { get; set; }
        public Nullable<int> Revision { get; set; }
        public string Token { get; set; }
        public string EditReason { get; set; }
        public string TokenOwner { get; set; }
        public string TokenManifestId { get; set; }
        public string Description { get; set; }
        public string DeclineId { get; set; }
        public string IconCss { get; set; }
        public Nullable<System.DateTime> ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string UpdateLocker { get; set; }
        public string TMSResponse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sys_Event_Subscription> Sys_Event_Subscription { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_ModuleTable> sys_ModuleTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_ShortCut> sys_ShortCut { get; set; }
    }
}

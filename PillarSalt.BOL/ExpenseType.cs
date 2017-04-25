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
    
    public partial class ExpenseType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpenseType()
        {
            this.Admin_WorkOrder = new HashSet<Admin_WorkOrder>();
            this.Acc_Budget_Breakdown = new HashSet<Acc_Budget_Breakdown>();
            this.Acc_Retirements = new HashSet<Acc_Retirements>();
        }
    
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Nullable<bool> RequireApproval { get; set; }
        public Nullable<int> CentreId { get; set; }
        public string ExpenseAccount { get; set; }
        public Nullable<decimal> MaxAmount { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
        public Nullable<int> GLBatchNo { get; set; }
        public string ReviewerId { get; set; }
        public string OverrideId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public string userid { get; set; }
        public Nullable<int> BranchID { get; set; }
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
        public Nullable<System.DateTime> ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string controlAccount { get; set; }
        public string UpdateLocker { get; set; }
        public string TMSResponse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_WorkOrder> Admin_WorkOrder { get; set; }
        public virtual ProfitCentre ProfitCentre { get; set; }
        public virtual SchoolBranch SchoolBranch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acc_Budget_Breakdown> Acc_Budget_Breakdown { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acc_Retirements> Acc_Retirements { get; set; }
    }
}
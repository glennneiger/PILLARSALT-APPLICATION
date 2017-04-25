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
    
    public partial class Expens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expens()
        {
            this.Admin_Requisition_Documents = new HashSet<Admin_Requisition_Documents>();
            this.Admin_Requisition_Enquiries = new HashSet<Admin_Requisition_Enquiries>();
            this.Admin_WorkOrder = new HashSet<Admin_WorkOrder>();
            this.InventoryPurchaseOrders = new HashSet<InventoryPurchaseOrder>();
        }
    
        public int ExpensesID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string ModeOfPayment { get; set; }
        public Nullable<decimal> AmountRequested { get; set; }
        public string Purpose { get; set; }
        public string UserID { get; set; }
        public Nullable<decimal> ReleasedAmount { get; set; }
        public Nullable<System.DateTime> DateRequsted { get; set; }
        public Nullable<System.DateTime> DateGiven { get; set; }
        public Nullable<System.DateTime> DateNeeded { get; set; }
        public Nullable<bool> Collected { get; set; }
        public Nullable<int> DeptID { get; set; }
        public Nullable<bool> HODApproval { get; set; }
        public Nullable<bool> SecondApproval { get; set; }
        public Nullable<bool> MainApproval { get; set; }
        public Nullable<bool> FinalApproval { get; set; }
        public string DirectorRemarks { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
        public Nullable<int> SerialAcc { get; set; }
        public Nullable<bool> Active { get; set; }
        public string HODId { get; set; }
        public string SecondId { get; set; }
        public string MainId { get; set; }
        public string FinalId { get; set; }
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
        public Nullable<int> BranchId { get; set; }
        public string Notes { get; set; }
        public Nullable<int> Revision { get; set; }
        public string Token { get; set; }
        public string EditReason { get; set; }
        public string TokenOwner { get; set; }
        public string TokenManifestId { get; set; }
        public string DeclineId { get; set; }
        public Nullable<int> vendorAcc { get; set; }
        public Nullable<System.DateTime> ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public Nullable<int> currencyId { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string UpdateLocker { get; set; }
        public string TMSResponse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_Requisition_Documents> Admin_Requisition_Documents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_Requisition_Enquiries> Admin_Requisition_Enquiries { get; set; }
        public virtual Admin_RequisitionType Admin_RequisitionType { get; set; }
        public virtual Admin_RequisitionType Admin_RequisitionType1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_WorkOrder> Admin_WorkOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryPurchaseOrder> InventoryPurchaseOrders { get; set; }
        public virtual Acc_CurrencyCode Acc_CurrencyCode { get; set; }
        public virtual Account Account { get; set; }
    }
}

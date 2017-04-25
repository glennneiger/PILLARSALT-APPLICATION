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
    
    public partial class InventoryPurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryPurchaseOrder()
        {
            this.InventoryOrderDetails = new HashSet<InventoryOrderDetail>();
            this.InventoryVouchers = new HashSet<InventoryVoucher>();
        }
    
        public int PurchaseOrderID { get; set; }
        public Nullable<byte> RevisionNumber { get; set; }
        public string Status { get; set; }
        public Nullable<int> SerialAcc { get; set; }
        public Nullable<int> ShipMethodID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> TaxAmt { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Notes { get; set; }
        public string UserId { get; set; }
        public string Authorisation { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
        public Nullable<System.DateTime> SupplyDate { get; set; }
        public Nullable<int> ExpensesID { get; set; }
        public Nullable<bool> Active { get; set; }
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
        public decimal TotalDue { get; set; }
        public string TMSResponse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryOrderDetail> InventoryOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryVoucher> InventoryVouchers { get; set; }
        public virtual Expens Expens { get; set; }
        public virtual Account Account { get; set; }
    }
}
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
    
    public partial class InventoryOrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryOrderDetail()
        {
            this.InventoryBatchings = new HashSet<InventoryBatching>();
        }
    
        public int OrderDetailID { get; set; }
        public Nullable<int> PurchaseOrderID { get; set; }
        public Nullable<int> OrderQty { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> ReceivedQty { get; set; }
        public Nullable<int> RejectedQty { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string UserId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<decimal> LPOWAC { get; set; }
        public Nullable<int> LPOQuantity { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<bool> VatInclusive { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> GLBatchNo { get; set; }
        public string ReviewerId { get; set; }
        public string OverrideId { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public Nullable<System.DateTime> entry { get; set; }
        public string AuthoriseId { get; set; }
        public string RelatorKey { get; set; }
        public Nullable<System.DateTime> ApprovalEntry { get; set; }
        public Nullable<int> Destination { get; set; }
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
        public string UpdateLocker { get; set; }
        public decimal LineTotal { get; set; }
        public int StockedQty { get; set; }
        public string TMSResponse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryBatching> InventoryBatchings { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public virtual InventoryPurchaseOrder InventoryPurchaseOrder { get; set; }
        public virtual Department Department { get; set; }
        public virtual Acc_CurrencyCode Acc_CurrencyCode { get; set; }
    }
}
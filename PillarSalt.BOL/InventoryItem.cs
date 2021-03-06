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
    
    public partial class InventoryItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryItem()
        {
            this.Asset_Disposal = new HashSet<Asset_Disposal>();
            this.Asset_FixedAssets = new HashSet<Asset_FixedAssets>();
            this.Asset_Maintenance_Request = new HashSet<Asset_Maintenance_Request>();
            this.CustomerItineraries = new HashSet<CustomerItinerary>();
            this.InventoryBatchings = new HashSet<InventoryBatching>();
            this.InventoryMovements = new HashSet<InventoryMovement>();
            this.InventoryOrderDetails = new HashSet<InventoryOrderDetail>();
            this.InventoryPriceHistories = new HashSet<InventoryPriceHistory>();
            this.InventoryPricings = new HashSet<InventoryPricing>();
            this.InventoryReqDetails = new HashSet<InventoryReqDetail>();
            this.InventorySales = new HashSet<InventorySale>();
            this.InventoryStockings = new HashSet<InventoryStocking>();
            this.MANUBoms = new HashSet<MANUBom>();
            this.MANUBoms1 = new HashSet<MANUBom>();
            this.ServiceAssemblies = new HashSet<ServiceAssembly>();
            this.AccProformaDetails = new HashSet<AccProformaDetail>();
        }
    
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemNumber { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<bool> FinishedGoodsFlag { get; set; }
        public Nullable<short> SafetyStockLevel { get; set; }
        public Nullable<short> ReorderPoint { get; set; }
        public Nullable<decimal> CurrentCost { get; set; }
        public Nullable<decimal> ListPrice { get; set; }
        public string UnitMeasureCode { get; set; }
        public Nullable<int> DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public Nullable<System.DateTime> SellStartDate { get; set; }
        public Nullable<System.DateTime> SellEndDate { get; set; }
        public Nullable<System.DateTime> DiscontinuedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string UserId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<System.DateTime> entry { get; set; }
        public Nullable<decimal> DiscountRate { get; set; }
        public Nullable<decimal> VATRate { get; set; }
        public string ExpenseAccount { get; set; }
        public string IncomeAccount { get; set; }
        public string VATAccount { get; set; }
        public string ExpiredItemAccount { get; set; }
        public string DisposalAccount { get; set; }
        public Nullable<bool> UnderCapitation { get; set; }
        public Nullable<bool> Sellable { get; set; }
        public Nullable<bool> Stickable { get; set; }
        public Nullable<bool> Manufactured { get; set; }
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
        public virtual ICollection<Asset_Disposal> Asset_Disposal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_FixedAssets> Asset_FixedAssets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_Maintenance_Request> Asset_Maintenance_Request { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerItinerary> CustomerItineraries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryBatching> InventoryBatchings { get; set; }
        public virtual InventoryStockType InventoryStockType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryMovement> InventoryMovements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryOrderDetail> InventoryOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryPriceHistory> InventoryPriceHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryPricing> InventoryPricings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryReqDetail> InventoryReqDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventorySale> InventorySales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryStocking> InventoryStockings { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; }
        public virtual UnitMeasure UnitMeasure1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MANUBom> MANUBoms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MANUBom> MANUBoms1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceAssembly> ServiceAssemblies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccProformaDetail> AccProformaDetails { get; set; }
    }
}

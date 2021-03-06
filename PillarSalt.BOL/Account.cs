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
    
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.Acc_Accounts_BankDetails = new HashSet<Acc_Accounts_BankDetails>();
            this.ACCProformas = new HashSet<ACCProforma>();
            this.Admin_WorkOrder = new HashSet<Admin_WorkOrder>();
            this.Asset_Maintenance_Request = new HashSet<Asset_Maintenance_Request>();
            this.CRMLeads = new HashSet<CRMLead>();
            this.CustomerItineraries = new HashSet<CustomerItinerary>();
            this.CustomerPayments = new HashSet<CustomerPayment>();
            this.CustomerVisits = new HashSet<CustomerVisit>();
            this.Expenses = new HashSet<Expens>();
            this.HR_Staff_Wage = new HashSet<HR_Staff_Wage>();
            this.InventoryPurchaseOrders = new HashSet<InventoryPurchaseOrder>();
            this.InventoryVendors = new HashSet<InventoryVendor>();
            this.InventoryVouchers = new HashSet<InventoryVoucher>();
            this.Loans = new HashSet<Loan>();
            this.Real_RentalLog = new HashSet<Real_RentalLog>();
            this.StaffPayRolls = new HashSet<StaffPayRoll>();
        }
    
        public int SerialAcc { get; set; }
        public string AccountNo { get; set; }
        public Nullable<short> AccountEntityId { get; set; }
        public string Notes { get; set; }
        public string AccountName { get; set; }
        public Nullable<decimal> bkbalance { get; set; }
        public Nullable<int> Branch { get; set; }
        public string CardNo { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string RegistrationName { get; set; }
        public Nullable<System.DateTime> Expires { get; set; }
        public Nullable<bool> Active { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
        public Nullable<int> ParentAcc { get; set; }
        public Nullable<int> ContactID { get; set; }
        public string CardNo2 { get; set; }
        public Nullable<decimal> DrLimit { get; set; }
        public Nullable<decimal> CrLimit { get; set; }
        public Nullable<int> GLBatchNo { get; set; }
        public string ReviewerId { get; set; }
        public string OverrideId { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public string AuthoriseId { get; set; }
        public string RelatorKey { get; set; }
        public Nullable<System.DateTime> ApprovalEntry { get; set; }
        public Nullable<System.DateTime> LastOdDate { get; set; }
        public Nullable<bool> MainAccount { get; set; }
        public Nullable<bool> PrivateAcc { get; set; }
        public Nullable<bool> CanBuy { get; set; }
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
        public Nullable<decimal> pendingBalance { get; set; }
        public Nullable<System.DateTime> ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string UpdateLocker { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string BVN { get; set; }
        public string TMSResponse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acc_Accounts_BankDetails> Acc_Accounts_BankDetails { get; set; }
        public virtual AccountEntity AccountEntity { get; set; }
        public virtual CRMContact CRMContact { get; set; }
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCProforma> ACCProformas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_WorkOrder> Admin_WorkOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_Maintenance_Request> Asset_Maintenance_Request { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRMLead> CRMLeads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerItinerary> CustomerItineraries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPayment> CustomerPayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerVisit> CustomerVisits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expens> Expenses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HR_Staff_Wage> HR_Staff_Wage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryPurchaseOrder> InventoryPurchaseOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryVendor> InventoryVendors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryVoucher> InventoryVouchers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Real_RentalLog> Real_RentalLog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffPayRoll> StaffPayRolls { get; set; }
    }
}

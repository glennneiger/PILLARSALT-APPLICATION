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
    
    public partial class Real_RentalLog
    {
        public int Id { get; set; }
        public Nullable<int> RentalUnitId { get; set; }
        public Nullable<int> NoRentedOut { get; set; }
        public Nullable<System.DateTime> MoveIn { get; set; }
        public Nullable<System.DateTime> MoveOut { get; set; }
        public Nullable<System.DateTime> LeaseStart { get; set; }
        public Nullable<System.DateTime> LeaseEnd { get; set; }
        public Nullable<decimal> CautionFees { get; set; }
        public Nullable<int> TenantId { get; set; }
        public Nullable<decimal> LegalFees { get; set; }
        public Nullable<decimal> AgencyFee { get; set; }
        public Nullable<decimal> OtherFees { get; set; }
        public Nullable<decimal> TotalServiceCharge { get; set; }
        public Nullable<int> SerialAcc { get; set; }
        public Nullable<decimal> InitialRent { get; set; }
        public Nullable<decimal> Tenure { get; set; }
        public Nullable<int> ProformaId { get; set; }
        public Nullable<decimal> CurrentRent { get; set; }
        public Nullable<decimal> RentsPerUnit { get; set; }
        public Nullable<decimal> ServiceChargePerUnit { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<int> InvoiceNo { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<System.DateTime> FirstRenewalAlert { get; set; }
        public Nullable<System.DateTime> SecondRenewalAlert { get; set; }
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
        public Nullable<decimal> VAT { get; set; }
        public string TMSResponse { get; set; }
    
        public virtual CRM_Clients CRM_Clients { get; set; }
        public virtual CustomerVisit CustomerVisit { get; set; }
        public virtual Real_RentalUnit Real_RentalUnit { get; set; }
        public virtual Acc_CurrencyCode Acc_CurrencyCode { get; set; }
        public virtual Account Account { get; set; }
        public virtual ACCProforma ACCProforma { get; set; }
    }
}

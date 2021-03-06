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
    
    public partial class CRMLead
    {
        public int LeadNo { get; set; }
        public string Lead { get; set; }
        public Nullable<int> SerialAcc { get; set; }
        public Nullable<int> CurrencyCode { get; set; }
        public Nullable<int> InterestedProductID { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> PrimaryContactID { get; set; }
        public string Notes { get; set; }
        public Nullable<int> LeadSourceID { get; set; }
        public Nullable<short> RatingCode { get; set; }
        public Nullable<int> IndustryID { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
        public Nullable<int> Branch { get; set; }
        public string UserId { get; set; }
        public Nullable<int> GLBatchNo { get; set; }
        public string ReviewerId { get; set; }
        public string OverrideId { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public string AuthoriseId { get; set; }
        public string RelatorKey { get; set; }
        public Nullable<System.DateTime> ApprovalEntry { get; set; }
        public string ConversionPeriod { get; set; }
        public Nullable<int> PartnerID { get; set; }
        public Nullable<int> ProspectProduct { get; set; }
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
        public string TMSResponse { get; set; }
    
        public virtual CRMContact CRMContact { get; set; }
        public virtual Product Product { get; set; }
        public virtual Term Term { get; set; }
        public virtual Account Account { get; set; }
    }
}

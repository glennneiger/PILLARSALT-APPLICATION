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
    
    public partial class zkem_DEPARTMENTS
    {
        public int DEPTID { get; set; }
        public string DEPTNAME { get; set; }
        public Nullable<int> SUPDEPTID { get; set; }
        public Nullable<short> InheritParentSch { get; set; }
        public Nullable<short> InheritDeptSch { get; set; }
        public Nullable<short> InheritDeptSchClass { get; set; }
        public Nullable<short> AutoSchPlan { get; set; }
        public Nullable<short> InLate { get; set; }
        public Nullable<short> OutEarly { get; set; }
        public Nullable<short> InheritDeptRule { get; set; }
        public Nullable<int> MinAutoSchInterval { get; set; }
        public Nullable<short> RegisterOT { get; set; }
        public Nullable<int> DefaultSchId { get; set; }
        public Nullable<short> ATT { get; set; }
        public Nullable<short> Holiday { get; set; }
        public Nullable<short> OverTime { get; set; }
        public string ReviewerId { get; set; }
        public string OverrideId { get; set; }
        public Nullable<int> GLBatchNo { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public string AuthoriseId { get; set; }
        public Nullable<bool> Active { get; set; }
        public string RelatorKey { get; set; }
        public Nullable<System.DateTime> ApprovalEntry { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
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
        public Nullable<System.DateTime> ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string UpdateLocker { get; set; }
        public string TMSResponse { get; set; }
    }
}

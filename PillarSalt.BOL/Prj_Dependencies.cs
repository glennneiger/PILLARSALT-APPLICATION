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
    
    public partial class Prj_Dependencies
    {
        public int id { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> TaskId { get; set; }
        public Nullable<int> SuccessorId { get; set; }
        public Nullable<int> PredecessorID { get; set; }
        public Nullable<short> DependencyType { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public string UserId { get; set; }
        public string ReviewerId { get; set; }
        public string OverrideId { get; set; }
        public string AuthoriseId { get; set; }
        public string RelatorKey { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public Nullable<System.DateTime> Entry { get; set; }
        public Nullable<System.DateTime> ApprovalEntry { get; set; }
        public Nullable<int> StartModuleID { get; set; }
        public Nullable<bool> Active { get; set; }
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
    
        public virtual Prj_Projects Prj_Projects { get; set; }
        public virtual Prj_Tasks Prj_Tasks { get; set; }
    }
}
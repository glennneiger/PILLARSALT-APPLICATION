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
    
    public partial class StaffDutyShift
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffDutyShift()
        {
            this.StaffTimes = new HashSet<StaffTime>();
        }
    
        public int id { get; set; }
        public string ShiftName { get; set; }
        public Nullable<System.TimeSpan> StartSignIn { get; set; }
        public Nullable<System.TimeSpan> SignInExact { get; set; }
        public Nullable<System.TimeSpan> EndSignIn { get; set; }
        public Nullable<System.TimeSpan> StartSignOut { get; set; }
        public Nullable<System.TimeSpan> SignOutExact { get; set; }
        public Nullable<System.TimeSpan> EndSignOut { get; set; }
        public Nullable<System.TimeSpan> BreakStart { get; set; }
        public Nullable<System.TimeSpan> BreakEnd { get; set; }
        public string userid { get; set; }
        public Nullable<bool> active { get; set; }
        public string authoriseId { get; set; }
        public Nullable<System.DateTime> entry { get; set; }
        public string reviewerId { get; set; }
        public string OverrideId { get; set; }
        public Nullable<System.DateTime> AprovalEntry { get; set; }
        public string relatorkey { get; set; }
        public string IPAdress { get; set; }
        public string MacAdress { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public Nullable<System.DateTime> ApprovalEntry { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffTime> StaffTimes { get; set; }
    }
}

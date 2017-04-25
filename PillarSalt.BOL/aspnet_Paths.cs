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
    
    public partial class aspnet_Paths
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aspnet_Paths()
        {
            this.aspnet_PersonalizationPerUser = new HashSet<aspnet_PersonalizationPerUser>();
            this.aspnet_PersonalizationPerUser1 = new HashSet<aspnet_PersonalizationPerUser>();
            this.aspnet_PersonalizationPerUser2 = new HashSet<aspnet_PersonalizationPerUser>();
        }
    
        public System.Guid ApplicationId { get; set; }
        public System.Guid PathId { get; set; }
        public string Path { get; set; }
        public string LoweredPath { get; set; }
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
    
        public virtual aspnet_Applications aspnet_Applications { get; set; }
        public virtual aspnet_Applications aspnet_Applications1 { get; set; }
        public virtual aspnet_Applications aspnet_Applications2 { get; set; }
        public virtual aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
        public virtual aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser1 { get; set; }
        public virtual aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser2 { get; set; }
    }
}
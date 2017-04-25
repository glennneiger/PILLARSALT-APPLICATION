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
    
    public partial class Asset_Inspection_Visit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asset_Inspection_Visit()
        {
            this.Asset_FixedAsset_Faults = new HashSet<Asset_FixedAsset_Faults>();
            this.Asset_Inspection_Visit1 = new HashSet<Asset_Inspection_Visit>();
            this.Assets_FixedAsset_Faults = new HashSet<Assets_FixedAsset_Faults>();
        }
    
        public int Id { get; set; }
        public Nullable<int> RequestId { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> InspectionDate { get; set; }
        public Nullable<int> InspectionType { get; set; }
        public Nullable<int> ParentId { get; set; }
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
        public Nullable<int> LocationId { get; set; }
        public Nullable<System.DateTime> ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string UpdateLocker { get; set; }
        public string TMSResponse { get; set; }
    
        public virtual Asset_AssetLocations Asset_AssetLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_FixedAsset_Faults> Asset_FixedAsset_Faults { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_Inspection_Visit> Asset_Inspection_Visit1 { get; set; }
        public virtual Asset_Inspection_Visit Asset_Inspection_Visit2 { get; set; }
        public virtual Asset_InspectionType Asset_InspectionType { get; set; }
        public virtual Asset_Maintenance_Request Asset_Maintenance_Request { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assets_FixedAsset_Faults> Assets_FixedAsset_Faults { get; set; }
    }
}
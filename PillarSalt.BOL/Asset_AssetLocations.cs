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
    
    public partial class Asset_AssetLocations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asset_AssetLocations()
        {
            this.Admin_Appointments = new HashSet<Admin_Appointments>();
            this.Asset_FixedAssets = new HashSet<Asset_FixedAssets>();
            this.Asset_Inspection_Visit = new HashSet<Asset_Inspection_Visit>();
            this.Asset_Relocations = new HashSet<Asset_Relocations>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> DeptId { get; set; }
        public string Building { get; set; }
        public Nullable<int> Floor { get; set; }
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
        public Nullable<int> PropertyId { get; set; }
        public Nullable<System.DateTime> ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string UpdateLocker { get; set; }
        public string TMSResponse { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_Appointments> Admin_Appointments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_FixedAssets> Asset_FixedAssets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_Inspection_Visit> Asset_Inspection_Visit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset_Relocations> Asset_Relocations { get; set; }
        public virtual Real_Property Real_Property { get; set; }
        public virtual Department Department { get; set; }
    }
}

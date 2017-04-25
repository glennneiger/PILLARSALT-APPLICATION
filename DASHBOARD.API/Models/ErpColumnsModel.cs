using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DASHBOARD.API.Models
{
    public class ErpColumnsModel
    {
        public string ModuleId { get; set; }
        public string CurrentStage { get; set; }
        public string UserId { get; set; }
        public string ReviewerId { get; set; }
        public string OverriderId { get; set; }
        public string AuthoriseId { get; set; }
        public bool Active { get; set; }
        public string RelatorKey { get; set; }
        public String IpAddress { get; set; }
        public string MacAddress { get; set; }
        public DateTime Entry { get; set; }
        public DateTime ApprovalEntry { get; set; }
        public DateTime CreationDate { get; set; }
        public string StartModuleId { get; set; }
        public string BranchId { get; set; }
        public string Note { get; set; }
        public string Revision { get; set; }
        public string Token { get; set; }
        public string EditReason { get; set; }
        public string TokenOwner { get; set; }
        public string TokenManifestId { get; set; }
        public string DeclineId { get; set; }
        public string ReviewEntry { get; set; }
        public string DeclineReason { get; set; }
        public string ApprovalComment { get; set; }
        public string ReviewerComment { get; set; }
        public string UpdateLocker { get; set; }

    }
}
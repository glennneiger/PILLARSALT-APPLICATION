using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PillarSalt.BOL;

namespace DASHBOARD.API.Models
{
    public class BagViewModel
    {
        public IEnumerable<TMS_DepositeBag> TmsDepositeBags { get; set; }
        public IEnumerable<TMS_MachineBags> TmsMachineBagses { get; set; }
        public IEnumerable<TMS_MachineBagDetachment> TmsMachineBagDetachments { get; set; }
        public IEnumerable<TMS_Machine_Documents> TmsMachineDocumentses { get; set; }
        //public IEnumerable<TMS_Machine_Profilling> TmsMachineProfillings { get; set; }
        public IEnumerable<TMS_Machine_BrandandModels> TmsMachineBrands { get; set; }
    }
}
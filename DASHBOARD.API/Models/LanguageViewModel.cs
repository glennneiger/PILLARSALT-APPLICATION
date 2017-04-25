using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PillarSalt.BOL;

namespace DASHBOARD.API.Models
{
    public class LanguageViewModel
    {
        public IEnumerable<TMS_Language> TmsLanguages { get; set; }
        public IEnumerable<TMS_LanguageManifest> TmsLanguageManifests { get; set; }
        public IEnumerable<TMS_LanguageResources> TmsLanguageResourceses { get; set; }
    }
}
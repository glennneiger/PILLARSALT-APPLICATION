using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsLanguageManifestController : ApiController
    {
        private TmsLanguageManifestBll _languageBll;

        public TmsLanguageManifestController()
        {
            _languageBll = new TmsLanguageManifestBll();
        }


        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsLanguageManifest")]
        [ResponseType(typeof(TMS_LanguageManifest))]
        public IHttpActionResult GetAllLanguage()
        {
            TmsLanguageResourcesBll resourcesBll = new TmsLanguageResourcesBll();
            var resources = resourcesBll.GetAll();
            var qry = from lm in _languageBll.GetAll()
                      join lr in resources on lm.Id equals lr.LanguageId
                      select new { lm.Id, lm.Description, lm.ScreenName, lm.ControlType, lm.CreationDate, lm.CurrentStage, lm.Notes, lm.UserId, lm.Entry };
            return Ok(qry.ToList().OrderBy(e => e.Entry));
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsLanguageManifest/GetLanguageManifestById/{id}")]
        [ResponseType(typeof(TMS_LanguageManifest))]
        //public IHttpActionResult GetCrmContact(int id)
        public IHttpActionResult GetLanguageManifestById(int id)
        {
            var contact = _languageBll.GetById(id);
            if (contact.Any())
            {
                TmsLanguageResourcesBll resourcesBll = new TmsLanguageResourcesBll();
                var resources = resourcesBll.GetAll();
                var qry = from lm in _languageBll.GetById(id)
                          join lr in resources on lm.Id equals lr.LanguageId
                          select new { lm.Id, lm.Description, lm.ScreenName, lm.ControlType, lm.CreationDate, lm.CurrentStage, lm.Notes, lm.UserId, lm.Entry };
                return Ok(qry.ToList().OrderBy(e => e.Entry));
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });
            }

        }

        //GET: api/TmsLanguageManifest/GetLanguageByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsLanguageManifest/GetLanguageManifestByContext/{sValue}")]
        [ResponseType(typeof(TMS_LanguageManifest))]
        public IHttpActionResult GetLanguageManifestByContext(string sValue)
        {

            if (sValue != null)
            {
                TmsLanguageResourcesBll resourcesBll = new TmsLanguageResourcesBll();
                var resources = resourcesBll.GetAll();
                var qry = from lm in _languageBll.GetAll()
                    .Where(lm => lm.Notes.Contains(sValue))
                          join lr in resources on lm.Id equals lr.LanguageId
                          select new { lm.Id, lm.Description, lm.ScreenName, lm.ControlType, lm.CreationDate, lm.CurrentStage, lm.Notes, lm.UserId, lm.Entry };
                return Ok(qry.ToList().OrderBy(e => e.Entry));
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsLanguageManifest")]
        [ResponseType(typeof(TMS_LanguageManifest))]
        public IHttpActionResult Post(TMS_LanguageManifest language)
        {
            if (ModelState.IsValid)
            {
                int c = _languageBll.Insert(language);
                if (c == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });
            }
            else
            {
                return Json(new { Msg = "0" });
            }
        }


        // PUT: api/TmsLanguageManifest/UpdateLanguage/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsLanguageManifest/UpdateLanguageManifest/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateLanguageManifest(int id, TMS_LanguageManifest language)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != language.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _languageBll.Update(language);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteLanguageExists(id))
                {
                    //return NotFound();
                    return Json(new { Msg = "0", Reason = "No row affected!" });
                }
                else
                {
                    throw;
                }
            }
        }


        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("DELETE")]
        [Route("api/TmsLanguageManifest/DeleteLanguageManifest/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteLanguageManifest(int id)
        {
            var contact = _languageBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _languageBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool DeleteLanguageExists(int id)
        {
            return _languageBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

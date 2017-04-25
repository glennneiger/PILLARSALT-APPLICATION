using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsLanguageController : ApiController
    {
        private TmsLanguageBll _languageBll;

        public TmsLanguageController()
        {
            _languageBll = new TmsLanguageBll();
        }


        //GET: api/crmcontact
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.Route("api/TmsLanguage")]
        [ResponseType(typeof(TMS_Language))]
        public IHttpActionResult GetAllLanguage()
        {
            var qry = from l in _languageBll.GetAll()
                      select new { l.Id, l.Description, l.CurrentStage, l.Notes, l.CreationDate, l.Entry };
            return Ok(qry.ToList().OrderBy(c => c.Entry));
        }

        //GET: api/CrmContact/id
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.Route("api/TmsLanguage/GetLanguageById/{id}")]
        [ResponseType(typeof(TMS_Language))]
        //public IHttpActionResult GetCrmContact(int id)
        public IHttpActionResult GetLanguageById(int id)
        {
            var contact = _languageBll.GetById(id);
            if (contact.Any())
            {
                var qry = from l in _languageBll.GetById(id)
                          select new { l.Id, l.Description, l.CurrentStage, l.Notes, l.CreationDate, l.Entry };
                return Ok(qry.ToList().OrderBy(e => e.Entry));
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Record set is empty!" });
            }

        }

        //GET: api/TmsLanguage/GetLanguageByContext/{sValue}
        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.Route("api/TmsLanguage/GetLanguageByContext/{sValue}")]
        [ResponseType(typeof(TMS_Language))]
        public IHttpActionResult GetLanguageByContext(string sValue)
        {

            if (sValue != null)
            {
                var context = from c in _languageBll.GetAll()
                    .Where(c => c.LanguageCategory.Equals(sValue))
                              select new { c.Id, c.Description, c.CurrentStage, c.Notes, c.CreationDate, c.Entry };
                return Ok(context.ToList().OrderBy(e => e.Entry));
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.Route("api/TmsLanguage/")]
        [ResponseType(typeof(TMS_Language))]
        public IHttpActionResult Post(TMS_Language language)
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


        // PUT: api/TmsLanguage/UpdateLanguage/{id}
        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.Route("api/TmsLanguage/UpdateLanguage/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateLanguage(int id, TMS_Language language)
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

        //[Authorize]
        // PUT: api/crmcontact/UpdateCrmContact
        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.Route("api/TmsLanguage/DeleteLanguage/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteLanguage(int id)
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

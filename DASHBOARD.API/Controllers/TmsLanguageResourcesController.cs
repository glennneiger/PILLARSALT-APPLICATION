using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DASHBOARD.API.Models;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsLanguageResourcesController : ApiController
    {
        private TmsLanguageResourcesBll _languageResourcesBll;
        private LanguageViewModel _languageViewModel;
        private PillarsaltDbContext _dbContext;


        public TmsLanguageResourcesController()
        {
            _languageResourcesBll = new TmsLanguageResourcesBll();
            _languageViewModel = new LanguageViewModel();
            _dbContext = new PillarsaltDbContext();
        }


        //GET: api/AccCurrencyCode
        [AcceptVerbs("GET")]
        [Route("api/TmsLanguageResources")]
        [ResponseType(typeof(TMS_LanguageResources))]
        public IHttpActionResult GetAllLanguageResources()
        {
            _languageViewModel.TmsLanguages = _dbContext.TMS_Language.ToList();
            _languageViewModel.TmsLanguageManifests = _dbContext.TMS_LanguageManifest.ToList();
            _languageViewModel.TmsLanguageResourceses = _dbContext.TMS_LanguageResources.ToList();
            var qry = _languageResourcesBll.GetAll()
                .Join(_languageViewModel.TmsLanguages, lr => lr.LanguageId, l => l.Id, (lr, l) => new
                {
                    l.Id,
                    l.Active,
                    l.LanguageCategory,
                    l.LanguageType,
                    lr.AudioResources,
                    lr.LanguageId,
                    lrActive = lr.Active,
                    lrEntry = lr.Entry,
                    lr.TextResources,
                    lr.CurrentStage,
                    LangDescription = l.Description,
                    ResourcesrDescription = lr.Description
                });
            return Ok(qry.ToList());
        }


        //GET: api/AccCurrencyCode/GetLanguageResourcesMappingById/{id}
        [AcceptVerbs("GET")]
        [Route("api/TmsLanguageResources/GetLanguageResourcesById/{id}")]
        [ResponseType(typeof(TMS_LanguageResources))]
        public IHttpActionResult GetLanguageResourcesById(int id)
        {
            var contact = _languageResourcesBll.GetById(id);
            if (contact.Any())
            {

                _languageViewModel.TmsLanguages = _dbContext.TMS_Language.ToList();
                _languageViewModel.TmsLanguageManifests = _dbContext.TMS_LanguageManifest.ToList();
                _languageViewModel.TmsLanguageResourceses = _dbContext.TMS_LanguageResources.ToList();
                var qry = from lr in _languageResourcesBll.GetById(id)
                          join l in _languageViewModel.TmsLanguages on lr.LanguageId equals l.Id
                          select
                              new
                              {
                                  l.Id,
                                  l.Active,
                                  l.LanguageCategory,
                                  l.LanguageType,
                                  lr.AudioResources,
                                  lr.LanguageId,
                                  lrActive = lr.Active,
                                  lrEntry = lr.Entry,
                                  lr.TextResources,
                                  lr.CurrentStage,
                                  LangDescription = l.Description,
                                  ResourcesrDescription = lr.Description
                              };


                return Ok(qry.ToList());
            }
            else
            {
                return Json(new { Msg = "0", Reason = "Recordset is empty!" });

            }

        }

        //GET: api/TmsLanguageResources/GetLanguageResourcesByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsLanguageResources/GetLanguageResourcesByContext/{sValue}")]
        [ResponseType(typeof(TMS_LanguageResources))]
        public IHttpActionResult GetLanguageResourcesByContext(string sValue)
        {

            if (sValue != null)
            {
                _languageViewModel.TmsLanguages = _dbContext.TMS_Language.ToList();
                _languageViewModel.TmsLanguageManifests = _dbContext.TMS_LanguageManifest.ToList();
                _languageViewModel.TmsLanguageResourceses = _dbContext.TMS_LanguageResources.ToList();
                var qry = from lr in _languageResourcesBll.GetAll().Where(c => c.TextResources.Contains(sValue))
                          join l in _languageViewModel.TmsLanguages on lr.LanguageId equals l.Id
                          select
                              new
                              {
                                  l.Id,
                                  l.Active,
                                  l.LanguageCategory,
                                  l.LanguageType, 
                                  lr.AudioResources,
                                  lr.LanguageId,
                                  lrActive = lr.Active,
                                  lrEntry = lr.Entry,
                                  lr.TextResources,
                                  lr.CurrentStage,
                                  LangDescription = l.Description,
                                  ResourcesrDescription = lr.Description
                              };

                return Ok(qry.ToList());
            }
            return Json(new { Msg = "0" });
        }

        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsLanguageResources")]
        [ResponseType(typeof(TMS_LanguageResources))]
        public IHttpActionResult Post(TMS_LanguageResources language)
        {
            if (ModelState.IsValid)
            {
                int c = _languageResourcesBll.Insert(language);
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


        // PUT: api/AccAccountsLanguageResourcesDetails/UpdateAccountsLanguageResourcesDetails/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsLanguageResources/UpdateLanguageResources")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateLanguageResources(int id, TMS_LanguageResources language)
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
                int s = _languageResourcesBll.Update(language);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageResourcesMappingExists(id))
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
        [Route("api/TmsLanguageResources/DeleteLanguageResources/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCurrencyCode(int id)
        {
            var contact = _languageResourcesBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _languageResourcesBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Record Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool LanguageResourcesMappingExists(int id)
        {
            return _languageResourcesBll.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}

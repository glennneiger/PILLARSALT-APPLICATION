using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsConfigureScreenController : ApiController
    {
        private TmsConfigureScreenBll _configureScreenBll;
        public TmsConfigureScreenController()
        {
            _configureScreenBll = new TmsConfigureScreenBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsConfigureScreen")]
        [ResponseType(typeof(TMS_ConfigureScreen))]
        public IHttpActionResult GetAllConfigureScreen()
        {
            var mp = _configureScreenBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.MachineName,
                            a.ConfigurationStatus,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsConfigureScreen/GetConfigureScreenByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsConfigureScreen/GetConfigureScreenByContext/{sValue}")]
        [ResponseType(typeof(TMS_ConfigureScreen))]
        public IHttpActionResult GetConfigureScreenByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _configureScreenBll.GetAll().Where(c => c.MachineName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.MachineName,
                                a.ConfigurationStatus,
                                a.Notes,
                                a.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsConfigureScreen/GeConfigureScreenById/{id}")]
        [ResponseType(typeof(TMS_ConfigureScreen))]
        public IHttpActionResult GetConfigureScreenById(int id)
        {
            if (id == 0)
            {
                var mp = _configureScreenBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.MachineName,
                        a.ConfigurationStatus,
                        a.Notes,
                        a.Entry
                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsConfigureScreen")]
        [ResponseType(typeof(TMS_ConfigureScreen))]
        public IHttpActionResult Post(TMS_ConfigureScreen tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _configureScreenBll.Insert(tmsAdvertiseCash);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });

                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                return Json(new { Msg = "0", Reason = "No row affected!" });
            }
        }


        // POST: api/crmcontact/UpdateAccountSetup/{id}
        [AcceptVerbs("POST")]
        [Route("api/TmsConfigureScreen/UpdateConfigureScreen/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateConfigureScreen(int id, TMS_ConfigureScreen tmsAdvertiseCash)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != tmsAdvertiseCash.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _configureScreenBll.Update(tmsAdvertiseCash);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmsAdvertiseCashExists(id))
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

        // PUT: api/crmcontact/Delete/id
        [AcceptVerbs("DELETE")]
        [Route("api/TmsConfigureScreen/DeleteConfigureScreen/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteConfigureScreen(int id)
        {
            var contact = _configureScreenBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _configureScreenBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _configureScreenBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
}

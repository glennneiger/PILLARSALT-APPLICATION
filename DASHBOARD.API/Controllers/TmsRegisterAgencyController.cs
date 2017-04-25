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
    public class TmsRegisterAgencyController : ApiController
    {
        private TmsRegisterAgencyBll _registerAgencyBll;
        public TmsRegisterAgencyController()
        {
            _registerAgencyBll = new TmsRegisterAgencyBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsRegisterAgency")]
        [ResponseType(typeof(TMS_RegisterAgency))]
        public IHttpActionResult GetAllRegisterAgency()
        {
            var mp = _registerAgencyBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.AgencyName,
                            a.ContactPersonName,
                            a.ContactPersonPhoneNo,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsRegisterAgency/GetRegisterAgencyByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsRegisterAgency/GetRegisterAgencyByContext/{sValue}")]
        [ResponseType(typeof(TMS_RegisterAgency))]
        public IHttpActionResult GetRegisterAgencyByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _registerAgencyBll.GetAll().Where(c => c.AgencyName.Equals(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.AgencyName,
                                a.ContactPersonName,
                                a.ContactPersonPhoneNo,
                                a.Notes,
                                a.Entry

                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsRegisterAgency/GeRegisterAgencyById/{id}")]
        [ResponseType(typeof(TMS_RegisterAgency))]
        public IHttpActionResult GetRegisterAgencyById(int id)
        {
            if (id == 0)
            {
                var mp = _registerAgencyBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.AgencyName,
                        a.ContactPersonName,
                        a.ContactPersonPhoneNo,
                        a.Notes,
                        a.Entry

                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsRegisterAgency")]
        [ResponseType(typeof(TMS_RegisterAgency))]
        public IHttpActionResult Post(TMS_RegisterAgency tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _registerAgencyBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsRegisterAgency/UpdateRegisterAgency/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateRegisterAgency(int id, TMS_RegisterAgency tmsAdvertiseCash)
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
                int s = _registerAgencyBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsRegisterAgency/DeleteRegisterAgency/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteRegisterAgency(int id)
        {
            var contact = _registerAgencyBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _registerAgencyBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _registerAgencyBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

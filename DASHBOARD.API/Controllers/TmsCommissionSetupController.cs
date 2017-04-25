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
    public class TmsCommissionSetupController : ApiController
    {
        private TmsCommissionSetupBll _commissionSetupBll;
        public TmsCommissionSetupController()
        {
            _commissionSetupBll = new TmsCommissionSetupBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsCommissionSetup")]
        [ResponseType(typeof(TMS_Commission_Setup))]
        public IHttpActionResult GetAllCommissionSetup()
        {
            var mp = _commissionSetupBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.CommissionType,
                            a.Percentage,
                            a.CommissionTotal,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsCommissionSetup/GetCommissionSetupByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsCommissionSetup/GetCommissionSetupByContext/{sValue}")]
        [ResponseType(typeof(TMS_Commission_Setup))]
        public IHttpActionResult GetCommissionSetupByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _commissionSetupBll.GetAll().Where(c => c.CommissionType.Equals(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.CommissionType,
                                a.Percentage,
                                a.CommissionTotal,
                                a.Notes,
                                a.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsCommissionSetup/GeCommissionSetupById/{id}")]
        [ResponseType(typeof(TMS_Commission_Setup))]
        public IHttpActionResult GetCommissionSetupById(int id)
        {
            if (id == 0)
            {
                var mp = _commissionSetupBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.CommissionType,
                        a.Percentage,
                        a.CommissionTotal,
                        a.Notes,
                        a.Entry
                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsCommissionSetup")]
        [ResponseType(typeof(TMS_Commission_Setup))]
        public IHttpActionResult Post(TMS_Commission_Setup tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _commissionSetupBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsCommissionSetup/UpdateCommissionSetup/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateCommissionSetup(int id, TMS_Commission_Setup tmsAdvertiseCash)
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
                int s = _commissionSetupBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsCommissionSetup/DeleteCommissionSetup/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCommissionSetup(int id)
        {
            var contact = _commissionSetupBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _commissionSetupBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _commissionSetupBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

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
    public class TmsAdvertSchedulingController : ApiController
    {
        private TmsAdvertSchedulingBll _advertSchedulingBll;
        public TmsAdvertSchedulingController()
        {
            _advertSchedulingBll = new TmsAdvertSchedulingBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAdvertScheduling")]
        [ResponseType(typeof(TMS_AdvertScheduling))]
        public IHttpActionResult GetAllAdvertScheduling()
        {
            var disburse = _advertSchedulingBll.GetAll()
                .Select(
                    d =>
                        new
                        {
                            d.Id,
                            d.AdvertName,
                            d.ScheduleDateFrom,
                            d.ScheduleDateTo,
                            d.AdvertCompany,
                            d.Notes,
                            d.Entry
                        }).OrderBy(c => c.Entry).ThenByDescending(c => c.Entry);

            return Ok(disburse.ToList());
        }

        //GET: api/TmsMachineBrand/GetMachineBrandByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsAdvertScheduling/GetAdvertSchedulingByContext/{sValue}")]
        [ResponseType(typeof(TMS_AdvertScheduling))]
        public IHttpActionResult GetAdvertSchedulingByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _advertSchedulingBll.GetAll().Where(c => c.AdvertName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                        d =>
                            new
                            {
                                d.Id,
                                d.AdvertName,
                                d.ScheduleDateFrom,
                                d.ScheduleDateTo,
                                d.AdvertCompany,
                                d.Notes,
                                d.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Ok(new { Msg = "0" });
        }

        [AcceptVerbs("GET")]
        [Route("api/TmsAdvertScheduling/GetAdvertSchedulingById/{id}")]
        [ResponseType(typeof(TMS_AdvertScheduling))]
        public IHttpActionResult GetAdvertSchedulingById(int id)
        {
            var disburse = _advertSchedulingBll.GetAll().Where(c => c.Id.Equals(id))
                .Select
                    (
                        d =>
                            new
                            {
                                d.Id,
                                d.AdvertName,
                                d.ScheduleDateFrom,
                                d.ScheduleDateTo,
                                d.AdvertCompany,
                                d.Notes,
                                d.Entry
                            }).OrderBy(c => c.Entry).ToList();
            return Ok(disburse.ToList());
        }



        [AcceptVerbs("POST")]
        [Route("api/TmsAdvertScheduling")]
        [ResponseType(typeof(TMS_AdvertScheduling))]
        public IHttpActionResult InsertAdvertScheduling(TMS_AdvertScheduling tmsDisbursment)
        {
            if (tmsDisbursment == null)
            {
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _advertSchedulingBll.Insert(tmsDisbursment);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                return Ok(new { Msg = "0", Reason = "No row affected!" });
            }
        }


        [AcceptVerbs("POST")]
        [Route("api/TmsAdvertScheduling/UpdateAdvertScheduling/{id}")]
        [ResponseType(typeof(TMS_AdvertScheduling))]
        public IHttpActionResult UpdateAdvertScheduling(int id, TMS_AdvertScheduling tmsDisbursment)
        {
            if (tmsDisbursment == null)
            {
                return Ok(new { Msg = "0" });
            }

            if (id != tmsDisbursment.Id)
            {
                //return BadRequest();
                return Ok(new { Msg = "0" });
            }

            try
            {
                int s = _advertSchedulingBll.Update(tmsDisbursment);
                if (s == 1)
                {
                    return Ok(new { Msg = "1", Reason = "Record Update Successfull!" });

                }
                return Ok(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmsAdvertCashExists(id))
                {
                    //return NotFound();
                    return Ok(new { Msg = "0", Reason = "No row affected!" });
                }
                else
                {
                    throw;
                }
            }
        }

        [AcceptVerbs("DELETE")]
        [Route("api/TmsAdvertScheduling/DeleteAdvertScheduling/{id}")]
        [ResponseType(typeof(TMS_Disbursment))]
        public IHttpActionResult DeleteAdvertScheduling(int id)
        {
            var disburse = _advertSchedulingBll.GetById(id);
            if (disburse == null)
            {
                return Ok(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _advertSchedulingBll.Delete(id);
            if (d == 1)
            {
                return Ok(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Ok(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertCashExists(int id)
        {
            return _advertSchedulingBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }
    
}

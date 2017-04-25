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
    public class TmsResourceAllocationController : ApiController
    {
        private TmsResourceAllocationBll _resourceAllocationBll;
        public TmsResourceAllocationController()
        {
            _resourceAllocationBll = new TmsResourceAllocationBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsResourceAllocation")]
        [ResponseType(typeof(TMS_ResourceAllocation))]
        public IHttpActionResult GetAllResourceAllocation()
        {
            var mp = _resourceAllocationBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.ResourseName,
                            a.CompanyName, 
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsResourceAllocation/GetResourceAllocationByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsResourceAllocation/GetResourceAllocationByContext/{sValue}")]
        [ResponseType(typeof(TMS_ResourceAllocation))]
        public IHttpActionResult GetResourceAllocationByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _resourceAllocationBll.GetAll().Where(c => c.ResourseName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.ResourseName,
                                a.CompanyName,
                                a.Notes,
                                a.Entry

                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsResourceAllocation/GeResourceAllocationById/{id}")]
        [ResponseType(typeof(TMS_ResourceAllocation))]
        public IHttpActionResult GetResourceAllocationById(int id)
        {
            if (id == 0)
            {
                var mp = _resourceAllocationBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.ResourseName,
                        a.CompanyName,
                        a.Notes,
                        a.Entry

                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsResourceAllocation")]
        [ResponseType(typeof(TMS_ResourceAllocation))]
        public IHttpActionResult Post(TMS_ResourceAllocation tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _resourceAllocationBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsResourceAllocation/UpdateResourceAllocation/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateResourceAllocation(int id, TMS_ResourceAllocation tmsAdvertiseCash)
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
                int s = _resourceAllocationBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsResourceAllocation/DeleteResourceAllocation/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteResourceAllocation(int id)
        {
            var contact = _resourceAllocationBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _resourceAllocationBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _resourceAllocationBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

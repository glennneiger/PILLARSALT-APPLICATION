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
    public class TmsBulkCashController : ApiController
    {
        private TmsBulkCashBll _bulkCashBll;
        public TmsBulkCashController()
        {
            _bulkCashBll = new TmsBulkCashBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsBulkCash")]
        [ResponseType(typeof(TMS_BulkCash))]
        public IHttpActionResult GetAllBulkCash()
        {
            var mp = _bulkCashBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.CashLocation,
                            a.CashDestination,
                            a.TotalAmoutofCash,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsBulkCash/GetBulkCashByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsBulkCash/GetBulkCashByContext/{sValue}")]
        [ResponseType(typeof(TMS_BulkCash))]
        public IHttpActionResult GetBulkCashByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _bulkCashBll.GetAll().Where(c => c.CashDestination.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.CashLocation,
                                a.CashDestination,
                                a.TotalAmoutofCash,
                                a.Notes,
                                a.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsBulkCash/GeBulkCashById/{id}")]
        [ResponseType(typeof(TMS_BulkCash))]
        public IHttpActionResult GetBulkCashById(int id)
        {
            if (id == 0)
            {
                var mp = _bulkCashBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.CashLocation,
                        a.CashDestination,
                        a.TotalAmoutofCash,
                        a.Notes,
                        a.Entry
                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsBulkCash")]
        [ResponseType(typeof(TMS_BulkCash))]
        public IHttpActionResult Post(TMS_BulkCash tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _bulkCashBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsBulkCash/UpdateBulkCash/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateBulkCash(int id, TMS_BulkCash tmsAdvertiseCash)
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
                int s = _bulkCashBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsBulkCash/DeleteBulkCash/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteBulkCash(int id)
        {
            var contact = _bulkCashBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _bulkCashBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _bulkCashBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

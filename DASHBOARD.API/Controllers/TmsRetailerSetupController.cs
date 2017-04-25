using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsRetailerSetupController : ApiController
    {
        private TmsRetailerSetupBll _retailerSetupBll;
        public TmsRetailerSetupController()
        {
            _retailerSetupBll = new TmsRetailerSetupBll();
        }
        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsRetailerSetup")]
        [ResponseType(typeof(TMS_Retailer_Setup))]
        public IHttpActionResult GetAllRetailerSetup()
        {
            var mp = _retailerSetupBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.RetailerName,
                            a.RetailerLocation,
                            a.AcctNo,
                            a.AcctName,
                            a.ContactPersonName,
                            a.ContactPersonPhone,
                            a.ContactPersonEmail,
                            a.Notes,
                            a.Entry

                        }).OrderBy(c => c.Entry);

            return Ok(mp.ToList());
        }

        //GET: api/TmsRetailerSetup/GetRetailerSetupByContext/{sValue}
        [AcceptVerbs("GET")]
        [Route("api/TmsRetailerSetup/GetRetailerSetupByContext/{sValue}")]
        [ResponseType(typeof(TMS_Retailer_Setup))]
        public IHttpActionResult GetRetailerSetupByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _retailerSetupBll.GetAll().Where(c => c.RetailerName.Contains(sValue) || c.AcctName.Contains(sValue) || c.ContactPersonName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                       a =>
                            new
                            {
                                a.Id,
                                a.RetailerName,
                                a.RetailerLocation,
                                a.AcctNo,
                                a.AcctName,
                                a.ContactPersonName,
                                a.ContactPersonPhone,
                                a.ContactPersonEmail,
                                a.Notes,
                                a.Entry

                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }

            return Json(new { Msg = "0" });
        }

        //GET: api/crmcontact
        [Route("api/TmsRetailerSetup/GeRetailerSetupById/{id}")]
        [ResponseType(typeof(TMS_Retailer_Setup))]
        public IHttpActionResult GetRetailerSetupById(int id)
        {
            if (id == 0)
            {
                var mp = _retailerSetupBll.GetAll().Where(i => i.Id.Equals(id))
                    .Select(a => new
                    {
                        a.Id,
                        a.RetailerName,
                        a.RetailerLocation,
                        a.AcctNo,
                        a.AcctName,
                        a.ContactPersonName,
                        a.ContactPersonPhone,
                        a.ContactPersonEmail,
                        a.Notes,
                        a.Entry

                    });

                return Ok(mp.ToList());
            }
            return Json(new { Msg = "0", Reason = "Empty record, no record with such details!" });


        }


        //POST: api/TmsAdvertiseCash
        [AcceptVerbs("POST")]
        [Route("api/TmsRetailerSetup")]
        [ResponseType(typeof(TMS_Retailer_Setup))]
        public IHttpActionResult Post(TMS_Retailer_Setup tmsAdvertiseCash)
        {
            if (tmsAdvertiseCash == null)
            {
                return Json(new { Msg = "0" });

            }

            try
            {
                int s = _retailerSetupBll.Insert(tmsAdvertiseCash);
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
        [Route("api/TmsRetailerSetup/UpdateRetailerSetup/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateRetailerSetup(int id, TMS_Retailer_Setup tmsAdvertiseCash)
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
                int s = _retailerSetupBll.Update(tmsAdvertiseCash);
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
        [Route("api/TmsRetailerSetup/DeleteRetailerSetup/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteRetailerSetup(int id)
        {
            var contact = _retailerSetupBll.GetAll().Where(i => i.Id.Equals(id));
            if (!contact.Any())
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _retailerSetupBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }

        private bool TmsAdvertiseCashExists(int id)
        {
            return _retailerSetupBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    

    
}

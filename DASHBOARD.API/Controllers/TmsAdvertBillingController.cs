using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using PillarSalt.BLL;
using PillarSalt.BOL;

namespace DASHBOARD.API.Controllers
{
    public class TmsAdvertBillingController : ApiController
    {
        private TmsAdvertBillingBll _advertBillingBll;
        public TmsAdvertBillingController()
        {
            _advertBillingBll = new TmsAdvertBillingBll();
        }

        //GET: api/crmcontact
        [AcceptVerbs("GET")]
        [Route("api/TmsAdvertBilling")]
        [ResponseType(typeof(TMS_AdvertBilling))]
        public IHttpActionResult GetAllAdvertBilling()
        {
            var contact = _advertBillingBll.GetAll()
                .Select(
                    a =>
                        new
                        {
                            a.Id,
                            a.AdvertCategory,
                            a.AdvertName,
                            a.AmountCharge,
                            a.Notes,
                            a.AccountName,
                            a.Entry
                        }).OrderBy(c => c.Entry).ThenByDescending(c => c.Entry);

            return Ok(contact.ToList());
        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsAdvertBilling/GetAdvertBillingById/{id}")]
        [ResponseType(typeof(TMS_AdvertBilling))]
        public IHttpActionResult GetAdvertBillingById(int id)
        {
            var contact = _advertBillingBll.GetById(id);
            if (contact != null)
            {
                var contact2 = _advertBillingBll.GetAll()
                    .Select(
                        a => new
                        {
                            a.Id,
                            a.AdvertCategory,
                            a.AdvertName,
                            a.AmountCharge,
                            a.Notes,
                            a.AccountName,
                            a.Entry
                        }
                    )
                    .Where(c => c.Id == id);

                return Ok(contact2);
            }
            else
            {
                return Json(new { Msg = "0" });

            }

        }

        //GET: api/CrmContact/id
        [AcceptVerbs("GET")]
        [Route("api/TmsAdvertBilling/GetAdvertBillingByContext/{sValue}")]
        [ResponseType(typeof(TMS_AdvertBilling))]
        public IHttpActionResult GetTmsAdvertBillingByContext(string sValue)
        {
            if (sValue != null)
            {
                var context = _advertBillingBll.GetAll().Where(c => c.AccountName.Contains(sValue)).ToList();
                var nContext = from c in context
                    .Select
                    (
                        a =>
                            new
                            {
                                a.Id,
                                a.AdvertCategory,
                                a.AdvertName,
                                a.Entry
                            }).OrderBy(c => c.Entry).ToList()
                               select (c);
                return Ok(nContext.ToList());
            }
            return Json(new { Msg = "0" });
        }


        //POST : api/crmcontact/post
        [AcceptVerbs("POST")]
        [Route("api/TmsAdvertBilling")]
        [ResponseType(typeof(TMS_AdvertBilling))]
        public IHttpActionResult Post(TMS_AdvertBilling tmsAdvertBilling)
        {
            if (ModelState.IsValid)
            {
                int c = _advertBillingBll.Insert(tmsAdvertBilling);
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


        // PUT: api/crmcontact/UpdateCrmContact
        [AcceptVerbs("POST")]
        [Route("api/TmsAdvertBilling/UpdateAdvertBilling/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateContact(int id, TMS_AdvertBilling advertBilling)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new { Msg = "0" });
            }

            if (id != advertBilling.Id)
            {
                //return BadRequest();
                return Json(new { Msg = "0" });
            }

            try
            {
                int s = _advertBillingBll.Update(advertBilling);
                if (s == 1)
                {
                    return Json(new { Msg = "1" });
                }
                return Json(new { Msg = "0" });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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


        // PUT: api/TmsAdvertBilling/DeleteAdvertBilling/{id}
        [AcceptVerbs("DELETE")]
        [Route("api/TmsAdvertBilling/DeleteAdvertBilling/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteContact(int id)
        {
            var contact = _advertBillingBll.GetById(id);
            if (contact == null)
            {
                return Json(new { Msg = "0", Reason = "No record found!" });
            }
            int d = _advertBillingBll.Delete(id);
            if (d == 1)
            {
                return Json(new { Msg = "1", Reason = "Entry Deleted!" });
            }
            return Json(new { Msg = "0", Reason = "Deleted Failed!" });
        }



        private bool ContactExists(int id)
        {
            return _advertBillingBll.GetAll().Count(e => e.Id == id) > 0;
        }

    }

    


}
